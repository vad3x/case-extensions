using System;

namespace CaseExtensions
{
    public static partial class StringExtensions
    {
        public static string ToSnakeCase(this string source)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            return SymbolsPipe(
                source,
                '_',
                (s, disableFrontDelimiter) =>
                {
                    if (disableFrontDelimiter)
                    {
                        return new char[] { char.ToLowerInvariant(s) };
                    }

                    return new char[] { '_', char.ToLowerInvariant(s) };
                }, s => { return new char[] {char.ToLowerInvariant(s)}; });
        }
    }
}
