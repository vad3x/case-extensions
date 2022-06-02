using System;
using System.Linq;
using System.Text;

namespace CaseExtensions
{
    public static partial class StringExtensions
    {
        private static readonly char[] Delimiters = { ' ', '-', '_' };

        private static string SymbolsPipe(
            string source,
            char mainDelimiter,
            Func<char, bool, char[]> newWordSymbolHandler,
            Func<char, char[]> middleWordSymbolHandler)
        {
            var builder = new StringBuilder();

            bool nextAlphaNumericSymbolStartsNewWord = true;
            bool disableFrontDelimiter = true;
            var stringHasLowerCase = source.Any(char.IsLower);
            for (var i = 0; i < source.Length; i++)
            {
                var symbol = source[i];
                if (Delimiters.Contains(symbol))
                {
                    if (symbol == mainDelimiter)
                    {
                        builder.Append(symbol);
                        disableFrontDelimiter = true;
                    }

                    nextAlphaNumericSymbolStartsNewWord = true;
                }
                else if (!char.IsLetterOrDigit(symbol))
                {
                    builder.Append(symbol);
                    disableFrontDelimiter = true;
                    nextAlphaNumericSymbolStartsNewWord = true;
                }
                else
                {
                    var symbolIsUppercase = char.IsUpper(symbol);
                    if (!nextAlphaNumericSymbolStartsNewWord && symbolIsUppercase && stringHasLowerCase)
                        nextAlphaNumericSymbolStartsNewWord = true;
                    if (nextAlphaNumericSymbolStartsNewWord)
                    {
                        var charsToAppend = newWordSymbolHandler(symbol, disableFrontDelimiter);
                        builder.Append(charsToAppend);
                        disableFrontDelimiter = false;
                        nextAlphaNumericSymbolStartsNewWord = false;
                    }
                    else
                    {
                        var charsToAppend = middleWordSymbolHandler(symbol);
                        builder.Append(charsToAppend);
                    }
                }
            }

            return builder.ToString();
        }
    }
}
