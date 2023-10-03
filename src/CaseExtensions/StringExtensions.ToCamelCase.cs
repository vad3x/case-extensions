using System;

namespace CaseExtensions;

/// <inheritdoc cref="StringExtensions" />
public static partial class StringExtensions
{
    /// <summary>
    /// A <see cref="Func{T1, T2, TResult}" /> that handles new word symbols when converting a <see cref="string" /> to camel case.
    /// </summary>
    private static readonly Func<char, bool, char[]> ToCamelCaseNewWordSymbolHandler = (
        s,
        disableFrontDelimiter
    ) =>
        disableFrontDelimiter
            ? [char.ToLowerInvariant(s),]
            : [char.ToUpperInvariant(s)];

    /// <summary>
    /// Converts the specified <see cref="string" /> to camel case.
    /// </summary>
    /// <param name="source">The <see cref="string" /> to convert.</param>
    /// <returns>The camel case representation of the specified <see cref="string" />.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="source" /> is <c>null</c>.</exception>
    /// <example>
    /// <code>
    /// using CaseExtensions;
    ///
    /// "The Quick Brown Fox".ToCamelCase() == "theQuickBrownFox"
    /// "the_quick_brown_fox".ToCamelCase() == "theQuickBrownFox"
    /// "the-quick-brown-fox".ToCamelCase() == "theQuickBrownFox"
    /// "The-Quick-Brown-Fox".ToCamelCase() == "theQuickBrownFox"
    /// "theQuickBrownFox".ToCamelCase() == "theQuickBrownFox"
    /// "TheQuickBrownFox".ToCamelCase() == "theQuickBrownFox"
    /// </code>
    /// </example>
    public static string ToCamelCase(this string source)
    {
        if (source == null)
        {
            throw new ArgumentNullException(nameof(source));
        }

        return SymbolsPipe(source, '\0', ToCamelCaseNewWordSymbolHandler);
    }
}