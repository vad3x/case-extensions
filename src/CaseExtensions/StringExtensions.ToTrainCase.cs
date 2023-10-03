using System;

namespace CaseExtensions;

public static partial class StringExtensions
{
    private static readonly Func<char, bool, char[]> ToTrainCaseNewWordSymbolHandler = (
        s,
        disableFrontDelimiter
    ) =>
        disableFrontDelimiter
            ? [char.ToUpperInvariant(s),]
            : ['-', char.ToUpperInvariant(s)];

    public static string ToTrainCase(this string source)
    {
        if (source == null)
        {
            throw new ArgumentNullException(nameof(source));
        }

        return SymbolsPipe(source, '-', ToTrainCaseNewWordSymbolHandler);
    }
}