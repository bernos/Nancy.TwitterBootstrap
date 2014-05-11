namespace Nancy.TwitterBootstrap.Models
{
    public class ListOption<TValue>
    {
        public string Label { get; set; }
        public TValue Value { get; set; }

        public ListOption(string label, TValue value)
        {
            Label = label;
            Value = value;
        }
    }
}