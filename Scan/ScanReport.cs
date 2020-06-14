using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scan
{
    public class ScanReport
    {
        string path_to_infected_file,
               virus_name;
        int total_checked_file
        {
            get{return total_checked_file;}
            set {}
        }

        Stopwatch stop_watch = new Stopwatch();

        public ScanReport()
        {
            total_checked_file = 0;
            stop_watch.Start();
            try
            {
                scan_report_list.Clear();
            }
            catch (Exception) { };
        }

        public List<ScanReport> scan_report_list = new List<ScanReport>();

        public void Add_record(bool infecded, string path_to_infected_file, string virus_name)
        {
            if (!infecded)
                total_checked_file++;
            else
            {
                scan_report_list.Add(new ScanReport()
                {
                    path_to_infected_file = path_to_infected_file,
                    virus_name = virus_name
                });
                total_checked_file++;
            }
        }

        public string Get_time_scaning()
        {
            stop_watch.Stop();
            TimeSpan ts = stop_watch.Elapsed;
            string elapsed_time = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds / 10);
            return elapsed_time;
        }
    }
}
