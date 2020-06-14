using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using SignatureBase;

namespace Scan
{
    public class ScanRegion
    {
        int segment_size, //Размер сегмента
            scan_offset_begin; //Смещение относительно начала контента
        IObjectContent objectContent;
        const int BLOCK_SIZE = 8 * 1024; // 1 кбайт

        //IObjectContent IOC = new IObjectContent(); //Объект IObjectContent
        public ScanRegion() { }
        public ScanRegion(IObjectContent obj, int seg_size, int offset)
        {
            objectContent = obj;
            segment_size = seg_size;
            scan_offset_begin = offset;
        }

        public bool Block_split() //Метод блочного чтения заданного региона
        {
            // разбить файл на регионы (делим на BLOCK_SIZE)
            // создать список регионов, являющихся экземплярами класса ScanRegion
            // читаем каждый полученный блок и вызываем проверку из SignatureIO

            byte[] res = new byte[segment_size];
            objectContent.Block_read(res, scan_offset_begin, segment_size);
            Console.WriteLine(System.Text.Encoding.Default.GetString(res));

            Signature tmp = new Signature();
            tmp.Load_all_line_in_base();
            if (tmp.FindSignature(Encoding.Default.GetString(res))) 
            {
                return true;
            }
            else 
            {
                return false;
            }
            
        }
    }
}
