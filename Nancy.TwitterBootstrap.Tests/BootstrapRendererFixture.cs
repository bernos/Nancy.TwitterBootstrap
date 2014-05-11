using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nancy.TwitterBootstrap.Models;
using Xunit;

namespace Nancy.TwitterBootstrap.Tests
{
    public static class StringExtensions
    {
        public static string Clean(this string input)
        {
            return input.Replace("\r", "").Replace("\n", "").Replace("\t", "").Replace("  ", "");
        }
    }

    public class BootstrapRendererFixture
    {
        protected readonly BootstrapRenderer _renderer;

        public BootstrapRendererFixture()
        {
            _renderer = new BootstrapRenderer(new BootstrapTemplates());    
        }

        protected void AssertMarkupEqual(string expected, string actual)
        {
            Assert.Equal(expected.Clean(), actual.Clean());
        }

        public class BeginFormGroupMethod : BootstrapRendererFixture
        {
            [Fact]
            public void Should_Render_Without_Custom_Attributes()
            {
                AssertMarkupEqual(@"<div class=""form-group"">", _renderer.BeginFormGroup());
            }

            [Fact]
            public void Should_Render_Custom_Attributes()
            {
                AssertMarkupEqual(@"<div id=""my-div"" class=""form-group pretty"">", _renderer.BeginFormGroup(new
                {
                    Id = "my-div",
                    @class= "pretty"
                }));
            }
        }

        public class EndFormGroupMethod :BootstrapRendererFixture
        {
            [Fact]
            public void Should_Render()
            {
                AssertMarkupEqual(@"</div>", _renderer.EndFormGroup());
            }
        }

        public class CheckboxMethod : BootstrapRendererFixture
        {
            [Fact]
            public void Should_Render_Without_Checked_Flag()
            {
                var expected = @"<div class=""checkbox"">
                                    <label>
                                        <input type=""checkbox"" name=""my-checkbox"" value=""1"" />
                                        Hello
                                    </label>
                                </div>";

                AssertMarkupEqual(expected, _renderer.Checkbox("my-checkbox", 1, "Hello"));
            }

            [Fact]
            public void Should_Render_With_Checked_Flag()
            {
                var expected = @"<div class=""checkbox"">
                                    <label>
                                        <input type=""checkbox"" name=""my-checkbox"" value=""1"" checked />
                                        Hello
                                    </label>
                                </div>";

                AssertMarkupEqual(expected, _renderer.Checkbox("my-checkbox", 1, "Hello", true));
            }

            [Fact]
            public void Should_Render_With_Custom_Attributes()
            {
                var expected = @"<div id=""my-checkbox"" class=""checkbox"">
                                    <label>
                                        <input type=""checkbox"" name=""my-checkbox"" value=""1"" />
                                        Hello
                                    </label>
                                </div>";

                AssertMarkupEqual(expected, _renderer.Checkbox("my-checkbox", 1, "Hello", false, new
                {
                    Id = "my-checkbox"
                }));
            }
        }

        public class CheckboxListMethod : BootstrapRendererFixture
        {
            private readonly IEnumerable<ListOption<int>> _options; 
            
            public CheckboxListMethod()
            {
                _options = new List<ListOption<int>>    
                {
                    new ListOption<int>("one", 1),
                    new ListOption<int>("two", 2),
                    new ListOption<int>("three", 3)
                };
            }

            [Fact]
            public void Should_Render_With_No_Selected_Options()
            {
                var expected = @"<div class=""checkbox"">
                                    <label>
                                        <input type=""checkbox"" name=""mycheckbox"" value=""1"" />
                                        one
                                    </label>
                                </div>
                                <div class=""checkbox"">
                                    <label>
                                        <input type=""checkbox"" name=""mycheckbox"" value=""2"" />
                                        two
                                    </label>
                                </div>
                                <div class=""checkbox"">
                                    <label>
                                        <input type=""checkbox"" name=""mycheckbox"" value=""3"" />
                                        three
                                    </label>
                                </div>";

                AssertMarkupEqual(expected, _renderer.CheckboxList("mycheckbox", _options));
            }

