using System;
using System.IO;
using SignatureBase;
using ScanObjectBuilder;
using Scan;

namespace SignatureBase
{
    class Program
    {
        static void Main()
        {
            //Signature my_sign = new Signature();
            // Console.WriteLine("До сортировки по префиксу");
            // string wm_str = "";

            //my_sign.LineSplit("Petya 6 hello jshgdfjsygdvhd 1 10");
            //my_sign.LineSplit("Alesha 6 wo jshgdfjsygdvhd 1 10");
            //my_sign.LineSplit("Zinaida 6 aloha jshgdfjsygdvhd 1 10");
            //my_sign.LineSplit("Cactus 6 aut jshgdfjsygdvhd 1 10");


            //Console.WriteLine("Результат проверки файла:");
            //string tmp = "wehjoniuowowisvuosi jhrgiu";
            //bool flag;

            //// циклический посимвольный поиск
            //wm_str= my_sign.Find_prefix(tmp);
            //while (wm_str == "" && tmp != "")
            //{
            //    tmp = tmp.Substring(1);
            //    wm_str = my_sign.Find_prefix(tmp);
            //}
            //if (wm_str != "")
            //    Console.WriteLine("Префикс сигнатуры: {0}", wm_str);
            //else
            //    Console.WriteLine("Не найдено");


            //Scan.CheckFile my_path = new Scan.CheckFile("C:/Games/Hearts of Iron IV/unit_test.txt");
            //bool result = my_path.IsFilePE();

            //if (result)
            //    Console.WriteLine("Execute file");
            //else
            //    Console.WriteLine("Not execute file");


            PEScanObjectBuilder sob = new PEScanObjectBuilder(new Scan.FileObjectContent("C:/Program Files (x86)/Crusader Kings 2/unins000.exe"));

            ScanObject so = sob.CreateScanObject();
            Console.WriteLine("Размер файла в байтах:" + so.content.Size_object());
            so.Block_read();
            Console.ReadKey();


        }
 
    }
}
