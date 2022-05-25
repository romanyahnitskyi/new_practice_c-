using ReceiptsAPI.Validation;

namespace ReceiptsAPI.Requests
{
    public class Result
    {
        public string? Status { get; set; }
        public string? Message { get; set; }
        public string Errors { get; set; }
        public ReceiptResponse? Receipt { get; set; }
    }
}
