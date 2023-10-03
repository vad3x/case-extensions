using System;

namespace CaseExtensions;

public static partial class StringExtensions
{
    private static readonly Func<char, bool, char[]> ToKebabCaseNewWordSymbolHandler = (
        s,
        disableFrontDelimiter
    ) =>
        disableFrontDelimiter
            ? [char.ToLowerInvariant(s),]
            : ['-', char.ToLowerInvariant(s)];

    public static string ToKebabCase(this string source)
    {
        if (source == null)
        {
            throw new ArgumentNullException(nameof(source));
        }

        return SymbolsPipe(source, '-', ToKebabCaseNewWordSymbolHandler);
    }
}