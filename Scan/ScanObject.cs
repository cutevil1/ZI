using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scan
{
    public class ScanObject
    {
        string file_name, 
               file_path; 

        public IObjectContent content;
        bool start_scan_object = false, 
             end_scan_object = false,  
             start_object_region = false, 
             end_object_region = false; 
        byte[] block;
        const int blocksize = 1024;
        List<ScanRegion> region_list = new List<ScanRegion> { }; 

        ScanObject() { }

        public ScanObject(IObjectContent obj) 
        {
            content = obj;
        }

        public int Block_read()
        {
            
            int offset = 0;
            for (int i = 0; i < content.Size_object() / blocksize; i++) 
            {
                region_list.Add(new ScanRegion(content, blocksize,offset));
                offset += blocksize;
            }
            

            int errors = 0;

            Console.WriteLine("Начало файла:");
            int j = 0;
            foreach(var sc in region_list) 
            {
                Console.WriteLine("Начало сегмента " + j + ":");
                if (sc.Block_split()) 
                {
                    errors++;
                    Console.WriteLine("Найдена Сигнатура!");
                }
                else 
                {
                    Console.WriteLine("Сигнатур не найдено!");
                }
                Console.WriteLine("Конец сегмента " + j + ":");
                j++;
            }
          

            Console.WriteLine("Конец файла:")


            return errors;
        }

        public int Size_object()
        {
            return 0;
        }
    }
}
