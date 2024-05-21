using System;
using System.Collections.Generic;
using System.Linq;

namespace MyUtils
{
    public static class Csv
    {
        /// <summary>
        ///     解析逗号分隔的CSV字符串 并且去掉字符串两边的引号 例如 "a","b","c" 解析为 a, b, c
        ///     字符串中的引号可以用""表示一个引号 例如 "a""b","c" 解析为 a"b, c
        /// </summary>
        public static IReadOnlyList<string> ParseIgnoreQuotation(string csv)
        {
            return Parse(csv)
                  .Select(s =>
                   {
                       if (string.IsNullOrWhiteSpace(s))
                       {
                           return s;
                       }
                       else
                       {
                           char firstChar = s[0];
                           char lastChar = s[^1];
                           if (firstChar == '"' && lastChar == '"')
                           {
                               if (s.Length <= 2)
                               {
                                   return string.Empty;
                               }
                               else
                               {
                                   return s[1..^1];
                               }
                           }
                           else
                           {
                               return s;
                           }
                       }
                   })
                  .ToArray();
        }

        /// <summary>
        ///     仅解析逗号分隔的CSV字符串 但是不去掉字符串两边的引号 例如 "a","b","c" 解析为 "a", "b", "c"
        ///     字符串中的引号可以用""表示一个引号 例如 "a""b","c" 解析为 "a"b", "c"
        /// </summary>
        public static IReadOnlyList<string> Parse(string csv)
        {
            char[] charArray = csv.ToCharArray();
            List<int> quotationIndexes = new();
            List<int> commaIndexes = new();
            for (int i = 0; i < charArray.Length; i++)
            {
                if (charArray[i] == '"')
                {
                    quotationIndexes.Add(i);
                }
                else if (charArray[i] == ',')
                {
                    commaIndexes.Add(i);
                }
            }

            if (quotationIndexes.Count % 2 != 0)
            {
                throw new Exception("Invalid CSV format");
            }

            if (commaIndexes.Count <= 0)
            {
                return new[] { csv, };
            }

            List<string> result = new();
            int beginIndex = 0;
            int quotationIndex = 0;
            bool isInnerString = false;
            string subString;
            for (int i = 0; i < commaIndexes.Count; i++)
            {
                int commaIndex = commaIndexes[i];
                while (quotationIndex < quotationIndexes.Count && quotationIndexes[quotationIndex] < commaIndex)
                {
                    bool isDoubleQuotation = quotationIndex + 1 < quotationIndexes.Count
                        ? quotationIndexes[quotationIndex] == quotationIndexes[quotationIndex + 1]
                        : false;
                    if (isDoubleQuotation)
                    {
                        quotationIndex += 2;
                    }
                    else
                    {
                        isInnerString = !isInnerString;
                        quotationIndex += 1;
                    }
                }

                if (!isInnerString)
                {
                    subString = new string(charArray, beginIndex, commaIndex - beginIndex)
                               .Replace(@"""""", @"""")
                               .Trim();
                    result.Add(subString);
                    beginIndex = commaIndex + 1;
                }
            }

            subString = new string(charArray, beginIndex, charArray.Length - beginIndex)
                       .Replace(@"""""", @"""")
                       .Trim();
            result.Add(subString);
            return result;
        }
    }
}