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
        string path,
               name;
        int check
        {
            get{return check;}
            set {}
        }
        Stopwatch stop = new Stopwatch();
		
        public ScanReport()
        {
            check = 0;
            stop.Start();
            try
            {
                scan_report_list.Clear();
            }
            catch (Exception) { };
        }

        public List<ScanReport> scan_report_list = new List<ScanReport>();
        public void Add_record(bool inf, string path, string name)
        {
            if (!inf) check++;
            else
            {
                scan_report_list.Add(new ScanReport()
                {
                    path = path,
                    name = name
                });
                check++;
            }
        }

        public string Get_time_scaning()
        {
            stop.Stop();
            TimeSpan ts = stop.Elapsed;
            string timeE = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds / 10);
            return timeE;
        }
    }
}
