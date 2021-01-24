namespace EmailSendingFunction.Core.DbModel
{
    public class EmailLogModel
    {
        public long Id { get; set; }
        public string Subject { get; set; }
        public string Boy { get; set; }
        public string Recipient { get; set; }
    }
}