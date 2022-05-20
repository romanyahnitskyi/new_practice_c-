using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using Newtonsoft.Json;
namespace Receipt_my
{
    public class Receipt
    {
        string id = "Undefined";
        string recipient_iban = "Undefined";
        string bank = "Undefined";
        string amount = "Undefined";
        string payment_type = "Undefined";
        string payment_datetime = "Undefined";
        public string Id
        {
            get
            {
                return id;
            }
            set
            {
                if (Validator.positive_num(value))
                    id = value;
                else
                    id = Validator.input_positive_num();
            }
        }
        public string Recipient_name { get; set; }
        public string Recipient_iban
        {
            get
            {
                return recipient_iban;
            }
            set
            {
                if (Validator.iban_check(value))
                    recipient_iban = value;
                else
                    recipient_iban = Validator.input_iban();
            }
        }

        public string Bank
        {
            get
            {
                return bank;
            }
            set
            {
                if (Validator.bank_check(value))
                    bank = value;
                else
                    bank = Validator.input_bank();
            }
        }

        public string Payment_type
        {
            get
            {
                return payment_type;
            }
            set
            {
                if (Validator.payment_type_check(value))
                    payment_type = value;
                else
                    payment_type = Validator.input_payment_type();
            }
        }

        public string Amount
        {
            get
            {
                return amount;
            }
            set
            {
                if (Validator.positive_num(value))
                    amount = value;
                else
                    amount = Validator.input_positive_num();
            }
        }

        public string Payment_datetime
        {
            get
            {
                return payment_datetime;
            }
            set
            {
                if (Validator.payment_datetime_check(value))
                    payment_datetime = value;
                else
                    payment_datetime = Validator.input_payment_datetime();
            }
        }
        public void edit(string num)
        {
            switch(num)
            {
                case ("2"):
                    Recipient_name = Console.ReadLine();
                    break;
                case ("3"):
                    Recipient_iban = Validator.input_iban();
                    break;
                case ("4"):
                    Bank = Validator.input_bank();
                    break;
                case ("5"):
                    Payment_type = Validator.input_payment_type();
                    break;
                case ("6"):
                    Amount = Validator.input_positive_num();
                    break;
                case ("7"):
                    Payment_datetime = Validator.input_payment_datetime();
                    break;

            }
        }
 
        public string return_json()
        {
            return JsonConvert.SerializeObject(this);
        }
        
    }
}
