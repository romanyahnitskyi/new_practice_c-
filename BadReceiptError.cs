namespace ReceiptsAPI.Validation
{
    public class BadReceiptError
    {
        public string Property { get; set; }
        public string Message { get; set; }

        public BadReceiptError(string property, string message)
        {
            Property = property;
            Message = message;
        }
    }
}
