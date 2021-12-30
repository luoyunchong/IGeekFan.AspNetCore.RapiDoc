using System;
using System.Linq;
using System.Text;

namespace GetRapidoc
{
    public class APIDto
    {
        public string Name { get; set; }
        public string Desc { get; set; }
        public string DefaultVal { get; set; }

        public string NamePascalize => ToPascalCase(Name);

        public string DefaultValFormat
        {
            get
            {
              
                if (DefaultVal == "#")
                {
                    return $"";
                }
                if (DefaultVal == "(empty)")
                {
                    return $" = \"\";";
                }

                if (!string.IsNullOrEmpty(DefaultVal))
                {
                    if (Type == "bool")
                    {
                        return $" = {DefaultVal};";
                    }
                
                    // 处理默认值
                    if(DefaultVal.StartsWith("Dark Theme") || DefaultVal.Contains("#"))
                    {
                        return $" = \"\";";
                    }
                    if (DefaultVal.Contains("\""))
                    {
                        return $" = @\"{DefaultVal.Replace("\"","\"\"")}\";";
                    }
                    if (Type == "string")
                    {
                        return $" = \"{DefaultVal}\";";
                    }
                }
            
           
                return $"";
            }
        }
        public string Type
        {
            get
            {
                if (DefaultVal == "(empty)")
                {
                    return "string";
                }
                switch (DefaultVal)
                {
                    case "false":
                    case "true": return "bool";
                    case "(empty)": return "string";
                    default:
                        break;
                }
                return "string";

            }
        }

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

        public static string ToPascalCase(string source)
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
    }
}
