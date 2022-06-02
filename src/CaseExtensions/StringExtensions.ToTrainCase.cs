using System;

namespace CaseExtensions
{
    public static partial class StringExtensions
    {
        public static string ToTrainCase(this string source)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            return SymbolsPipe(
                source,
                '-',
                (s, disableFrontDelimiter) =>
                {
                    if (disableFrontDelimiter)
                    {
                        return new char[] { char.ToUpperInvariant(s) };
                    }

                    return new char[] { '-', char.ToUpperInvariant(s) };
                }, s => { return new char[] {char.ToLowerInvariant(s)}; });
        }
    }
}
