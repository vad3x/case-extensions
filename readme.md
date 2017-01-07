# .NET CaseExtensions

The library that allows to change any string case to `PascalCase`/`camelCase`/`kebab-case`/`snake_case`.

# Usage

```csharp
using CaseExtensions;

    ...

    var source = "The string to Convert";
    var result = source.ToKebabCase(); // the-string-to-convert
```

# Tests

To run tests:

```sh
dotnet test test/CaseExtensions.Tests/project.json
```

# License

The MIT License (MIT)
