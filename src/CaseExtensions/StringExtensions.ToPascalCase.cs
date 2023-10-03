using System;

namespace CaseExtensions;

public static partial class StringExtensions
{
    private static readonly Func<char, bool, char[]> ToPascalCaseNewWordSymbolHandler = (s, _) =>
        [char.ToUpperInvariant(s)];

    public static string ToPascalCase(this string source)
    {
        if (source == null)
        {
            throw new ArgumentNullException(nameof(source));
        }

        return SymbolsPipe(source, '\0', ToPascalCaseNewWordSymbolHandler);
    }
}