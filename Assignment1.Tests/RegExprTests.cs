using System;
using System.Collections.Generic;
using Xunit;

namespace Assignment1.Tests
{
    public class RegExprTests
    {
        [Fact]
        public void SplitLine_ReturnsNoElementsOnEmptyString() {
            var actual = RegExpr.SplitLine(new string[] {""});
            var expected = new string[0];
            Assert.Equal<IEnumerable<string>>(expected, actual);
        }

        [Fact]
        public void SplitLine_SplitsSingleLineCorrectly() {
            var input = new string[] {
                "This line contains five words."
            };
            var actual = RegExpr.SplitLine(input);
            var expected = new string[] {
                "This",
                "line",
                "contains",
                "five",
                "words",
            };
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SplitLine_SplitsMultipleLinesCorrectly() {
            var input = new string[] {
                "This first line contains five words.",
                "This next sentence spans two lines, this being the first,",
                " and this being the second.",
            };
            var actual = RegExpr.SplitLine(input);
            var expected = new string[] {
                "This", "first", "line", "contains", "five", "words",
                "This", "next", "sentence", "spans", "two", "lines", "this", "being", "the", "first",
                "and", "this", "being", "the", "second",
            };
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Resolution_ReturnsNoElementsOnEmptyString() {
            var actual = RegExpr.Resolution(new string[] {""});
            var expected = new (int, int)[0];
            Assert.Equal<IEnumerable<(int width, int height)>>(expected, actual);

        }

        [Fact]
        public void Resolution_IsCorrectForGivenInput() {
            var input = new string[] {
                "1920x1080",
                "1024x768, 800x600, 640x480",
                "320x200, 320x240, 800x600", 
                "1280x960",
            };
            var actual = RegExpr.Resolution(input);
            var expected = new (int, int)[] {
                (1920, 1080),
                (1024, 768),
                (800, 600),
                (640, 480),
                (320, 200),
                (320, 240),
                (800, 600),
                (1280, 960),
            };
            Assert.Equal<IEnumerable<(int width, int height)>>(expected, actual);

        }

        [Fact]
        public void InnerText_ReturnsNoElementsOnEmptyString() {
            var actual = RegExpr.InnerText("", "a");
            var expected = new string[0];
            Assert.Equal<IEnumerable<string>>(expected, actual);

        }

        [Fact]
        public void InnerText_IsCorrectForNonNestedInput() {
            var input = @"
            <div>
                <p>A <b>regular expression</b>, <b>regex</b> or <b>regexp</b> (sometimes called a <b>rational expression</b>) is, in <a href=""/wiki/Theoretical_computer_science"" title=""Theoretical computer science"">theoretical computer science</a> and <a href=""/wiki/Formal_language"" title=""Formal language"">formal language</a> theory, a sequence of <a href=""/wiki/Character_(computing)"" title=""Character (computing)"">characters</a> that define a <i>search <a href=""/wiki/Pattern_matching"" title=""Pattern matching"">pattern</a></i>. Usually this pattern is then used by <a href=""/wiki/String_searching_algorithm"" title=""String searching algorithm"">string searching algorithms</a> for ""find"" or ""find and replace"" operations on <a href=""/wiki/String_(computer_science)"" title=""String (computer science)"">strings</a>.</p>
            </div>
            ";
            var actual = RegExpr.InnerText(input, "a");
            var expected = new string[] {
                "theoretical computer science",
                "formal language",
                "characters",
                "pattern",
                "string searching algorithms",
                "strings",
            };
            Assert.Equal<IEnumerable<string>>(expected, actual);

        }

        [Fact]
        public void InnerText_IsCorrectForNestedInput() {
            var input = @"
            <div>
                <p>The phrase <i>regular expressions</i> (and consequently, regexes) is often used to mean the specific, standard textual syntax for representing <u>patterns</u> that matching <em>text</em> need to conform to.</p>
            </div>
            ";
            var actual = RegExpr.InnerText(input, "p");
            var counter = 0;
            foreach (var item in actual) {
                counter++;
                Console.WriteLine(item);
            }
            Console.WriteLine(counter);
            var expected = new string[] {
                "The phrase regular expressions (and consequently, regexes) is often used to mean the specific, standard textual syntax for representing patterns that matching text need to conform to."
            };
            Assert.Equal<IEnumerable<string>>(expected, actual);

        }
    }
}
