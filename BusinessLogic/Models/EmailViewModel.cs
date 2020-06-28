namespace BusinessLogic.Models
{
    public class EmailViewModel
    {
        public string To { get; set; }

        public string Content { get; set; }

        public string Subject { get; set; }

        public bool IsHtml { get; set; }
    }
}
