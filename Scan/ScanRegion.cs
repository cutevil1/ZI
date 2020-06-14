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
        int size, 
            begin; 
        IObjectContent objectContent;
        public ScanRegion() { }
        public ScanRegion(IObjectContent obj, int sizeS, int offset)
        {
            objectContent = obj;
            size = sizeS;
            begin = offset;
        }

        public bool Block_split() 
        {
            byte[] res = new byte[size];
            objectContent.Block_read(res, begin, size);
            Signature tmp = new Signature();
            tmp.Load_all_line_in_base();
            if (tmp.FindSignature(Encoding.Default.GetString(res))) return true;
            else return false;
        }
    }
}
