using System;

namespace CaseExtensions;

public static partial class StringExtensions
{
    private static readonly Func<char, bool, char[]> ToCamelCaseNewWordSymbolHandler = (
        s,
        disableFrontDelimiter
    ) =>
        disableFrontDelimiter
            ? [char.ToLowerInvariant(s),]
            : [char.ToUpperInvariant(s)];

    public static string ToCamelCase(this string source)
    {
        if (source == null)
        {
            throw new ArgumentNullException(nameof(source));
        }

        return SymbolsPipe(source, '\0', ToCamelCaseNewWordSymbolHandler);
    }
}