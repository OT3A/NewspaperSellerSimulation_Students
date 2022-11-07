using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NewspaperSellerModels;
using NewspaperSellerTesting;
using System.IO;

namespace NewspaperSellerSimulation
{
    public partial class Form1 : Form
    {
        public string filePath { get; set; }
        public SimulationSystem sys { get; set; }
        public Form1(SimulationSystem sys)
        {
            this.sys = sys;
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Select_Click(object sender, EventArgs e)
        {

            int size = -1;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            DialogResult result = openFileDialog1.ShowDialog(); // Show the dialog.

            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();

            if(result == DialogResult.OK)
            {
                filePath = openFileDialog1.FileName;
                try
                {
                    string text = File.ReadAllText(filePath);
                    size = text.Length;
                    sys = new SimulationSystem();
                    ReadDataFromTextFile data = new ReadDataFromTextFile(filePath, sys);
                    Calculations.FillTabel(sys);
                    Calculations.FillPerformanceMeasures(sys);
                    dataGridView1.DataSource = sys.SimulationTable;
                    List<PerformanceMeasures> p = new List<PerformanceMeasures>();
                    p.Add(sys.PerformanceMeasures);
                    dataGridView2.DataSource = p;
                    label2.Text = sys.NumOfNewspapers.ToString();
                    label4.Text = sys.SellingPrice.ToString();
                    label6.Text = sys.PurchasePrice.ToString();
                    label7.Text = sys.ScrapPrice.ToString();
                }
                catch (IOException)
                {

                }
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label2.Text = 0.ToString();
            label4.Text = 0.ToString();
            label6.Text = 0.ToString();
            label7.Text = 0.ToString();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
