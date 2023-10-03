using System;

namespace CaseExtensions;

/// <inheritdoc cref="StringExtensions" />
public static partial class StringExtensions
{
    /// <summary>
    /// A <see cref="Func{T1, T2, TResult}" /> that handles new word symbols when converting a <see cref="string" /> to kebab case.
    /// </summary>
    private static readonly Func<char, bool, char[]> ToKebabCaseNewWordSymbolHandler = (
        s,
        disableFrontDelimiter
    ) =>
        disableFrontDelimiter
            ? [char.ToLowerInvariant(s),]
            : ['-', char.ToLowerInvariant(s)];

    /// <summary>
    /// Converts the specified <see cref="string" /> to kebab case.
    /// </summary>
    /// <param name="source">The <see cref="string" /> to convert.</param>
    /// <returns>The kebab case representation of the specified <see cref="string" />.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="source" /> is <c>null</c>.</exception>
    /// <example>
    /// <code>
    /// using CaseExtensions;
    ///
    /// "The Quick Brown Fox".ToKebabCase() == "the-quick-brown-fox"
    /// "the_quick_brown_fox".ToKebabCase() == "the-quick-brown-fox"
    /// "the-quick-brown-fox".ToKebabCase() == "the-quick-brown-fox"
    /// "The-Quick-Brown-Fox".ToKebabCase() == "the-quick-brown-fox"
    /// "theQuickBrownFox".ToKebabCase() == "the-quick-brown-fox"
    /// "TheQuickBrownFox".ToKebabCase() == "the-quick-brown-fox"
    /// </code>
    /// </example>
    public static string ToKebabCase(this string source)
    {
        if (source == null)
        {
            throw new ArgumentNullException(nameof(source));
        }

        return SymbolsPipe(source, '-', ToKebabCaseNewWordSymbolHandler);
    }
}