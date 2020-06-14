using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scan
{
    public class FileObjectContent : IObjectContent
    {
        public string name;

        public FileObjectContent(string n) 
        {
            name = n;
        }
        public int Block_read(byte[] block,int start, int blocksize)
        {
            using (FileStream file = File.OpenRead(name))
            {
                file.Seek(start, SeekOrigin.Begin);
                file.Read(block, 0, blocksize);
            }
            return 0;
        }

        public int Size_object()
        {
            FileInfo fi = new FileInfo(name);
            return (int)fi.Length;
        }
    }
}
