using ReceiptsAPI.Entities;
using ReceiptsAPI.Requests;
using static ReceiptsAPI.Validation.Validation;

namespace ReceiptsAPI
{
    public class ReceiptLogic
    {
        private readonly ReceiptContext db;

        public ReceiptLogic(ReceiptContext context)
        {
            db = context;
        }

        public List<ReceiptResponse> GetAll(User user, string sort_by, string sort_type, string s)
        {
            var receipts = 
                db
                .Receipts.ToList()
                .Where(c => c?.User?.UserName == user.UserName)
                .ToList();

            if (sort_by != null)
            {
                var property =
                    typeof(Receipt)
                    .GetProperties()
                    .FirstOrDefault(prop => prop.Name.ToLower() == sort_by?.ToLower());

                if (property != null)
                {
                    if (sort_type?.ToLower() == "descending")
                    {
                        receipts = receipts.OrderByDescending(c => property.GetValue(c)).ToList();
                    }
                    else
                    {
                        receipts = receipts.OrderBy(c => property.GetValue(c)).ToList();
                    }
                }
            }

            if (s != null)
            {
                var properties = typeof(Receipt).GetProperties();
                var foundedReceipts = new List<Receipt>();

                foreach (Receipt receipt in receipts)
                {
                    foreach (var property in properties)
                    {
                        if (property.GetValue(receipt).ToString().ToLower().Contains(s.ToLower()))
                        {
                            foundedReceipts.Add(receipt);
                            break;
                        }
                    }
                }

                var answer = foundedReceipts.Select(r => new ReceiptResponse()
                {
                    Id = r.Id,
                    RecipientName = r.RecipientName,
                    RecipientIban = r.RecipientIban,
                    Bank = r.Bank,
                    PaymentType = r.PaymentType,
                    Amount = r.Amount,
                    PaymentDateTime = r.PaymentDateTime
                })
                .ToList();

                return answer;
            }

            var result = receipts.Select(r => new ReceiptResponse()
            {
                Id = r.Id,
                RecipientName = r.RecipientName,
                RecipientIban = r.RecipientIban,
                Bank = r.Bank,
                PaymentType = r.PaymentType,
                Amount = r.Amount,
                PaymentDateTime = r.PaymentDateTime
            })
            .ToList();

            return result;
        }

        public ReceiptResponse GetById(User user, int id)
        {
            Receipt receipt = db.Receipts.Find(id);

            if (receipt != null && receipt.User.UserName == user.UserName)
            {
                return new ReceiptResponse()
                {
                    Id = receipt.Id,
                    RecipientName = receipt.RecipientName,
                    RecipientIban = receipt.RecipientIban,
                    Bank = receipt.Bank,
                    PaymentType = receipt.PaymentType,
                    Amount = receipt.Amount,
                    PaymentDateTime = receipt.PaymentDateTime
                };
            }

            return null;
        }

        public Result Create(User user, ReceiptRequest request)
        {
            string messages = IsValid(request.RecipientName, request.RecipientIban, request.Bank, request.PaymentType, request.Amount, request.PaymentDateTime);

            if (messages != String.Empty)
                return new Result { Errors = messages };

            Receipt receipt = new Receipt()
            {
                RecipientName = request.RecipientName,
                RecipientIban = request.RecipientIban,
                Bank = request.Bank,
                PaymentType = request.PaymentType,
                Amount = request.Amount,
                PaymentDateTime = request.PaymentDateTime,
                User = user
            };

            db.Receipts.Add(receipt);
            db.SaveChanges();

            return new Result { Message = "Created" };
        }

        public Result EditById(User user, int id, ReceiptRequest request)
        {
            string messages = IsValid(request.RecipientName, request.RecipientIban, request.Bank, request.PaymentType, request.Amount, request.PaymentDateTime);

            if (messages != String.Empty)
                return new Result { Errors = messages };

            Receipt receipt = db.Receipts.Find(id);

            if (receipt is null || receipt.UserId != user.Id)
                return null;

            receipt.RecipientName = request.RecipientName;
            receipt.RecipientIban = request.RecipientIban;
            receipt.Bank = request.Bank;
            receipt.PaymentType = request.PaymentType;
            receipt.Amount = request.Amount;
            receipt.PaymentDateTime = request.PaymentDateTime;

            db.Receipts.Update(receipt);
            db.SaveChanges();

            return new Result { Message = "Updated" };
        }

        public Result RemoveById(User user, int id)
        {
            Receipt receipt = db.Receipts.Find(id);

            if (receipt is null || receipt.UserId != user.Id)
                return null;

            db.Receipts.Remove(receipt);
            db.SaveChanges();

            return new Result { Message = "Deleted" };
        }
    }
}
