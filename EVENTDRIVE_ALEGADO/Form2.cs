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
    public partial class Form2 : Form
    {
      
        public Form2()
        {
            InitializeComponent();
            LoadExcelFile();

        }
        private int GetSelectedRow()
        {

            if (dtgInfo.SelectedCells.Count > 0)
            {

                int selectedRowIndex = dtgInfo.SelectedCells[0].RowIndex;
                return selectedRowIndex;
            }
            return -1;
        }
        public void loadLogs()
        {
            Mylogs logs = new Mylogs();
            logs.showLogs(dtgInfo);
        }
        public void LoadExcelFile()
        {
            Workbook book = new Workbook();
            book.LoadFromFile(@"C:\Users\Computer\Desktop\EVENTDRIVEN\sint\EVENTDRIVE_ALEGADO\BOOKDB.xlsx");
            Worksheet sheet = book.Worksheets[0];
            DataTable dt = sheet.ExportDataTable();
            dtgInfo.DataSource = dt;
        }


        public void showStudent(string status)
        {
            Workbook book = new Workbook();
            book.LoadFromFile(@"C:\Users\Computer\Desktop\EVENTDRIVEN\sint\EVENTDRIVE_ALEGADO\BOOKDB.xlsx");
            Worksheet sh = book.Worksheets[0];
            DataTable dt = sh.ExportDataTable();
            DataTable filteredTable = dt.Clone();
            DataRow[] row = dt.Select("Status = " + status);

            foreach (DataRow r in row)
            {
                filteredTable.ImportRow(r);

                /* dtgInfo.Rows.Insert(count, r[0], r[1], r[2], r[3], r[4], r[5], r[6], r[7], r[8], r[9], r[10], r[11], r[12]);

                 count++;*/
            }
            dtgInfo.DataSource = filteredTable;
        }
        public void insert(string name, string gender, string hobbies, string color, string saying)
        {
            int i = dtgInfo.Rows.Add();
            dtgInfo.Rows[i].Cells[0].Value = name;
            dtgInfo.Rows[i].Cells[1].Value = gender;
            dtgInfo.Rows[i].Cells[2].Value = hobbies;
            dtgInfo.Rows[i].Cells[3].Value = color;
            dtgInfo.Rows[i].Cells[4].Value = saying;
        }
        public void update(int id, string name, string gender, string hobbies, string color, string saying)
        {

            dtgInfo.Rows[id].Cells[0].Value = name;
            dtgInfo.Rows[id].Cells[1].Value = gender;
            dtgInfo.Rows[id].Cells[2].Value = hobbies;
            dtgInfo.Rows[id].Cells[3].Value = color;
            dtgInfo.Rows[id].Cells[4].Value = saying;
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

            Mylogs logs = new Mylogs(); 
            logs.insertLogs(DisplayIt.CurrentUser, "Searched in the active list.");
            string searchText = txtSearch.Text.ToLower();
            bool foundMatch = false;

            if (string.IsNullOrEmpty(txtSearch.Text))
            {
                MessageBox.Show("Please enter the cell you want to search.", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }



            foreach (DataGridViewRow row in dtgInfo.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.Value != null && cell.Value.ToString().ToLower().Split(' ').Contains(searchText))
                    {
                        cell.Style.BackColor = Color.Yellow;
                        foundMatch = true;
                    }
                    else
                    {
                        cell.Style.BackColor = dtgInfo.DefaultCellStyle.BackColor;
                    }
                }
            }

            if (foundMatch)
            {
                MessageBox.Show("Matching cells have been highlighted.", "Search Results", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("No matching cells found.", "Search Results", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            //dtgInfo.ClearSelection();

            //if (string.IsNullOrEmpty(txtSearch.Text))
            //{
            //    MessageBox.Show("Please type on the search bar!", "Notice!");
            //}
            //else
            //{
            //    foreach (DataGridViewRow row in dtgInfo.Rows)
            //    {
            //        if (row.Cells[0].Value.ToString().Equals(txtSearch.Text))
            //        {
            //            row.Selected = true;
            //            break;
            //        }
            //    }

            //}
        }
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text.ToLower();

            foreach (DataGridViewRow row in dtgInfo.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    cell.Style.BackColor = dtgInfo.DefaultCellStyle.BackColor;
                }
            }
        }

        public void UpdateToExcel(int ID, string name, string gender, string hobbies, string address, string email, string birthday, string age, string favColor, string user, string pass, string saying, string course, string status, string profile)
        {
            Workbook book = new Workbook();
            book.LoadFromFile(@"C:\Users\Computer\Desktop\EVENTDRIVEN\sint\EVENTDRIVE_ALEGADO\BOOKDB.xlsx");
            Worksheet sheet = book.Worksheets[0];

            int id = ID + 2;
            sheet.Range[id, 1].Value = name;
            sheet.Range[id, 2].Value = gender;
            sheet.Range[id, 3].Value = address;
            sheet.Range[id, 4].Value = email;
            sheet.Range[id, 5].Value = birthday;
            sheet.Range[id, 6].Value = age;
            sheet.Range[id, 7].Value = user;
            sheet.Range[id, 8].Value = pass;
            sheet.Range[id, 9].Value = hobbies;
            sheet.Range[id, 10].Value = favColor;
            sheet.Range[id, 11].Value = saying;
            sheet.Range[id, 12].Value = course;
            sheet.Range[id, 13].Value = status;
            sheet.Range[id, 14].Value = profile;

            book.SaveToFile(@"C:\Users\Computer\Desktop\EVENTDRIVEN\sint\EVENTDRIVE_ALEGADO\BOOKDB.xlsx");

            int dgvIndex = ID;
            dtgInfo.Rows[dgvIndex].Cells[0].Value = name;
            dtgInfo.Rows[dgvIndex].Cells[1].Value = gender;
            dtgInfo.Rows[dgvIndex].Cells[2].Value = address;
            dtgInfo.Rows[dgvIndex].Cells[3].Value = email;
            dtgInfo.Rows[dgvIndex].Cells[4].Value = birthday;
            dtgInfo.Rows[dgvIndex].Cells[5].Value = age;
            dtgInfo.Rows[dgvIndex].Cells[6].Value = user;
            dtgInfo.Rows[dgvIndex].Cells[7].Value = pass;
            dtgInfo.Rows[dgvIndex].Cells[8].Value = hobbies;
            dtgInfo.Rows[dgvIndex].Cells[9].Value = favColor;
            dtgInfo.Rows[dgvIndex].Cells[10].Value = saying;
            dtgInfo.Rows[dgvIndex].Cells[11].Value = course;
            dtgInfo.Rows[dgvIndex].Cells[11].Value = status;

        }

        private void dtgInfo_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            Form4 frm4 = new Form4();
            Form1 frm1 = new Form1();

            int r = dtgInfo.CurrentCell.RowIndex;

            frm1.lblInfo.Text = r.ToString();
            string name = dtgInfo.Rows[r].Cells[0].Value.ToString();
            string gender = dtgInfo.Rows[r].Cells[1].Value.ToString();
            string address = dtgInfo.Rows[r].Cells[2].Value.ToString();
            string email = dtgInfo.Rows[r].Cells[3].Value.ToString();
            string birthday = dtgInfo.Rows[r].Cells[4].Value.ToString();
            string age = dtgInfo.Rows[r].Cells[5].Value.ToString();
            string user = dtgInfo.Rows[r].Cells[6].Value.ToString();
            string pass = dtgInfo.Rows[r].Cells[7].Value.ToString();
            string hobbies = dtgInfo.Rows[r].Cells[8].Value.ToString();
            string favColor = dtgInfo.Rows[r].Cells[9].Value.ToString();
            string saying = dtgInfo.Rows[r].Cells[10].Value.ToString();
            string course = dtgInfo.Rows[r].Cells[11].Value.ToString();
            string status = dtgInfo.Rows[r].Cells[12].Value.ToString();
            string profile = dtgInfo.Rows[r].Cells[13].Value.ToString();

            profile = frm4.lblProfPathHolder.Text;


            frm1.UpdateTextFields(r, name, gender, hobbies, address, email, birthday, age, favColor, user, pass, saying, course, status, profile);
            frm1.btnAdd.Visible = false;
            frm1.btnBrowse.Visible = false;
            frm1.lblProfile.Visible = false;
            frm1.txtBrowse.Visible = false;
            frm1.btnUpdate.Visible = true;
            frm1.Show();
            this.Hide();

            //int r = dtgInfo.CurrentCell.RowIndex;
            //Form1 f1 = (Form1)Application.OpenForms["Form1"];
            //f1.lblInfo.Text = r.ToString();
            //f1.txtName.Text = dtgInfo.Rows[r].Cells[0].Value.ToString();
            //string gender = dtgInfo.Rows[r].Cells[1].Value.ToString();
            //if (gender == "Male")
            //{
            //    f1.radMale.Checked = true;
            //}
            //else
            //{
            //    f1.radFemale.Checked = true;
            //}
            //f1.txtAddress.Text = dtgInfo.Rows[r].Cells[2].Value.ToString();
            //f1.txtEmail.Text = dtgInfo.Rows[r].Cells[3].Value.ToString();
            //f1.dtpBirthday.Text = dtgInfo.Rows[r].Cells[4].Value.ToString();
            //f1.txtAge.Text = dtgInfo.Rows[r].Cells[5].Value.ToString();
            //f1.txtUsername.Text = dtgInfo.Rows[r].Cells[6].Value.ToString();
            //f1.txtPassword.Text = dtgInfo.Rows[r].Cells[7].Value.ToString();

            //string hobbies = dtgInfo.Rows[r].Cells[8].Value.ToString();
            //if (hobbies == "Basketball")
            //{
            //    f1.chkBasketball.Checked = true;
            //}
            //if (hobbies == "Volleyball")
            //{
            //    f1.chkVolleyball.Checked = true;
            //}
            //if (hobbies == "Soccer")
            //{
            //    f1.chkSoccer.Checked = true;
            //}

            //f1.cmbFavColor.Text = dtgInfo.Rows[r].Cells[9].Value.ToString();
            //f1.txtSaying.Text = dtgInfo.Rows[r].Cells[10].Value.ToString();
            //f1.cmbCourse.Text = dtgInfo.Rows[r].Cells[11].Value.ToString();
            //f1.txtStatus.Text = dtgInfo.Rows[r].Cells[12].Value.ToString();

            //f1.btnAdd.Visible = false;
            //f1.btnUpdate.Visible = true;

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult Yes = MessageBox.Show("Are you sure you want to change the status of the selected info?", "Notice", MessageBoxButtons.YesNo);

            if (Yes == DialogResult.Yes)
            {

                Workbook book = new Workbook();
                book.LoadFromFile(@"C:\Users\Computer\Desktop\EVENTDRIVEN\sint\EVENTDRIVE_ALEGADO\BOOKDB.xlsx");
                Worksheet sh = book.Worksheets[0];
                int row = dtgInfo.CurrentCell.RowIndex + 2;

                sh.Range[row, 13].Value = "0";
                this.showStudent("1");

                //if(sh.Range[row, 13].Value == "0")
                //{
                //    this.showStudent("1");
                //}
                //else
                //{
                //    this.showStudent("0");
                //}




                book.SaveToFile(@"C:\Users\Computer\Desktop\EVENTDRIVEN\sint\EVENTDRIVE_ALEGADO\BOOKDB.xlsx", ExcelVersion.Version2016);

            }

        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();  
        }


        private void btnDeleteLogs_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to delete the selected info?", "Notice", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                // Load the Excel workbook
                Workbook book = new Workbook();
                book.LoadFromFile(@"C:\Users\Computer\Desktop\EVENTDRIVEN\sint\EVENTDRIVE_ALEGADO\BOOKDB.xlsx");
                Worksheet sh = book.Worksheets[0];
                // Get the current row index from the DataGridView
                int row = dtgInfo.CurrentCell.RowIndex + 2; // Adjust for header rows if necessary
                // Delete the row from the worksheet
                //int row = sh.Rows.Length;
                sh.DeleteRow(row);
                // Save the changes to the Excel file
                book.SaveToFile(@"C:\Users\Computer\Desktop\EVENTDRIVEN\sint\EVENTDRIVE_ALEGADO\BOOKDB.xlsx", ExcelVersion.Version2013);
                // Optionally, refresh the DataGridView to reflect the changes
                //LoadDataIntoDataGridView(); // Implement this method to reload data from the Excel file
            }
        }
    }
}
