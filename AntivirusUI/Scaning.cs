using Scan;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AntivirusUI
{
    public partial class Scaning : Form
    {
        public ScanObject so;
        public static int files_count = 0;
        public Scaning(ScanObject s)
        {
            InitializeComponent();
            so = s;
        }

        private void Break_button_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void start_stop_button_Click(object sender, EventArgs e)
        {
            if (start_stop_button.Text == "Приостановить")
            {
                start_stop_button.Text = "Возобновить";
            }
            else
            {
                ScanReport report = new ScanReport();
                //label5.Text = Convert.ToString(so.Block_read()); 
                label8.Text = "Идет сканирование...";
                label5.Text = Convert.ToString(so.Block_read());
                files_count++;
                label3.Text = Convert.ToString(files_count);
                label7.Text += report.Get_time_scaning();
                label8.Text = "Сканирование завершено!";
                start_stop_button.Text = "Приостановить";
                //Task task = new Task(() =>
                //{

                //    label5.Text = Convert.ToString(so.Block_read());
                //    files_count++;
                //    label3.Text = Convert.ToString(files_count);
                //    label7.Text += report.Get_time_scaning();
                //    label8.Text = "Сканирование завершено!";
                //});

                

                
            }
        }

        private void Scaning_Load(object sender, EventArgs e)
        {
              
        }
    }
}
