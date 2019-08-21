using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BekraSIEM
{
    public partial class Panel : Form
    {
        public Panel()
        {
            InitializeComponent();
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.ShowDialog();
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Bekraanliklog ak = new Bekraanliklog();
            ak.ShowDialog();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            anliklog al = new anliklog();
            al.ShowDialog();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            activedirectory ac = new activedirectory();ac.ShowDialog();
        }
    }
}
