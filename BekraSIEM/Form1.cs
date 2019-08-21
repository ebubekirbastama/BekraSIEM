using System;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BekraSIEM
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
        }
        object entries;
        private void securtyLogListingToolStripMenuItem_ClickAsync(object sender, EventArgs e)
        {
            securtylogi().ContinueWith(task => { task.Status.ToString(); });

        }
        #pragma warning disable CS1998 
                async Task securtylogi()
        #pragma warning restore CS1998 
        {
            try
            {
                EventLog log = new EventLog(comboBoxEx1.SelectedText);
                entries = log.Entries.Cast<EventLogEntry>()
                                        //.Where(x => x.InstanceId == 4624)
                                        .Select(x => new
                                        {
                                            x.Index,
                                            x.MachineName,
                                            x.EntryType,
                                            #pragma warning disable CS0618 
                                            x.EventID,
                                            #pragma warning restore CS0618 
                                            x.CategoryNumber,
                                            x.InstanceId,
                                            x.TimeGenerated,
                                            x.Source,
                                            x.Message
                                        }).ToList();
                if (entries != null)
                {
                    dataGridView1.DataSource = entries;
                    dataGridView1.PerformLayout();
                }
            }
            catch// (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            int cellls = dataGridView1.CurrentCell.ColumnIndex;
            richTextBox1.Text = dataGridView1.CurrentRow.Cells[cellls].Value.ToString();
        }
        string[] logname = {
            "Application",
            "COMODO Internet Security CEF",
            "HardwareEvents",
            "Internet Explorer",
            "Key Management Service",
            "ODiag",
            "OSession",
            "Security",
            "System",
            "Windows PowerShell" }; 
        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < logname.Length; i++)
            {
                comboBoxEx1.Items.Add(logname[i].ToString());
            }
        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            
        }
    }
}
