using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
namespace Receipt_my
{
    class Program
    {
        static void Main(string[] args)
        {
            bool do_it = true;
            Console.WriteLine("Input file name");
            Collection coll = new Collection
            {
                File_path = Console.ReadLine()
            };
            while (do_it)
            {
                Console.WriteLine("----------Menu----------");
                Console.WriteLine("Choose need option:");
                Console.WriteLine("1.Add new");
                Console.WriteLine("2.Delete");
                Console.WriteLine("3.Edit");
                Console.WriteLine("4.Search");
                Console.WriteLine("5.Sort");
                Console.WriteLine("6.Exit");
                string option = Validator.input_positive_num();
                while(Int32.Parse(option)<1 ^ Int32.Parse(option)>6)
                {
                    Console.WriteLine("Incorrect data.Re-enter it");
                    option = Validator.input_positive_num();
                }
                switch (option)
                {
                    case ("1"):
                        coll.add_new();
                        break;
                    case ("2"):
                        Console.WriteLine("Input id");
                        string id = Validator.input_positive_num();
                        coll.delete_by_id(id);
                        break;
                    case ("3"):
                        Console.WriteLine("Input id");
                        id = Validator.input_positive_num();
                        coll.edit_by_id(id);
                        break;
                    case ("4"):
                        Console.WriteLine("Input request");
                        string str =Console.ReadLine() ;
                        coll.Search(str);
                        break;
                    case ("5"):
                        coll.sort_by();
                        break;
                    case ("6"):
                        do_it = false;
                        break;

                }
            }

        }

    }
}
