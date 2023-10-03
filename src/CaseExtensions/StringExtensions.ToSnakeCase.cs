using System;

namespace CaseExtensions;

/// <inheritdoc cref="StringExtensions" />
public static partial class StringExtensions
{
    /// <summary>
    /// A <see cref="Func{T1, T2, TResult}" /> that handles new word symbols when converting a <see cref="string" /> to snake case.
    /// </summary>
    private static readonly Func<char, bool, char[]> ToSnakeCaseNewWordSymbolHandler = (
        s,
        disableFrontDelimiter
    ) =>
        disableFrontDelimiter
            ? [char.ToLowerInvariant(s),]
            : ['_', char.ToLowerInvariant(s)];

    /// <summary>
    /// Converts the specified <see cref="string" /> to snake case.
    /// </summary>
    /// <param name="source">The <see cref="string" /> to convert.</param>
    /// <returns>The snake case representation of the specified <see cref="string" />.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="source" /> is <c>null</c>.</exception>
    /// <example>
    /// <code>
    /// using CaseExtensions;
    ///
    /// "The Quick Brown Fox".ToSnakeCase() == "the_quick_brown_fox"
    /// "the_quick_brown_fox".ToSnakeCase() == "the_quick_brown_fox"
    /// "the-quick-brown-fox".ToSnakeCase() == "the_quick_brown_fox"
    /// "The-Quick-Brown-Fox".ToSnakeCase() == "the_quick_brown_fox"
    /// "theQuickBrownFox".ToSnakeCase() == "the_quick_brown_fox"
    /// "TheQuickBrownFox".ToSnakeCase() == "the_quick_brown_fox"
    /// </code>
    /// </example>
    public static string ToSnakeCase(this string source)
    {
        if (source == null)
        {
            throw new ArgumentNullException(nameof(source));
        }

        return SymbolsPipe(source, '_', ToSnakeCaseNewWordSymbolHandler);
    }
}