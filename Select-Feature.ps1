<#
.SYNOPSIS
    Selects or toggles which .Run() feature step to execute in Program.cs.

.DESCRIPTION
    Automates testing of learning features in Program.cs.
    - If a feature name is provided, all other .Run() steps are commented out and the selected one is uncommented.
    - If run with no parameters (or "all"), all .Run() steps in Program.cs are uncommented.
    - Supports listing all features and optionally running 'dotnet run' immediately.

.PARAMETER Feature
    The name (or partial name) of the feature class to test (e.g., 'Calculator', 'WeatherStation').
    Leave empty to uncomment all features.

.PARAMETER List
    Switch to list all detected features and their current active/commented status.

.PARAMETER Run
    Switch to immediately execute 'dotnet run' after updating Program.cs.

.EXAMPLE
    .\Select-Feature.ps1 Calculator
    Comments out all features except Calculator.Run().

.EXAMPLE
    .\Select-Feature.ps1
    Uncomments all features.

.EXAMPLE
    .\Select-Feature.ps1 -List
    Lists all available features.

.EXAMPLE
    .\Select-Feature.ps1 JaggedArrays -Run
    Enables JaggedArrays and immediately runs the project.
#>

[CmdletBinding(DefaultParameterSetName = 'Select')]
param(
    [Parameter(Position = 0, ParameterSetName = 'Select')]
    [string]$Feature,

    [Parameter(ParameterSetName = 'List')]
    [switch]$List,

    [Parameter(ParameterSetName = 'Select')]
    [switch]$Run
)

# Locate Program.cs
$candidates = @(
    (Join-Path $PSScriptRoot "First Steps\Program.cs"),
    (Join-Path $PSScriptRoot "Program.cs"),
    (Join-Path $PWD "First Steps\Program.cs"),
    (Join-Path $PWD "Program.cs")
)

$targetFile = $null
foreach ($path in $candidates) {
    if (Test-Path $path) {
        $targetFile = (Resolve-Path $path).Path
        break
    }
}

if (-not $targetFile) {
    $found = Get-ChildItem -Path $PSScriptRoot -Filter "Program.cs" -Recurse -ErrorAction SilentlyContinue | Select-Object -First 1
    if ($found) {
        $targetFile = $found.FullName
    } else {
        Write-Error "Could not find Program.cs in repository."
        return
    }
}

$lines = [System.IO.File]::ReadAllLines($targetFile, [System.Text.Encoding]::UTF8)

# Find all .Run() lines
$featurePattern = '^(?<indent>\s*)(?<comment>//\s*)?(?<stmt>(?<class>[a-zA-Z0-9_]+)\.Run\s*\([^;]*\);)(?<trailing>.*)$'

$features = [System.Collections.Generic.List[PSCustomObject]]::new()
for ($i = 0; $i -lt $lines.Count; $i++) {
    if ($lines[$i] -match $featurePattern) {
        $features.Add([PSCustomObject]@{
            LineIndex = $i
            ClassName = $Matches['class']
            IsCommented = [bool]($Matches['comment'])
            Indent = $Matches['indent']
            Stmt = $Matches['stmt']
            Trailing = $Matches['trailing']
        })
    }
}

if ($features.Count -eq 0) {
    Write-Warning "No .Run() steps found in $targetFile"
    return
}

# If -List switch was requested
if ($List) {
    Write-Host "`nAvailable features in Program.cs:" -ForegroundColor Cyan
    foreach ($f in $features) {
        $status = if ($f.IsCommented) { "[ ]" } else { "[x]" }
        $color  = if ($f.IsCommented) { "DarkGray" } else { "Green" }
        Write-Host "  $status $($f.ClassName)" -ForegroundColor $color
    }
    Write-Host ""
    return
}

$enableAll = [string]::IsNullOrWhiteSpace($Feature) -or ($Feature -ieq "all")

if ($enableAll) {
    # Uncomment all
    for ($i = 0; $i -lt $lines.Count; $i++) {
        if ($lines[$i] -match $featurePattern) {
            $lines[$i] = "$($Matches['indent'])$($Matches['stmt'])$($Matches['trailing'])"
        }
    }
    Write-Host "Uncommented all $($features.Count) feature steps in Program.cs." -ForegroundColor Green
} else {
    # Match candidate
    # 1. Exact match (case-insensitive)
    $matched = @($features | Where-Object { $_.ClassName -ieq $Feature })
    
    # 2. If no exact match, partial match
    if ($matched.Count -eq 0) {
        $matched = @($features | Where-Object { $_.ClassName -ilike "*$Feature*" })
    }

    if ($matched.Count -eq 0) {
        Write-Host "Feature '$Feature' not found!" -ForegroundColor Red
        Write-Host "Available features:" -ForegroundColor Yellow
        foreach ($f in $features) {
            Write-Host "  - $($f.ClassName)"
        }
        return
    }

    if ($matched.Count -gt 1) {
        Write-Host "Multiple features matched '$Feature':" -ForegroundColor Yellow
        foreach ($m in $matched) {
            Write-Host "  - $($m.ClassName)"
        }
        Write-Host "Please be more specific." -ForegroundColor Yellow
        return
    }

    $targetClass = $matched[0].ClassName

    for ($i = 0; $i -lt $lines.Count; $i++) {
        if ($lines[$i] -match $featurePattern) {
            $cls = $Matches['class']
            $indent = $Matches['indent']
            $stmt = $Matches['stmt']
            $trailing = $Matches['trailing']

            if ($cls -ieq $targetClass) {
                # Uncomment
                $lines[$i] = "$indent$stmt$trailing"
            } else {
                # Comment
                $lines[$i] = "$indent// $stmt$trailing"
            }
        }
    }
    Write-Host "Active feature: $targetClass" -ForegroundColor Green
    Write-Host "All other $($features.Count - 1) features commented out." -ForegroundColor DarkGray
}

# Save with UTF-8 BOM encoding
$utf8WithBom = New-Object System.Text.UTF8Encoding($true)
[System.IO.File]::WriteAllLines($targetFile, $lines, $utf8WithBom)

# Optionally run
if ($Run) {
    $projectDir = Split-Path $targetFile -Parent
    Write-Host "`nRunning dotnet run..." -ForegroundColor Cyan
    dotnet run --project $projectDir
}
