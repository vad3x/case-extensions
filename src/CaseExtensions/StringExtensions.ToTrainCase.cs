using System;

namespace CaseExtensions;

/// <inheritdoc cref="StringExtensions" />
public static partial class StringExtensions
{
    /// <summary>
    /// A <see cref="Func{T1, T2, TResult}" /> that handles new word symbols when converting a <see cref="string" /> to train case.
    /// </summary>
    private static readonly Func<char, bool, char[]> ToTrainCaseNewWordSymbolHandler = (
        s,
        disableFrontDelimiter
    ) =>
        disableFrontDelimiter
            ? [char.ToUpperInvariant(s),]
            : ['-', char.ToUpperInvariant(s)];

    /// <summary>
    /// Converts the specified <see cref="string" /> to train case.
    /// </summary>
    /// <param name="source">The <see cref="string" /> to convert.</param>
    /// <returns>The train case representation of the specified <see cref="string" />.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="source" /> is <c>null</c>.</exception>
    /// <example>
    /// <code>
    /// using CaseExtensions;
    ///
    /// "The Quick Brown Fox".ToTrainCase() == "The-Quick-Brown-Fox"
    /// "the_quick_brown_fox".ToTrainCase() == "The-Quick-Brown-Fox"
    /// "the-quick-brown-fox".ToTrainCase() == "The-Quick-Brown-Fox"
    /// "The-Quick-Brown-Fox".ToTrainCase() == "The-Quick-Brown-Fox"
    /// "theQuickBrownFox".ToTrainCase() == "The-Quick-Brown-Fox"
    /// "TheQuickBrownFox".ToTrainCase() == "The-Quick-Brown-Fox"
    /// </code>
    /// </example>
    public static string ToTrainCase(this string source)
    {
        if (source == null)
        {
            throw new ArgumentNullException(nameof(source));
        }

        return SymbolsPipe(source, '-', ToTrainCaseNewWordSymbolHandler);
    }
}