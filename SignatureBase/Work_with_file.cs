using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace SignatureBase
{
    public class Work_with_data
    {
        public Mutex mutex_wwd = new Mutex(false, "mutex_wwd");
        public string signature_db_file_name = "SignatureDB.txt", path_to_db_file;

        public Work_with_data()
        {
            path_to_db_file = Path.Combine(Directory.GetCurrentDirectory(), signature_db_file_name);
        }

        public void Write_to_end_file(string virus_name, int signature_length, int signature_prefix, string signature_hash, int offset_bigin, int offset_end)
        {
            string text = virus_name + " " + signature_length.ToString() + " " + signature_prefix.ToString() + " " +
                signature_hash + " " + offset_bigin.ToString() + " " + offset_end.ToString();
            mutex_wwd.WaitOne();
            try
            {
                using (StreamWriter writer = new StreamWriter(path_to_db_file, true, System.Text.Encoding.Default))
                {
                    writer.WriteLine(text);
                }
            }
            catch (Exception)
            { }
            finally
            {
                mutex_wwd.ReleaseMutex();
            }

        }


        public string Read_from_file_one_line(int number_line)
        {
            try
            {
                mutex_wwd.WaitOne();
                string line = File.ReadLines(path_to_db_file).ElementAt(number_line);

                return line;
            }
            catch (Exception)
            {
                return "-1";
            }
            finally
            {
                mutex_wwd.ReleaseMutex();
            }
        }

    }
}