using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scan
{
    public class ScanObject
    {
        string file_name, //для файлов имя файла
               file_path; //путь до объекта

        public IObjectContent content;
        bool start_scan_object = false, //флаги, сигнализирующие о начале и конце файла
             end_scan_object = false,  // ..
             start_object_region = false, //флаги, сигнализирующие о начале и конце блока 
             end_object_region = false; // ..
        byte[] block;
        const int blocksize = 1024;
        List<ScanRegion> region_list = new List<ScanRegion> { }; //Список регионов ScanRegion для сканирования
        //Список подобъектов

        ScanObject() { }

        public ScanObject(IObjectContent obj) 
        {
            content = obj;
        }

        public int Block_read()
        {
            //Cначала метод возвращает регионы для сканирования самого объекта, 
            //затем рекурсивно применяется ко всем дочерним объектам. 
            //Метод должен сигнализировать о начале и конце объекта, о начале и 
            //конце каждого региона, о начале и конце каждого дочернего подобъекта
            
            int offset = 0;
            for (int i = 0; i < content.Size_object() / blocksize; i++) 
            {
                region_list.Add(new ScanRegion(content, blocksize,offset));
                offset += blocksize;
            }
            //ScanReport report = new ScanReport();

            int errors = 0;

            Console.WriteLine("Начало файла:");
            int j = 0;
            foreach(var sc in region_list) 
            {
                Console.WriteLine("Начало сегмента " + j + ":");
                if (sc.Block_split()) 
                {
                    errors++;
                    //report.Add_record()
                    Console.WriteLine("Найдена Сигнатура!");
                }
                else 
                {
                    Console.WriteLine("Сигнатур не найдено!");
                }
                Console.WriteLine("Конец сегмента " + j + ":");
                j++;
            }
            // Directory.GetFiles
            // SearchFile

            Console.WriteLine("Конец файла:");

            // 1. вызываем scan_region для разбиения на блоки (сигнал о начале и конце объекта, начало и конец региона,
            // начало и конец дочернего подобъекта)
            // ммм рекурсия



            return errors;
        }

        public int Size_object()
        {
            return 0;
        }
    }
}
