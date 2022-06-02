using System;

namespace CaseExtensions
{
    public static partial class StringExtensions
    {
        public static string ToCamelCase(this string source)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            return SymbolsPipe(
                source,
                '\0',
                (s, disableFrontDelimiter) =>
                {
                    if (disableFrontDelimiter)
                    {
                        return new char[] { char.ToLowerInvariant(s) };
                    }

                    return new char[] { char.ToUpperInvariant(s) };
                }, s => { return new char[] {char.ToLowerInvariant(s)}; });
        }
    }
}
