using Scan;
using ScanObjectBuilder;
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
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        public ScanObject so { get; set; }
        private void MainWindow_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e) //start_scan_button

        {
            Scaning sc = new Scaning(so);

            sc.Show();
        }



        private void button4_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                PEScanObjectBuilder build = new PEScanObjectBuilder(new Scan.FileObjectContent(fileDialog.FileName));
                so = build.CreateScanObject();
                label3.Text = fileDialog.FileName;
            }
        }
    }
}
