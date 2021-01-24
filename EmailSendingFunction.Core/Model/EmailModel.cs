namespace EmailSendingFunction.Core.Model
{
    public class EmailModel
    {
        public string Body { get; set; }
        public string ToEmail { get; set; }
        public string Recipient { get; set; }
        public string Subject { get; set; }
    }
}