using Nancy.TwitterBootstrap.Models;
using Xunit;

namespace Nancy.TwitterBootstrap.Tests
{
    public class HtmlAttributesFixture
    {
        [Fact]
        public void Should_Convert_Object_To_Attribute_String()
        {
            var sut = new HtmlAttributes(new
            {
                name = "hello",
                id = "world"
            });

            Assert.Equal(@" id=""world"" name=""hello""", sut.ToString());
        }

        [Fact]
        public void Should_Convert_Underscore_To_Hyphen_In_Attribute_Name()
        {
            var sut = new HtmlAttributes(new
            {
                an_attribute = "asdf"
            });

            Assert.Equal(@" an-attribute=""asdf""", sut.ToString());
        }

        [Fact]
        public void Should_Convert_Attribute_Names_To_Lower_Case()
        {
            var sut = new HtmlAttributes(new
            {
                AnAttribute = "asdf"
            });

            Assert.Equal(@" anattribute=""asdf""", sut.ToString());
        }

        [Fact]
        public void Should_Use_Valueless_Attribute_For_Boolean_True()
        {
            var sut = new HtmlAttributes(new
            {
                Disabled = true
            });

            Assert.Equal(@" disabled", sut.ToString());
        }

        [Fact]
        public void Should_Omit_Attribute_For_Boolean_False()
        {
            var sut = new HtmlAttributes(new
            {
                Disabled = false
            });

            Assert.Equal(@"", sut.ToString());
        }
        
        [Fact]
        public void Should_Merge_Attribte_Values()
        {
            var a = new HtmlAttributes(new
            {
                @class = "a b"
            });

            var b = new HtmlAttributes(new
            {
                @class = "c d"
            });

            Assert.Equal(@" class=""a b c d""", a.Merge(b).ToString());
        }

        [Fact]
        public void Should_Sort_Attribute_Names()
        {
            Assert.Equal(@" id=""a"" class=""c"" name=""b""", new HtmlAttributes(new
            {
                Name = "b",
                @class = "c",
                Id = "a"
            }).ToString());
        }
    }
}