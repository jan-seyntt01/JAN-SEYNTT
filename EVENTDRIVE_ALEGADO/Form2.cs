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
            book.LoadFromFile(@"C:\Users\ACT-STUDENT\Desktop\seyntt\EVENTDRIVE_ALEGADO\BOOKDB.xlsx");
            Worksheet sheet = book.Worksheets[0];
            DataTable dt = sheet.ExportDataTable();
            dtgInfo.DataSource = dt;
        }
        public void showStudent(string status)
        {
            Workbook book = new Workbook();
            book.LoadFromFile(@"C:\Users\ACT-STUDENT\Desktop\seyntt\EVENTDRIVE_ALEGADO\BOOKDB.xlsx");
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
            dtgInfo.ClearSelection();

            if (string.IsNullOrEmpty(txtSearch.Text))
            {
                MessageBox.Show("Please type on the search bar!", "Notice!");
            }
            else
            {
                foreach (DataGridViewRow row in dtgInfo.Rows)
                {
                    if (row.Cells[0].Value.ToString().Equals(txtSearch.Text))
                    {
                        row.Selected = true;
                        break;
                    }
                }

            }
        }

        private void dtgInfo_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Form1 f1 = new Form1();
            int r = dtgInfo.CurrentCell.RowIndex;
            //Form1 f1 = (Form1)Application.OpenForms["Form1"];
            f1.lblInfo.Text = r.ToString();
            f1.txtName.Text = dtgInfo.Rows[r].Cells[0].Value.ToString();
            string gender = dtgInfo.Rows[r].Cells[1].Value.ToString();
            if (gender == "Male")
            {
                f1.radMale.Checked = true;
            }
            else
            {
                f1.radFemale.Checked = true;
            }
            f1.txtAddress.Text = dtgInfo.Rows[r].Cells[2].Value.ToString();
            f1.txtEmail.Text = dtgInfo.Rows[r].Cells[3].Value.ToString();
            f1.dtpBirthday.Text = dtgInfo.Rows[r].Cells[4].Value.ToString();
            f1.txtAge.Text = dtgInfo.Rows[r].Cells[5].Value.ToString();
            f1.txtUsername.Text = dtgInfo.Rows[r].Cells[6].Value.ToString();
            f1.txtPassword.Text = dtgInfo.Rows[r].Cells[7].Value.ToString();

            string hobbies = dtgInfo.Rows[r].Cells[8].Value.ToString();
            if (hobbies == "Basketball")
            {
                f1.chkBasketball.Checked = true;
            }
            if (hobbies == "Volleyball")
            {
                f1.chkVolleyball.Checked = true;
            }
            if (hobbies == "Soccer")
            {
                f1.chkSoccer.Checked = true;
            }

            f1.cmbFavColor.Text = dtgInfo.Rows[r].Cells[9].Value.ToString();
            f1.txtSaying.Text = dtgInfo.Rows[r].Cells[10].Value.ToString();
            f1.cmbCourse.Text = dtgInfo.Rows[r].Cells[11].Value.ToString();
            f1.txtStatus.Text = dtgInfo.Rows[r].Cells[12].Value.ToString();

            f1.btnAdd.Visible = false;
            f1.btnUpdate.Visible = true;

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult Yes = MessageBox.Show("Are you sure you want to change the status of the selected info?", "Notice", MessageBoxButtons.YesNo);

            if (Yes == DialogResult.Yes)
            {

                Workbook book = new Workbook();
                book.LoadFromFile(@"C:\Users\ACT-STUDENT\Desktop\seyntt\EVENTDRIVE_ALEGADO\BOOKDB.xlsx");
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




                book.SaveToFile(@"C:\Users\ACT-STUDENT\Desktop\seyntt\EVENTDRIVE_ALEGADO\BOOKDB.xlsx", ExcelVersion.Version2016);

            }

        }
    }
}
