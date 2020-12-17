# .NET CaseExtensions

[![codecov](https://codecov.io/gh/vad3x/case-extensions/branch/master/graph/badge.svg?token=XaDyFQOpKn)](https://codecov.io/gh/vad3x/case-extensions)

The library that allows to change any string case to `PascalCase`/`camelCase`/`kebab-case`/`snake_case`/`Train-Case`.

# Usage

```csharp
using CaseExtensions;

    ...

    var source = "The Quick Brown Fox";
    var result = source.ToKebabCase(); // the-quick-brown-fox
```

# More Examples

Inter-style case translations are supported just like translations from plain English.

Here are a few demo expressions. Each of these expression evaluates to `true`.

```csharp
// from plain English
"The Quick Brown Fox".ToCamelCase() == "theQuickBrownFox"
"The Quick Brown Fox".ToKebabCase() == "the-quick-brown-fox"
"The Quick Brown Fox".ToPascalCase() == "TheQuickBrownFox"
"The Quick Brown Fox".ToSnakeCase() == "the_quick_brown_fox"
"The Quick Brown Fox".ToTrainCase() == "The-Quick-Brown-Fox"

// from camelCase
"theQuickBrownFox".ToCamelCase() == "theQuickBrownFox"
"theQuickBrownFox".ToKebabCase() == "the-quick-brown-fox"
"theQuickBrownFox".ToPascalCase() == "TheQuickBrownFox"
"theQuickBrownFox".ToSnakeCase() == "the_quick_brown_fox"
"theQuickBrownFox".ToTrainCase() == "The-Quick-Brown-Fox"

// from kebab-case
"the-quick-brown-fox".ToCamelCase() == "theQuickBrownFox"
"the-quick-brown-fox".ToKebabCase() == "the-quick-brown-fox"
"the-quick-brown-fox".ToPascalCase() == "TheQuickBrownFox"
"the-quick-brown-fox".ToSnakeCase() == "the_quick_brown_fox"
"the-quick-brown-fox".ToTrainCase() == "The-Quick-Brown-Fox"

// from PascalCase
"TheQuickBrownFox".ToCamelCase() == "theQuickBrownFox"
"TheQuickBrownFox".ToKebabCase() == "the-quick-brown-fox"
"TheQuickBrownFox".ToPascalCase() == "TheQuickBrownFox"
"TheQuickBrownFox".ToSnakeCase() == "the_quick_brown_fox"
"TheQuickBrownFox".ToTrainCase() == "The-Quick-Brown-Fox"

// from snake_case
"the_quick_brown_fox".ToCamelCase() == "theQuickBrownFox"
"the_quick_brown_fox".ToKebabCase() == "the-quick-brown-fox"
"the_quick_brown_fox".ToPascalCase() == "TheQuickBrownFox"
"the_quick_brown_fox".ToSnakeCase() == "the_quick_brown_fox"
"the_quick_brown_fox".ToTrainCase() == "The-Quick-Brown-Fox"

// from Train-Case
"The-Quick-Brown-Fox".ToCamelCase() == "theQuickBrownFox"
"The-Quick-Brown-Fox".ToKebabCase() == "the-quick-brown-fox"
"The-Quick-Brown-Fox".ToPascalCase() == "TheQuickBrownFox"
"The-Quick-Brown-Fox".ToSnakeCase() == "the_quick_brown_fox"
"The-Quick-Brown-Fox".ToTrainCase() == "The-Quick-Brown-Fox"
```

# Tests

To run tests:

```sh
dotnet test test/CaseExtensions.Tests/project.json
```

# License

The MIT License (MIT)
