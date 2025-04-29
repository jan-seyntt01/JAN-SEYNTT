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
    public partial class Form4 : Form
    {
        Form2 f2 = new Form2();
        
        public Form4()
        {
            InitializeComponent();
            lblActiveCount.Text = showCount(13, "1").ToString();
            lblMaleCount.Text = showCount(2, "Male").ToString();
            lblInactiveCount.Text = showCount(13, "0").ToString();
            lblFemaleCount.Text = showCount(2, "Female").ToString();
        }
       
        public int showCount(int c, string field)
        {
            Workbook book = new Workbook();
            book.LoadFromFile(@"C:\Users\ACT-STUDENT\Desktop\SEYNTT\EVENTDRIVE_ALEGADO\BOOKDB.xlsx");
            Worksheet sh = book.Worksheets[0];
            int counter = 0;
            int row = sh.Rows.Length;
            for (int i = 2; i <= row; i++)
            {
                if (sh.Range[i, c].Value == field)
                {
                    counter++;
                }
            }
            return counter;
        }


        private void btnNew_Click(object sender, EventArgs e)
        {
            Form1 info = new Form1();
            info.Show();
        }

        private void btnActiveStatus_Click(object sender, EventArgs e)
        {
            f2.showStudent("1");
            f2.Show();
        }

        private void btnInactiveStatus_Click(object sender, EventArgs e)
        {
            f2.showStudent("0");
            f2.Show();
        }

        private void btnLogs_Click(object sender, EventArgs e)
        {
            f2.loadLogs();
            f2.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Mylogs mylogs = new Mylogs();
            Form3 f3 = new Form3();
            DialogResult Yes = MessageBox.Show("Are you sure you want to logout?", "Notice", MessageBoxButtons.YesNo);
            if (Yes == DialogResult.Yes)
            {
                f3.Show();
            }
            
            this.Hide();
        }
    }
}
