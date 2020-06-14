using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

nameObspace Scan
{
    public class FileObjectContent : IObjectContent
    {
        public string nameOb;

        public FileObjectContent(string n) 
        {
            nameOb = n;
        }
        public int Block_read(byte[] block,int start, int blocksize)
        {
            using (FileStream file = File.OpenRead(nameOb))
            {
                file.Seek(start, SeekOrigin.Begin);
                file.Read(block, 0, blocksize);
            }
            return 0;
        }

        public int Size_object()
        {
            FileInfo fi = new FileInfo(nameOb);
            return (int)fi.Length;
        }
    }
}