            [Fact]
            public void Should_Render_With_Selected_Options_Enumerable()
            {
                var expected = @"<div class=""checkbox"">
                                    <label>
                                        <input type=""checkbox"" name=""mycheckbox"" value=""1"" checked />
                                        one
                                    </label>
                                </div>
                                <div class=""checkbox"">
                                    <label>
                                        <input type=""checkbox"" name=""mycheckbox"" value=""2"" />
                                        two
                                    </label>
                                </div>
                                <div class=""checkbox"">
                                    <label>
                                        <input type=""checkbox"" name=""mycheckbox"" value=""3"" checked />
                                        three
                                    </label>
                                </div>";

                AssertMarkupEqual(expected, _renderer.CheckboxList("mycheckbox", _options, new List<int> { 1, 3 }));
            }

            [Fact]
            public void Should_Render_With_Selected_Options_Lambda()
            {
                var expected = @"<div class=""checkbox"">
                                    <label>
                                        <input type=""checkbox"" name=""mycheckbox"" value=""1"" />
                                        one
                                    </label>
                                </div>
                                <div class=""checkbox"">
                                    <label>
                                        <input type=""checkbox"" name=""mycheckbox"" value=""2"" checked />
                                        two
                                    </label>
                                </div>
                                <div class=""checkbox"">
                                    <label>
                                        <input type=""checkbox"" name=""mycheckbox"" value=""3"" checked />
                                        three
                                    </label>
                                </div>";

                AssertMarkupEqual(expected, _renderer.CheckboxList("mycheckbox", _options, o => o.Value != 1));
            }
        }

        public class EmailMethodFixture : BootstrapRendererFixture
        {
            [Fact]
            public void Should_Render()
            {
                var expected = @"<input type=""email"" name=""email-address"" value=""test@test.com"" />";

                AssertMarkupEqual(expected, _renderer.Email("email-address", "test@test.com"));
            }

            [Fact]
            public void Should_Render_With_Custom_Attributes()
            {
                var expected = @"<input type=""email"" name=""email-address"" value=""test@test.com"" id=""address"" class=""pretty"" />";

                var actual = _renderer.Email("email-address", "test@test.com", new
                {
                    Id = "address",
                    @class = "pretty"
                });

                AssertMarkupEqual(expected, actual);
            }
        }

        public class LabelMethodFixture : BootstrapRendererFixture
        {
            [Fact]
            public void Should_Render()
            {
                var expected = @"<label for=""my-input"">hello world</label>";

                AssertMarkupEqual(expected, _renderer.Label("hello world", "my-input"));
            }

            [Fact]
            public void Should_Omit_For_Attribute_If_Empty()
            {
                var expected = @"<label>hello world</label>";

                AssertMarkupEqual(expected, _renderer.Label("hello world"));
            }

            [Fact]
            public void Should_Render_With_CustomAttributes()
            {
                var expected = @"<label id=""my-label"" class=""label"" for=""my-input"">hello world</label>";

                AssertMarkupEqual(expected, _renderer.Label("hello world", "my-input", new
                {
                    Id = "my-label",
                    @class = "label"
                }));
            }
        }

        public class PasswordMethodFixture : BootstrapRendererFixture
        {
            [Fact]
            public void Should_Render()
            {
                var expected = @"<input type=""password"" name=""my-password"" value=""asdf"" />";

                AssertMarkupEqual(expected, _renderer.Password("my-password", "asdf"));
            }

            [Fact]
            public void Should_Render_With_Custom_Attributes()
            {
                var expected = @"<input type=""password"" name=""my-password"" value=""asdf"" class=""pretty"" size=""10"" />";

                AssertMarkupEqual(expected, _renderer.Password("my-password", "asdf", new
                {
                    @class = "pretty",
                    size = 10
                }));
            }
        }

