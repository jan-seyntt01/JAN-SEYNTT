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
    public partial class Form1 : Form
    {
        string[] info = new string[5];
        int i = 0;
        Form2 f2 = new Form2();
        public Form1()
        {
            InitializeComponent();
        }
        public string checkEmpty()
        {
            string errors = "Empty fields";
            foreach (Control c in Controls)
            {
                if (c is TextBox)
                {
                    if(c.Text == "")
                    {
                        errors += c.Name + " is empty";
                    }
                }
                if (c is RadioButton)
                {
                    if (c.Text == "")
                    {
                        errors += c.Name + " is empty";
                    }
                }
                if (c is ComboBox)
                {
                    if (c.Text == "")
                    {
                        errors += c.Name + " is empty";
                    }
                }
                //if (c is DateTimePicker)
                //{
                   
                //    if (c is DateTimePicker dateTimePicker)
                //    {
                        
                //        if (dateTimePicker.Value.Date == DateTime.Today) 
                //        {
                //            errors += c.Name + " is not selected\n";
                            
                //        }
                //    }
                //}
            }
            return errors;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pnlInfo.BackColor = Color.FromArgb(30, 50, 50, 100);
            txtAge.Enabled = false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            lblMessage.Text = checkEmpty();
            lblMessage.Visible = true;
            string data = "";
            string gender = "";
            string hobbies = "";

            data = txtName.Text;
            if (radMale.Checked == true)
            {
                gender = radMale.Text;
            }
            if (radFemale.Checked == true)
            {
                gender = radFemale.Text;
            }
            if (chkBasketball.Checked)
            {
                hobbies += " " + chkBasketball.Text;
            }
            if (chkVolleyball.Checked)
            {
                hobbies += " " + chkVolleyball.Text;
            }
            if (chkSoccer.Checked)
            {
                hobbies += " " + chkSoccer.Text;
            }
            data += cmbFavColor.Text;
            data += txtSaying.Text;

            info[i] = data;
            i++;

            //f2.insert(txtName.Text, gender, hobbies, cmbFavColor.Text, txtSaying.Text);
            Workbook book = new Workbook();
            book.LoadFromFile(@"C:\Users\Computer\Desktop\EVENTDRIVEN\sint\EVENTDRIVE_ALEGADO\BOOKDB.xlsx");
            Worksheet sh = book.Worksheets[0];
            int row = sh.Rows.Length + 1;
            sh.Range[row, 1].Value = txtName.Text;
            sh.Range[row, 2].Value = gender;
            sh.Range[row, 3].Value = txtAddress.Text;
            sh.Range[row, 4].Value = txtEmail.Text;
            sh.Range[row, 5].Value = dtpBirthday.Text;
            sh.Range[row, 6].Value = txtAge.Text;
            sh.Range[row, 7].Value = txtUsername.Text;
            sh.Range[row, 8].Value = txtPassword.Text;
            sh.Range[row, 9].Value = hobbies;
            sh.Range[row, 10].Value = cmbFavColor.Text;
            sh.Range[row, 11].Value = txtSaying.Text;
            sh.Range[row, 12].Value = cmbCourse.Text;
            sh.Range[row, 13].Value = txtStatus.Text;

            

            if (lblMessage.Text == "")
            {
                book.SaveToFile(@"C:\Users\Computer\Desktop\EVENTDRIVEN\sint\EVENTDRIVE_ALEGADO\BOOKDB.xlsx", ExcelVersion.Version2016);
                DataTable dt = sh.ExportDataTable();
                f2.dtgInfo.DataSource = dt;
            }
            else return;

            txtName.Clear();
            txtSaying.Clear();

        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            btnAdd.Visible = false;
            string data = "";
            string gender = "";
            string hobbies = "";

            data = txtName.Text;
            if (radMale.Checked == true)
            {
                gender = radMale.Text;
            }
            if (radFemale.Checked == true)
            {
                gender = radFemale.Text;
            }
            if (chkBasketball.Checked)
            {
                hobbies += " " + chkBasketball.Text;
            }
            if (chkVolleyball.Checked)
            {
                hobbies += " " + chkVolleyball.Text;
            }
            if (chkSoccer.Checked)
            {
                hobbies += " " + chkSoccer.Text;
            }
            data += cmbFavColor.Text;
            data += txtSaying.Text;

            info[i] = data;
            i++;

            //f2.update(Convert.ToInt32(lblInfo.Text), txtName.Text, gender, hobbies, cmbFavColor.Text, txtSaying.Text);
            Workbook book = new Workbook();
            book.LoadFromFile(@"C:\Users\Computer\Desktop\EVENTDRIVEN\sint\EVENTDRIVE_ALEGADO\BOOKDB.xlsx");
            Worksheet sh = book.Worksheets[0];
            int row = f2.dtgInfo.CurrentCell.RowIndex + 2;
            sh.Range[row, 1].Value = txtName.Text;
            sh.Range[row, 2].Value = gender;
            sh.Range[row, 3].Value = txtAddress.Text;
            sh.Range[row, 4].Value = txtEmail.Text;
            sh.Range[row, 5].Value = dtpBirthday.Text;
            sh.Range[row, 6].Value = txtAge.Text;
            sh.Range[row, 7].Value = txtUsername.Text;
            sh.Range[row, 8].Value = txtPassword.Text;
            sh.Range[row, 9].Value = hobbies;
            sh.Range[row, 10].Value = cmbFavColor.Text;
            sh.Range[row, 11].Value = txtSaying.Text;
            sh.Range[row, 12].Value = cmbCourse.Text;
            sh.Range[row, 13].Value = txtStatus.Text;

            book.SaveToFile(@"C:\Users\Computer\Desktop\EVENTDRIVEN\sint\EVENTDRIVE_ALEGADO\BOOKDB.xlsx", ExcelVersion.Version2016);
            DataTable dt = sh.ExportDataTable();
            f2.dtgInfo.DataSource = dt;
        }
        private void btnDisplay_Click(object sender, EventArgs e)
        {
            f2.Show();
        }

        private void dtpBirthday_ValueChanged(object sender, EventArgs e)
        {
            string[] d = dtpBirthday.Text.ToString().Split(',');
            txtAge.Text = (2025 - Convert.ToInt32(d[2])).ToString();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog d = new OpenFileDialog();
            if(d.ShowDialog()  == DialogResult.OK)
            {
                txtBrowse.Text = d.FileName;    
            }
        }
    }
}
