using Spire.Xls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EVENTDRIVE_ALEGADO
{
    public partial class Form3 : Form
    {
        Mylogs log = new Mylogs();
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            pnlSignIn.BackColor = Color.FromArgb(80, 0, 70, 100);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Workbook book = new Workbook();
            book.LoadFromFile(@"C:\Users\ACT-STUDENT\Desktop\seyntt\EVENTDRIVE_ALEGADO\BOOKDB.xlsx");
            Worksheet sheet = book.Worksheets[0];
            int row = sheet.Rows.Length;
            bool logs = false;
            if (string.IsNullOrEmpty(txtUsername.Text) || string.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show("Required fields!", "Notice!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else {
                for (int i = 2; i <= row; i++)
                {
                    if (sheet.Range[i, 7].Value == txtUsername.Text && sheet.Range[i, 8].Value == txtPassword.Text)
                    {

                        log.insertLogs(txtUsername.Text, txtUsername.Text + " logged in");
                        logs = true;
                        break;
                    }
                    else
                    {
                        logs = false;
                    }


                }
                if (logs == true)
                {
                    MessageBox.Show("You've succressfully login!", "Notice!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Form4 f1 = new Form4();
                    f1.Show();
                    this.Hide();

                } else { 
                
                    MessageBox.Show("Incorrect username or password. Please try again!", "Notice!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            
          
        }

        private void chkshowpassword_CheckedChanged(object sender, EventArgs e)
        {
            if (chkshowpassword.Checked == true)
            {
                txtPassword.UseSystemPasswordChar = false;
            }
            else
            {
                txtPassword.UseSystemPasswordChar = true;
            }
        }
    }
}