        public class RadioButtonFixture : BootstrapRendererFixture
        {
            [Fact]
            public void Should_Render()
            {
                var expected = @"<div class=""radio"">
                                    <label>
                                        <input type=""radio"" name=""my-radio"" value=""my-radio-value"" />
                                        Hello World
                                    </label>
                                </div>";

                AssertMarkupEqual(expected, _renderer.RadioButton("my-radio", "my-radio-value", "Hello World"));
            }

            [Fact]
            public void Should_Render_Checked_Attribute()
            {
                var expected = @"<div class=""radio"">
                                    <label>
                                        <input type=""radio"" name=""my-radio"" value=""my-radio-value"" checked />
                                        Hello World
                                    </label>
                                </div>";

                AssertMarkupEqual(expected, _renderer.RadioButton("my-radio", "my-radio-value", "Hello World", true));
            }

            [Fact]
            public void Should_Render_With_Custom_Attributes()
            {
                var expected = @"<div id=""rayjo"" class=""pretty radio"">
                                    <label>
                                        <input type=""radio"" name=""my-radio"" value=""my-radio-value"" checked />
                                        Hello World
                                    </label>
                                </div>";

                AssertMarkupEqual(expected, _renderer.RadioButton("my-radio", "my-radio-value", "Hello World", true, new
                {
                    Id = "rayjo",
                    @class = "pretty"
                }));
            }
        }

        public class RadioButtonGroupMethod : BootstrapRendererFixture
        {
            private readonly IEnumerable<ListOption<int>> _options;

            public RadioButtonGroupMethod()
            {
                _options = new List<ListOption<int>>    
                {
                    new ListOption<int>("one", 1),
                    new ListOption<int>("two", 2),
                    new ListOption<int>("three", 3)
                };
            }

            [Fact]
            public void Should_Render_With_No_Selected_Option()
            {
                var expected = @"<div class=""radio"">
                                    <label>
                                        <input type=""radio"" name=""myradio"" value=""1"" />
                                        one
                                    </label>
                                </div>
                                <div class=""radio"">
                                    <label>
                                        <input type=""radio"" name=""myradio"" value=""2"" />
                                        two
                                    </label>
                                </div>
                                <div class=""radio"">
                                    <label>
                                        <input type=""radio"" name=""myradio"" value=""3"" />
                                        three
                                    </label>
                                </div>";

                AssertMarkupEqual(expected, _renderer.RadioButtonGroup("myradio", _options, 0));
            }

            [Fact]
            public void Should_Render_With_Selected_Options_Enumerable()
            {
                var expected = @"<div class=""radio"">
                                    <label>
                                        <input type=""radio"" name=""myradio"" value=""1"" />
                                        one
                                    </label>
                                </div>
                                <div class=""radio"">
                                    <label>
                                        <input type=""radio"" name=""myradio"" value=""2"" />
                                        two
                                    </label>
                                </div>
                                <div class=""radio"">
                                    <label>
                                        <input type=""radio"" name=""myradio"" value=""3"" checked />
                                        three
                                    </label>
                                </div>";

                AssertMarkupEqual(expected, _renderer.RadioButtonGroup("myradio", _options, 3));
            }

            [Fact]
            public void Should_Render_With_Selected_Options_Lambda()
            {
                var expected = @"<div class=""radio"">
                                    <label>
                                        <input type=""radio"" name=""myradio"" value=""1"" />
                                        one
                                    </label>
                                </div>
                                <div class=""radio"">
                                    <label>
                                        <input type=""radio"" name=""myradio"" value=""2"" checked />
                                        two
                                    </label>
                                </div>
                                <div class=""radio"">
                                    <label>
                                        <input type=""radio"" name=""myradio"" value=""3"" />
                                        three
                                    </label>
                                </div>";

                AssertMarkupEqual(expected, _renderer.RadioButtonGroup("myradio", _options, o => o.Value == 2));
            }
        }
    }
}
