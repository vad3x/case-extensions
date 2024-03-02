using System;
using System.Linq;
using System.Text;

namespace CaseExtensions;

/// <summary>
/// Provides extension methods for <see cref="string" /> objects.
/// </summary>
public static partial class StringExtensions
{
    /// <summary>
    /// The delimiters used to split a <see cref="string" /> into words.
    /// </summary>
    private static readonly char[] Delimiters = [' ', '-', '_'];

    /// <summary>
    /// Converts a <see cref="string" /> to a new <see cref="string" /> with the specified <paramref name="mainDelimiter" /> and <paramref name="newWordSymbolHandler" /> <see cref="Func{T1, T2, TResult}" />.
    /// </summary>
    /// <param name="source">The string to convert.</param>
    /// <param name="mainDelimiter">The main delimiter to use.</param>
    /// <param name="newWordSymbolHandler">The function to handle new word symbols.</param>
    /// <returns>A new <see cref="string" /> built using the specified <paramref name="mainDelimiter" /> and <paramref name="newWordSymbolHandler" />.</returns>
    private static string SymbolsPipe(
        string source,
        char mainDelimeter,
        Func<char, bool, char[]> newWordSymbolHandler
    )
    {
        var builder = new StringBuilder();

        var nextSymbolStartsNewWord = true;
        var disableFrontDelimeter = true;
        for (var i = 0; i < source.Length; i++)
        {
            var symbol = source[i];
            if (Delimiters.Contains(symbol))
            {
                if (symbol == mainDelimeter)
                {
                    builder.Append(symbol);
                    disableFrontDelimeter = true;
                }

                nextSymbolStartsNewWord = true;
            }
            else if (!char.IsLetterOrDigit(symbol))
            {
                builder.Append(symbol);
                disableFrontDelimeter = true;
                nextSymbolStartsNewWord = true;
            }
            else
            {
                if (nextSymbolStartsNewWord || char.IsUpper(symbol))
                {
                    builder.Append(newWordSymbolHandler(symbol, disableFrontDelimeter));
                    disableFrontDelimeter = false;
                    nextSymbolStartsNewWord = false;
                }
                else
                {
                    builder.Append(symbol);
                }
            }
        }

        return builder.ToString();
    }
}