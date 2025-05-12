using Spire.Xls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
        public bool IsValidEmail(string email)
        {

            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            Regex regex = new Regex(pattern);
            return regex.IsMatch(email);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pnlInfo.BackColor = Color.FromArgb(30, 50, 50, 100);
            txtAge.Enabled = false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            Workbook book = new Workbook();
            lblMessage.Text = checkEmpty();
            lblMessage.Visible = true;

            lblMessage.Text = "";
            StringBuilder errors = new StringBuilder();

            if (string.IsNullOrWhiteSpace(txtUsername.Text)) errors.AppendLine("• Username is required.");
            if (string.IsNullOrWhiteSpace(txtPassword.Text)) errors.AppendLine("• Password is required.");
            if (string.IsNullOrWhiteSpace(txtName.Text)) errors.AppendLine("• Name is required.");
            if (!radMale.Checked && !radFemale.Checked) errors.AppendLine("• Gender is required.");
            if (string.IsNullOrWhiteSpace(txtAddress.Text)) errors.AppendLine("• Address is required.");
            if (string.IsNullOrWhiteSpace(txtEmail.Text)) errors.AppendLine("• Email is required.");
            if (!dtpBirthday.Checked) errors.AppendLine("• Birthday is required.");
            if (!chkBasketball.Checked && !chkVolleyball.Checked && !chkSoccer.Checked) errors.AppendLine("• At least one sport must be selected.");
            if (cmbFavColor.SelectedIndex == -1) errors.AppendLine("• Favorite color must be selected.");
            if (cmbCourse.SelectedIndex == -1) errors.AppendLine("• Course must be selected.");
            if (string.IsNullOrWhiteSpace(txtSaying.Text)) errors.AppendLine("• Saying is required.");
            if (string.IsNullOrWhiteSpace(txtStatus.Text)) errors.AppendLine("• Status is required.");
            if (string.IsNullOrWhiteSpace(txtBrowse.Text)) errors.AppendLine("• Profile is required.");


            if (errors.Length > 0)
            {
                lblMessage.Text = errors.ToString();
                lblMessage.Visible = true;
                MessageBox.Show("Please fill in all required fields!", "MISSING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //txtName.Clear();
                //txtAddress.Clear();
                //txtEmail.Clear();
                //dtpBirthday.Checked = false;
                //txtUsername.Clear();
                //txtPassword.Clear();
                //cmbFavColor.SelectedIndex = -1;
                //cmbCourse.SelectedIndex = -1;
                //radMale.Checked = false;
                //radFemale.Checked = false;
                //chkBasketball.Checked = false;
                //chkVolleyball.Checked = false;
                //chkSoccer.Checked = false;
                //txtAge.Clear();
                //txtSaying.Clear();
                //txtBrowse.Clear();
                return;

            }

            try
            {

                string name = txtName.Text;
                string gender = "";
                if (radMale.Checked)
                {
                    gender = "Male";
                }
                if (radFemale.Checked)
                {
                    gender = "Female";
                }

                string hobbies = "";
                if (chkBasketball.Checked) hobbies += "Basketball ";
                if (chkVolleyball.Checked) hobbies += "Volleyball ";
                if (chkSoccer.Checked) hobbies += "Badminton ";

                string address = txtAddress.Text;
                string email = txtEmail.Text;
                string birthday = dtpBirthday.Text;
                string age = txtAge.Text;
                string favColor = cmbFavColor.Text;
                string user = txtUsername.Text;
                string pass = txtPassword.Text;
                string saying = txtSaying.Text;
                string course = cmbCourse.Text;
                string profile = txtBrowse.Text;
                string status = lblStatus.Text;

                book.LoadFromFile(@"C:\Users\Computer\Desktop\EVENTDRIVEN\sint\EVENTDRIVE_ALEGADO\BOOKDB.xlsx");
                Worksheet sheet = book.Worksheets[0];

                for (int row = 2; row <= sheet.LastRow; row++)//ERROR FOR EXISTING USER AND PASS
                {
                    string existingUsername = sheet.Range[row, 7].Value;
                    string existingPassword = sheet.Range[row, 8].Value;

                    if (existingUsername == txtUsername.Text)
                    {
                        MessageBox.Show("Username already exists. Please choose a different one.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if (existingPassword == txtPassword.Text)
                    {
                        MessageBox.Show("Password already exists. Please choose a different one.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                if (!IsValidEmail(email))
                {
                    MessageBox.Show("Invalid email format. Please enter a valid email.");
                    return;
                }
               

                int i = sheet.Rows.Length + 1;
                sheet.Range[i, 1].Value = txtName.Text;
                sheet.Range[i, 2].Value = gender;
                sheet.Range[i, 3].Value = txtAddress.Text;
                sheet.Range[i, 4].Value = txtEmail.Text;
                sheet.Range[i, 5].Value = dtpBirthday.Text;
                sheet.Range[i, 6].Value = txtAge.Text;
                sheet.Range[i, 7].Value = txtUsername.Text;
                sheet.Range[i, 8].Value = txtPassword.Text;
                sheet.Range[i, 9].Value = hobbies;
                sheet.Range[i, 10].Value = cmbFavColor.Text;
                sheet.Range[i, 11].Value = txtSaying.Text;
                sheet.Range[i, 12].Value = cmbCourse.Text;
                sheet.Range[i, 13].Value = txtStatus.Text;
                sheet.Range[i, 14].Value = txtBrowse.Text;

                book.SaveToFile(@"C:\Users\Computer\Desktop\EVENTDRIVEN\sint\EVENTDRIVE_ALEGADO\BOOKDB.xlsx", ExcelVersion.Version2016);

                DialogResult result = MessageBox.Show("Student successfully added!", "SUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (result == DialogResult.OK)
                {
                    Form4 frm4 = new Form4();
                    Mylogs logs = new Mylogs();
                    logs.insertLogs(DisplayIt.CurrentUser, "Added a new Student to the list.");
                    frm4.Show();

                }
                txtUsername.Clear();
                txtPassword.Clear();
                txtName.Clear();
                radMale.Checked = false;
                radFemale.Checked = false;
                txtAddress.Clear();
                txtEmail.Clear();
                dtpBirthday.Checked = false;
                chkBasketball.Checked = false;
                chkVolleyball.Checked = false;
                chkSoccer.Checked = false;
                cmbFavColor.SelectedIndex = -1;
                cmbCourse.SelectedIndex = -1;
                txtSaying.Clear();
                txtStatus.Clear();
                txtBrowse.Clear();



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //string data = "";
            //string gender = "";
            //string hobbies = "";

            //data = txtName.Text;
            //if (radMale.Checked == true)
            //{
            //    gender = radMale.Text;
            //}
            //if (radFemale.Checked == true)
            //{
            //    gender = radFemale.Text;
            //}
            //if (chkBasketball.Checked)
            //{
            //    hobbies += " " + chkBasketball.Text;
            //}
            //if (chkVolleyball.Checked)
            //{
            //    hobbies += " " + chkVolleyball.Text;
            //}
            //if (chkSoccer.Checked)
            //{
            //    hobbies += " " + chkSoccer.Text;
            //}
            //data += cmbFavColor.Text;
            //data += txtSaying.Text;

            //info[i] = data;
            //i++;

            ////f2.insert(txtName.Text, gender, hobbies, cmbFavColor.Text, txtSaying.Text);
            //Workbook book = new Workbook();
            //book.LoadFromFile(@"C:\Users\Computer\Desktop\EVENTDRIVEN\sint\EVENTDRIVE_ALEGADO\BOOKDB.xlsx");
            //Worksheet sh = book.Worksheets[0];
            //int row = sh.Rows.Length + 1;
            //sh.Range[row, 1].Value = txtName.Text;
            //sh.Range[row, 2].Value = gender;
            //sh.Range[row, 3].Value = txtAddress.Text;
            //sh.Range[row, 4].Value = txtEmail.Text;
            //sh.Range[row, 5].Value = dtpBirthday.Text;
            //sh.Range[row, 6].Value = txtAge.Text;
            //sh.Range[row, 7].Value = txtUsername.Text;
            //sh.Range[row, 8].Value = txtPassword.Text;
            //sh.Range[row, 9].Value = hobbies;
            //sh.Range[row, 10].Value = cmbFavColor.Text;
            //sh.Range[row, 11].Value = txtSaying.Text;
            //sh.Range[row, 12].Value = cmbCourse.Text;
            //sh.Range[row, 13].Value = txtStatus.Text;



            //if (lblMessage.Text == "")
            //{
            //    book.SaveToFile(@"C:\Users\Computer\Desktop\EVENTDRIVEN\sint\EVENTDRIVE_ALEGADO\BOOKDB.xlsx", ExcelVersion.Version2016);
            //    DataTable dt = sh.ExportDataTable();
            //    f2.dtgInfo.DataSource = dt;
            //}
            //else return;

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
