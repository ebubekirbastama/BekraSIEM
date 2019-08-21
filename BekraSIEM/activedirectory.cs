using System;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;
using System.Windows.Forms;

namespace BekraSIEM
{
    public partial class activedirectory : Form
    {
        public activedirectory()
        {
            InitializeComponent();
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {

            using (var context = new PrincipalContext(ContextType.Domain, textBoxX1.Text))
            {
                using (var searcher = new PrincipalSearcher(new UserPrincipal(context)))
                {
                    foreach (var result in searcher.FindAll())
                    {
                        DirectoryEntry de = result.GetUnderlyingObject() as DirectoryEntry;
                        richTextBox1.AppendText("First Name: " + de.Properties["givenName"].Value);
                        richTextBox1.AppendText("Last Name : " + de.Properties["sn"].Value);
                        richTextBox1.AppendText("SAM account name   : " + de.Properties["samAccountName"].Value);
                        richTextBox1.AppendText("User principal name: " + de.Properties["userPrincipalName"].Value);

                    }
                }
            }
        }
    }
}
