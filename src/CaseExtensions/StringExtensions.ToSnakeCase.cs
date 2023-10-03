using System;

namespace CaseExtensions;

public static partial class StringExtensions
{
    private static readonly Func<char, bool, char[]> ToSnakeCaseNewWordSymbolHandler = (
        s,
        disableFrontDelimiter
    ) =>
        disableFrontDelimiter
            ? [char.ToLowerInvariant(s),]
            : ['_', char.ToLowerInvariant(s)];

    public static string ToSnakeCase(this string source)
    {
        if (source == null)
        {
            throw new ArgumentNullException(nameof(source));
        }

        return SymbolsPipe(source, '_', ToSnakeCaseNewWordSymbolHandler);
    }
}