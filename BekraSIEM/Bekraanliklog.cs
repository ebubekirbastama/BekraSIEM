using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace BekraSIEM
{
    public partial class Bekraanliklog : Form
    {
        public Bekraanliklog()
        {
            InitializeComponent();
        }
        private void runningProcessListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clear(); veri_getir();
        }
        void clear()
        {
            git: for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                dataGridView1.Rows.RemoveAt(i);
            }
            if (dataGridView1.Rows.Count!=0)
            {
                goto git;
            }
        }
        void veri_getir()
        {
            Process[] Memory = Process.GetProcesses();

            for (int i = 0; i < Memory.Length - 1; i++)
            {
                dataGridView1.Rows.Add(Memory[i].Id, Memory[i].ProcessName, Memory[i].StartTime);
            }
        }
        void createcolumns()
        {
            dataGridView1.ColumnCount = 3;
            dataGridView1.Columns[0].Name = "ID";
            dataGridView1.Columns[1].Name = "Name";
            dataGridView1.Columns[2].Name = "Star Time";
        }
      
        private void Bekraanliklog_Load(object sender, EventArgs e)
        {
            createcolumns();
            veri_getir();
        }
    }
}
