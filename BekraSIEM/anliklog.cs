using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace BekraSIEM
{
    public partial class anliklog : Form
    {
        public anliklog()
        {
            InitializeComponent();
        }

        private void startLogingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fileSystemWatcher1.EnableRaisingEvents = true;
        }
        void veri_getir(string log,string state)
        {
            dataGridView1.Rows.Add(log, state);
        }
        void createcolumns()
        {
            dataGridView1.ColumnCount = 2;
            dataGridView1.Columns[0].Name = "Log";
            dataGridView1.Columns[1].Name = "State";
        }
        private void fileSystemWatcher1_Created(object sender, FileSystemEventArgs e)
        {
            try
            {

                veri_getir(e.FullPath+e.Name , "Oluşturuldu");

            }
            catch (Exception)
            {

            }

        }
        private void fileSystemWatcher1_Deleted(object sender, FileSystemEventArgs e)
        {
            try
            {

                veri_getir(e.FullPath , "Silindi");

            }
            catch (Exception)
            {

            }
        }
        private void fileSystemWatcher1_Renamed(object sender, RenamedEventArgs e)
        {
            try
            {

                veri_getir(e.FullPath , " Adı Değiştirildi");

            }
            catch (Exception)
            {

            }
        }
        private void fileSystemWatcher1_Changed(object sender, FileSystemEventArgs e)
        {
            try
            {

                veri_getir(e.FullPath , " Değişiklik yapıldı.");

            }
            catch (Exception ex)
            {

            }
        }

        private void anliklog_Load(object sender, EventArgs e)
        {
            createcolumns();
            notifyIcon1.Visible = false;
           
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            Process.Start(dataGridView1.CurrentRow.Cells[0].Value.ToString());
        }
    }
}
