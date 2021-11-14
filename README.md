# Trend-Fox templates
## Installation
Install templates from NuGet:
```
dotnet new -i TrendFox.Templates
```
To uninstall, use the switch `-u` instead of `-i`.

## Usage
After installing, use the following command. Use the desired
template name.
```
dotnet new <name>
```

- `tfblank`
  
  Blank solution using `src` and `test` folders. The
  template includes a PowerShell script for code coverage.

- `tfconsole`
  
  Console application with dependency injection and configuration.
