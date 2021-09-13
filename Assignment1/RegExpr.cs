using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Assignment1
{
    public static class RegExpr
    {
        private static Regex _wordExpression = new Regex(@"[a-zA-Z0-9]+");
        private static Regex _resolutionExpression = new Regex(@"(?<width>[0-9]{1,4})x(?<height>[0-9]{1,4})");
        public static IEnumerable<string> SplitLine(IEnumerable<string> lines)
        {
            foreach (var line in lines) {
                foreach (Match match in _wordExpression.Matches(line)) {
                    yield return match.Value;
                }
            }
        }

        public static IEnumerable<(int width, int height)> Resolution(IEnumerable<string> lines)
        {
            foreach (var line in lines) {
                foreach (Match match in _resolutionExpression.Matches(line)) {
                    yield return (
                        int.Parse(match.Groups["width"].ToString()), 
                        int.Parse(match.Groups["height"].ToString())
                        );
                }
            }
            
        }

        public static IEnumerable<string> InnerText(string html, string tag)
        {
            var re = new Regex($"<(?<tag>{tag}).*?>(?<inner>.+?)<\\/\\k<tag>>");
            foreach (Match match in re.Matches(html)) {
                var rawInner = match.Groups["inner"].Value;
                yield return Regex.Replace(rawInner, @"<(?<tag>\w+) ?.*?>(?<inner>.+?)<\/\k<tag>>", @"${inner}");
            }
        }
    }
}
