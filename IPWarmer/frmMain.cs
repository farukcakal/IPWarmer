using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IPWarmer
{
    public partial class frmMain : Form
    {
        public int CurrentStep = 0;
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if(txtTargetEmail.Text != "")
            {
                if(lstTargetEmails.Items.Contains(txtTargetEmail.Text) == false)
                {
                    lstTargetEmails.Items.Add(txtTargetEmail.Text);
                }
                else
                {
                    MessageBox.Show("Email already exist.");
                }
            }
            else
            {
                MessageBox.Show("To: Textbox can't be null.");
            }
        }

        private void btnDeleteMail_Click(object sender, EventArgs e)
        {
            if(lstTargetEmails.SelectedItems.Count != 0)
            {
                while (lstTargetEmails.SelectedItems.Count > 0)
                {
                    lstTargetEmails.Items.Remove(lstTargetEmails.SelectedItems[0]);
                }
            }
            else
            {
                MessageBox.Show("Please select some email");
            }
        }
    }
}
