using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;
using System.Text.Encodings.Web;
using System.Text.Unicode;

namespace Task16._1
{
    class Program
    {
        public static JavaScriptEncoder JavascriptEn { get; private set; }

        static void Main(string[] args)
        {
            const int n = 5;
            Product[] products = new Product[n];

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Введите код товара");
                int code = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Введите наименование товара");
                string name = Console.ReadLine();

                Console.WriteLine("Введите цену товара");
                double price = Convert.ToDouble(Console.ReadLine());
                products[i] = new Product() { Code = code, Name = name, Price = price };
            }
            JsonSerializerOptions option = new JsonSerializerOptions()
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                WriteIndented = true
            };
            string jsonString = JsonSerializer.Serialize(products, option);

            using (StreamWriter sw = new StreamWriter("../../../Products.json"))
            {
                sw.WriteLine(jsonString);
            }

        }
    }
}
