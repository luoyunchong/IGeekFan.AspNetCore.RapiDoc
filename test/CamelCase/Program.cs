using System;
using System.Linq;
using System.Text;

namespace CamelCase
{
    class Program
    {
        private static readonly char[] Delimeters = { ' ', '-', '_' };

        private static string SymbolsPipe(
          string source,
          char mainDelimeter,
          Func<char, bool, char[]> newWordSymbolHandler)
        {
            var builder = new StringBuilder();

            bool nextSymbolStartsNewWord = true;
            bool disableFrontDelimeter = true;
            foreach (var symbol in source)
            {
                if (Delimeters.Contains(symbol))
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

        public static string ToPascalCase( string source)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            return SymbolsPipe(
                source,
                '\0',
                (s, i) => new char[] { char.ToUpperInvariant(s) });
        }

        static void Main(string[] args)
        {
            string[] list = new string[] {
                "spec-url",
                "sort-tags",
                "sort-endpoints-by",
                "heading-text	",
                "goto-path",
                "fill-request-fields-with-example",
                "theme",
                "bg-color",
                "text-color",
                "header-color",
                "primary-color	",
                "load-fonts	",
                "regular-font",
                "mono-font",
                "font-size",
                "use-path-in-nav-bar",
                "nav-bg-color",
                "nav-bg-image",
                "nav-bg-image-size",
                "nav-bg-image-repeat	",
                "nav-text-color",
                "nav-hover-bg-color",
                "nav-hover-text-color",
                "nav-accent-color",
                "nav-item-spacing	",
                "layout	",
                "render-style",
                "on-nav-tag-click",
                "schema-style	",
                "schema-expand-level",
                "schema-description-expanded",
                "schema-hide-read-only",
                "schema-hide-write-only	",
                "default-schema-tab	",
                "response-area-height	",
                "show-info	",
                "info-description-headings-in-navbar",
                "show-components",
                "show-header",
                "allow-authentication",
                "allow-spec-url-load",
                "allow-spec-file-load",
                "allow-search",
                "allow-advanced-search",
                "allow-try	",
                "allow-server-selection",
                "allow-schema-description-expand-toggle",
                "server-url",
                "default-api-server	",
                "api-key-name",
                "api-key-location",
                "api-key-value",
                "fetch-credentials	",
            };

            foreach (var item in list)
            {
                string m=ToPascalCase(item).Trim();
                Console.WriteLine(m);
            }

        }
    }
}
