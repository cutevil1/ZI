using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scan
{
    public interface IObjectContent
    {
        int Size_object();
        int Block_read(byte[] b,int s,int bs); 
    }
}
