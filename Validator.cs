using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Receipt_my
{
    class Validator
    {
        public static bool positive_num(string num)
        {
            int num_;
            try
            {
                num_ = Int32.Parse(num);
            }
            catch (FormatException e)
            {
                Console.WriteLine("is not int format");
                return false;
            }
            if (num_ <= 0)
            {
                Console.WriteLine("must be >0");
                return false;
            }
            return true;
        }
        public static string input_positive_num()
        {
            while (true)
            {
                string str = Console.ReadLine();
                if (positive_num(str))
                    return (str);
            }
        }
        public static bool iban_check(string iban)
        {
            Regex rx = new Regex("^[A-Z]{2}[0-9]{27}$");

            if (rx.Matches(iban).Count == 1)
                return true;
            Console.WriteLine("Incorrect iban");
            return false;
        }
        public static string input_iban()
        {
            while (true)
            {
                string str = Console.ReadLine();
                if (iban_check(str))
                    return str;
            }
        }
        public static bool bank_check(string bank)
        {
            if ((bank == "privatbank") || (bank == "universal_bank"))
                return true;
            Console.WriteLine("Incorrect bank");
            return false;
        }
        public static string input_bank()
        {
            while (true)
            {
                string str = Console.ReadLine();
                if (bank_check(str))
                    return str;
            }
        }
        public static bool payment_type_check(string payment_type)
        {
            if ((payment_type == "monthly") || (payment_type == "yearly"))
                return true;
            Console.WriteLine("Incorrect payment_type");
            return false;
        }
        public static string input_payment_type()
        {
            while (true)
            {
                string str = Console.ReadLine();
                if (payment_type_check(str))
                    return str;
            }
        }
        public static bool payment_datetime_check(string payment_datetime)
        {
            try
            {
                DateTime.ParseExact(payment_datetime, "yyyy-MM-dd", null);
            }
            catch (FormatException e)
            {
                Console.WriteLine("is not right date format");
                return false;
            }
            return true;
        }
        public static string input_payment_datetime()
        {
            while (true)
            {
                string str = Console.ReadLine();
                if (payment_datetime_check(str))
                    return str;
            }
        }
    }
}
