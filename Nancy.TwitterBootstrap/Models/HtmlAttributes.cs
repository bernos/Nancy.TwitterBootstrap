using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nancy.TwitterBootstrap.Models
{
    public class HtmlAttributes
    {
        private readonly IDictionary<string, string> _attributes;

        public HtmlAttributes(object attributes)
        {
            _attributes = new Dictionary<string, string>();

            if (attributes as HtmlAttributes != null)
            {
                Merge(attributes as HtmlAttributes);
            } 
            else if (attributes != null)
            {
                foreach (var property in attributes.GetType().GetProperties())
                {
                    _attributes[property.Name] = property.GetValue(attributes, null).ToString();
                }
            }
        }

        public IDictionary<string, string> AsDictionary()
        {
            return _attributes;
        }

        public string this[string key]
        {
            get { return _attributes[key]; }
            set { _attributes[key] = value; }
        } 

        public HtmlAttributes Merge(HtmlAttributes otherAttributes)
        {
            if (otherAttributes != null)
            {
                foreach (var kvp in otherAttributes.AsDictionary())
                {
                    if (_attributes.ContainsKey(kvp.Key))
                    {
                        _attributes[kvp.Key] += " " + kvp.Value;
                    }
                    else
                    {
                        _attributes[kvp.Key] = kvp.Value;
                    }
                }
            }

            return this;
        }

        public override string ToString()
        {
            var output = new StringBuilder();

            foreach (var attribute in _attributes.OrderBy(o => o.Key, new AttributeNameComparer()))
            {
                if (attribute.Value.ToLower() != "false")
                {
                    if (attribute.Value.ToLower() == "true")
                    {
                        output.Append(string.Format(" {0}", attribute.Key.Replace("_", "-").ToLower()));
                    }
                    else
                    {
                        output.Append(string.Format(" {0}=\"{1}\"", attribute.Key.Replace("_", "-").ToLower(), attribute.Value));
                    }
                }

                
            }

            return output.ToString();
        }

        private class AttributeNameComparer : IComparer<string>
        {
            public int Compare(string x, string y)
            {
                if (x.ToLower() == "id")
                {
                    return y.ToLower() == "id" ? 0 : -1;
                }

                if (y.ToLower() == "id")
                {
                    return 1;
                }

                return string.Compare(x, y);
            }
        }
    }
}