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
        int segment_size, 
            scan_offset_begin; 
        IObjectContent objectContent;
        const int BLOCK_SIZE = 8 * 1024; 
        public ScanRegion() { }
        public ScanRegion(IObjectContent obj, int seg_size, int offset)
        {
            objectContent = obj;
            segment_size = seg_size;
            scan_offset_begin = offset;
        }

        public bool Block_split() 
        {

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
