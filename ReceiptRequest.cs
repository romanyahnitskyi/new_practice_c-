namespace ReceiptsAPI.Requests
{
    public class ReceiptRequest
    {
        public string RecipientName { get; set; }
        public string RecipientIban { get; set; }
        public string Bank { get; set; }
        public string PaymentType { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDateTime { get; set; }
    }
}
