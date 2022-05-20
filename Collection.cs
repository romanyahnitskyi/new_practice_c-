using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Receipt_my
{
    class Collection
    {
        string file_path = "";
        public List<Receipt> collect = new List<Receipt>();
        public string File_path
        {
           get
            {
                return file_path;
            }
           set
            {
                file_path = value;
                FileInfo file = new FileInfo(value);
                while(file.Exists!=true)
                {
                    Console.WriteLine("Non-existent file.Enter a valid name:");
                    file_path=Console.ReadLine();
                    file =new FileInfo(file_path);
                }
               
                    collect = JsonConvert.DeserializeObject<List<Receipt>>(File.ReadAllText(file_path));    
            }
        }
        public void File_update()
        {
            string str = JsonConvert.SerializeObject(collect);
            File.WriteAllText(file_path,str);
        }
        public void add_new()
        {
            Console.WriteLine("Input id,name,iban,bank,patment_type,ammount,datetime");
            Receipt rc = new Receipt
            {
                Id = Validator.input_positive_num(),
                Recipient_name = Console.ReadLine(),
                Recipient_iban = Validator.input_iban(),
                Bank = Validator.input_bank(),
                Payment_type = Validator.input_payment_type(),
                Amount = Validator.input_positive_num(),
                Payment_datetime = Validator.input_payment_datetime()
            };
            collect.Add(rc);
            this.File_update();
        }
        public int Search_by_id(string id)
        {
            int out_ = -1;
            foreach (Receipt iter in collect)
            {
                out_ += 1;
                if (iter.Id == id)
                    return out_;
            }
            return (-1);
        }
        public List<Receipt> Search(string str)
        {
            List<Receipt> out_ = new List<Receipt>();
            foreach(Receipt iter in collect)
            {
                if (iter.Id.Contains(str)^iter.Recipient_name.Contains(str) ^ iter.Recipient_iban.Contains(str) ^ iter.Bank.Contains(str) ^ iter.Payment_type.Contains(str) ^ iter.Amount.Contains(str) ^ iter.Payment_datetime.Contains(str))
                    out_.Add(iter);
            }
            return out_;
        }
        public void delete_by_id(string id)
        {
            int num = this.Search_by_id(id);
            if (num != -1)
            {
                collect.RemoveAt(num);
                this.File_update();            
            }
            else
                Console.WriteLine("Id not found");
        }
        public void edit_by_id(string id)
        {
            int num = this.Search_by_id(id);
            Console.WriteLine("Which atribute tou want to change(2-7)");
            string atr = Validator.input_positive_num();
            while (Int32.Parse(atr) < 2 ^ Int32.Parse(atr) > 7)
            {
                Console.WriteLine("Input correct number");
                atr = Validator.input_positive_num();
            }
            if (num != -1)
            {
                collect[num].edit(atr);
                this.File_update();
            }
            else
                Console.WriteLine("Id not found");
        }
        public void sort_by()
        {
            Console.WriteLine("Which atribute tou want use for sort(1-7)");
            string atr = Validator.input_positive_num();
            while (Int32.Parse(atr) < 1 ^ Int32.Parse(atr) > 7)
            {
                Console.WriteLine("Input correct number");
                atr = Validator.input_positive_num();
            }
            switch (atr)
            {
                case ("1"):
                    collect = collect.OrderBy(Receipt =>
                    {
                        var propertyInfo = Receipt.GetType().GetProperty("Id");
                        var value = propertyInfo.GetValue(Receipt, null);
                        return value;
                    }).ToList();
                    this.File_update();
                    break;
                case ("2"):
                    collect = collect.OrderBy(Receipt =>
                    {
                        var propertyInfo = Receipt.GetType().GetProperty("Recipient_name");
                        var value = propertyInfo.GetValue(Receipt, null);
                        return value;
                    }).ToList();
                    this.File_update();
                    break;
                case ("3"):
                    collect = collect.OrderBy(Receipt =>
                    {
                        var propertyInfo = Receipt.GetType().GetProperty("Recipient_iban");
                        var value = propertyInfo.GetValue(Receipt, null);
                        return value;
                    }).ToList();
                    this.File_update();
                    break;
                case ("4"):
                    collect = collect.OrderBy(Receipt =>
                    {
                        var propertyInfo = Receipt.GetType().GetProperty("Bank");
                        var value = propertyInfo.GetValue(Receipt, null);
                        return value;
                    }).ToList();
                    this.File_update();
                    break;
                case ("5"):
                    collect = collect.OrderBy(Receipt =>
                    {
                        var propertyInfo = Receipt.GetType().GetProperty("Payment_type");
                        var value = propertyInfo.GetValue(Receipt, null);
                        return value;
                    }).ToList();
                    this.File_update();
                    break;
                case ("6"):
                    collect = collect.OrderBy(Receipt =>
                    {
                        var propertyInfo = Receipt.GetType().GetProperty("Amount");
                        var value = propertyInfo.GetValue(Receipt, null);
                        return value;
                    }).ToList();
                    this.File_update();
                    break;
                case ("7"):
                    collect = collect.OrderBy(Receipt =>
                    {
                        var propertyInfo = Receipt.GetType().GetProperty("Payment_datetime");
                        var value = propertyInfo.GetValue(Receipt, null);
                        return value;
                    }).ToList();
                    this.File_update();
                    break;
                    
            }
        }
       

    }
     
            
}
