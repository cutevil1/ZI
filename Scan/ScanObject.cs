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
		const int size = 1024;

        public IObjectContent content;
        bool start_scan_object = false,
			 start_object_region = false, 
             end_scan_object = false,
             end_object_region = false; 
        byte[] block;
        
        List<ScanRegion> region_list = new List<ScanRegion> { }; 

        ScanObject() { }

        public ScanObject(IObjectContent obj) 
        {
            content = obj;
        }

        public int Block_read()
        {
            
            int lim = 0;
            for (int i = 0; i < content.Size_object() / size; i++) 
            {
                region_list.Add(new ScanRegion(content, size,lim));
                lim += size;
            }
            

            int err = 0;

            foreach(var sc in region_list) 
            {
                if (sc.Block_split()) 
                {
                    err++;
                    Console.WriteLine("Найдена Сигнатура!");
                }
            }


            return err;
        }

        public int Size_object()
        {
            return 0;
        }
    }
}
