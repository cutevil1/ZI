using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Scan;

namespace ScanObjectBuilder
{
    public class PEScanObjectBuilder
    {
        FileObjectContent file;
        public PEScanObjectBuilder() { }

        public PEScanObjectBuilder(FileObjectContent f)
        {
            file = f;
        }

        bool Check_PE() 
        {
            Scan.CheckFile check = new CheckFile(file.name);
            return check.IsFilePE();
        }

        public ScanObject CreateScanObject() 
        {
            if (Check_PE())
            {
                return new ScanObject(file);
            }
            else
            {
                return null;
            }
        }
    }
}
