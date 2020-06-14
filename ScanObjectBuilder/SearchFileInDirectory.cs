using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScanObjectBuilder
{
    class SearchFileInDirectory
    {
        public string[] Get_all_file_path_in_directory(string pathToDirectory)
        {
            string[] array_file_in_path = Search_file(pathToDirectory, "*.*");
            return array_file_in_path;
        }


        private string[] Search_file(string patch, string pattern)
        {
            try
            {
                string[] reult_search = Directory.GetFiles(patch, pattern, SearchOption.AllDirectories);
                return reult_search;
            }
            catch (UnauthorizedAccessException)
            {
                // add messagebox
                string[] reult_search = { "-1" };
                return reult_search;
            }
        }

        
            

    }
}
