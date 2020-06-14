using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scan
{
    public class CheckFile
    {
        string file_path;
        public CheckFile(string path)
        {
            file_path = path;
        }

        public bool IsFilePE()
        {
            const int blockSize = 16;
            string path = this.file_path;
            byte[] PE = { 80, 69, 00, 00 };
            byte[] buff = new byte[blockSize];

            using (var f = File.OpenRead(path))
            {
                while (true)
                {
                    int read;
                    int lim;
                    for (lim = 0; lim < blockSize;)
                    {
                        read = f.Read(buff, lim, blockSize - lim);
                        if (read == 0) return false;

                        for (int i = 0; i <= blockSize-4; i++)
                        {
                            if (buff[i] == PE[0])
                            {
                                if (buff[i + 1] == PE[1] && buff[i + 2] == PE[2] && buff[i + 3] == PE[3]) return true;
                            }
                        }
                        lim += read;
                        if (lim > 1024) return false;
                    }
                }
            }
        }
    }
}
