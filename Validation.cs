using System.Text.RegularExpressions;

namespace ReceiptsAPI.Validation
{
    public static class Validation
    {
        public static string IsValid(string name, string iban, string bank, string type, decimal amount, DateTime date)
        {
            string messages = String.Empty;

            if (Char.IsLower(name[0]))
                messages += "Recipient name - Ім'я повинно починатися з великої літери\n";

            if (!Regex.IsMatch(iban, VALID_IBAN))
                messages += "Recipient IBAN - Поганий формат IBAN\n";

            if (BANKS.FirstOrDefault(b => b == bank) == null)
                messages += "Bank - Вказано невідомий банк\n";

            if (TYPES.FirstOrDefault(t => t == type) == null)
                messages += "Payment type - Вказано поганий тип платежу\n";

            if (amount <= 0)
                messages += "Amount - Amount не може бути менше або рівне 0\n";

            if (date > DateTime.Now || date.Year < 1500)
                messages += $"Payment datetime - Date не може бути меншою за 01.01.1500 і більшою за {DateTime.Now.Day}.{DateTime.Now.Month}.{DateTime.Now.Year}\n";

            return messages;
        }

        private const string VALID_IBAN = @"^UA\d{8}[A-Z0-9]{19}$";
        private static string[] BANKS = new string[] { "privatbank", "universal_bank" };
        private static string[] TYPES = new string[] { "monthly", "yearly" };
    }
}