using System;

namespace CaseExtensions;

/// <inheritdoc cref="StringExtensions" />
public static partial class StringExtensions
{
    /// <summary>
    /// A <see cref="Func{T1, T2, TResult}" /> that handles new word symbols when converting a <see cref="string" /> to pascal case.
    /// </summary>
    private static readonly Func<char, bool, char[]> ToPascalCaseNewWordSymbolHandler = (s, _) =>
        [char.ToUpperInvariant(s)];

    /// <summary>
    /// Converts the specified <see cref="string" /> to pascal case.
    /// </summary>
    /// <param name="source">The <see cref="string" /> to convert.</param>
    /// <returns>The pascal case representation of the specified <see cref="string" />.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="source" /> is <c>null</c>.</exception>
    /// <example>
    /// <code>
    /// using CaseExtensions;
    ///
    /// "The Quick Brown Fox".ToPascalCase() == "TheQuickBrownFox"
    /// "the_quick_brown_fox".ToPascalCase() == "TheQuickBrownFox"
    /// "the-quick-brown-fox".ToPascalCase() == "TheQuickBrownFox"
    /// "The-Quick-Brown-Fox".ToPascalCase() == "TheQuickBrownFox"
    /// "theQuickBrownFox".ToPascalCase() == "TheQuickBrownFox"
    /// "TheQuickBrownFox".ToPascalCase() == "TheQuickBrownFox"
    /// </code>
    /// </example>
    public static string ToPascalCase(this string source)
    {
        if (source == null)
        {
            throw new ArgumentNullException(nameof(source));
        }

        return SymbolsPipe(source, '\0', ToPascalCaseNewWordSymbolHandler);
    }
}