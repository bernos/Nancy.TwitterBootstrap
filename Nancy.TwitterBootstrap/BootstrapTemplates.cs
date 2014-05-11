namespace Nancy.TwitterBootstrap
{
    public class BootstrapTemplates
    {
        public string BeginFormGroup = @"<div{attributes}>";
        public string EndFormGroup = @"</div>";

        public string Checkbox = @"<div{attributes}>
                                        <label>
                                            <input type=""checkbox"" name=""{name}"" value=""{value}""{selected} />
                                            {label}
                                        </label>
                                    </div>";

        public string Input = @"<input type=""{type}"" name=""{name}"" value=""{value}""{attributes} />";

        public string Label = @"<label{attributes}>{label}</label>";

        public string RadioButton = @"<div{attributes}>

                                        <label>
                                            <input type=""radio"" name=""{name}"" value=""{value}""{selected} />
                                            {label}
                                        </label>
                                    </div>";

        public string SelectList = @"<select {multiple} id=""{id}"" name=""{name}"" class=""{class}"">{options}</select>";
        public string SelectListOption = @"<option value=""{value}""{selected}>{label}</option>";

        public string Table = @"<table class=""{class}"">{content}</table>";
        public string TableBody = @"<tbody>{content}</tbody>";
        public string TableCell = @"<td>{content}</td>";
        public string TableHeader = @"<thead>{content}</thead>";
        public string TableHeaderCell = @"<th>{content}</th>";
        public string TableRow = @"<tr>{content}</tr>";

        public string ValidationMessage = @"<span class=""help-block"">{message}</span>";
    }
}