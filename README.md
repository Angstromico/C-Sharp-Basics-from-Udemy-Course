# First Steps

This project is a beginner-friendly C# console application created as part of the introductory section of the course "Master C# Programming from A to Z. Dive deep into .NET, OOP, Clean Code, LINQ, WPF, Generics, Unit Testing, and more" by Denis Panjuta on Udemy.

## Project Overview

This repository represents the first steps in learning C# programming. The application is intentionally simple and demonstrates:

- Basic C# syntax
- Console output using `Console.WriteLine()`
- Pausing the console using `Console.ReadKey()`
- A minimal .NET project setup

## Current Program

The current `Program.cs` file contains a classic introductory example:

```csharp
Console.WriteLine("Hello, World!");
Console.ReadKey();
```

This prints `Hello, World!` to the console and waits for a key press before closing the window.

## Project Structure

- `First Steps/Program.cs` - Main application code
- `First Steps/First Steps.csproj` - .NET project file
- `First Steps.slnx` - Solution file
- `Select-Feature.ps1` - PowerShell utility to toggle and isolate feature tests in `Program.cs`

## Requirements

To run this project, you need:

- .NET SDK 10.0 or later
- A terminal or IDE such as Visual Studio Code, Visual Studio, or JetBrains Rider

## How to Run

From the project root, run:

```bash
dotnet run --project "First Steps/First Steps.csproj"
```

## Feature Testing Automation (PowerShell)

As you add new topic files (e.g., `Calculator.cs`, `JaggedArrays.cs`), each topic has a corresponding `.Run()` call in `Program.cs`.

To easily isolate and test one specific topic without running all previous exercises, use the included [`Select-Feature.ps1`](./Select-Feature.ps1) script:

### 1. Test a single feature (comments out all others)
Pass the name (or partial name) of the feature class:

```powershell
.\Select-Feature.ps1 Calculator
```

All other `.Run()` lines in `Program.cs` will be commented out, leaving only `Calculator.Run();` enabled.

### 2. Select and run immediately
Use the `-Run` switch to update `Program.cs` and launch `dotnet run` in one step:

```powershell
.\Select-Feature.ps1 JaggedArrays -Run
```

### 3. Uncomment all features
Run the script without arguments (or with `all`) to restore and uncomment every `.Run()` call:

```powershell
.\Select-Feature.ps1
```

### 4. List all available features and their status
Check which features are currently enabled `[x]` or commented out `[ ]`:

```powershell
.\Select-Feature.ps1 -List
```

## Learning Notes

This is an introduction to C# and is meant to help build a foundation before moving on to more advanced topics such as:

- Object-Oriented Programming (OOP)
- Clean Code principles
- LINQ
- WPF
- Generics
- Unit Testing
- .NET development best practices

## Author

This project was created while following the course by Denis Panjuta.
