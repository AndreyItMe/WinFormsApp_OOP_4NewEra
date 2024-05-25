namespace WinFormsApp_OOP_2
{
    public class ComboboxItem
    {
        public string? Text { get; set; }
        public object? Value { get; set; }

        public override string? ToString()
        {
            return Text;
        }
    }
}
