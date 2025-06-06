﻿using Spire.Xls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EVENTDRIVE_ALEGADO
{
    public partial class Form4 : Form
    {
        Form2 f2 = new Form2();
        Workbook book = new Workbook();

        public Form4()
        {
            InitializeComponent();
            if (!string.IsNullOrEmpty(DisplayIt.ProfilePath) && File.Exists(DisplayIt.ProfilePath))
            {
                picPicture.Image = Image.FromFile(DisplayIt.ProfilePath);
                picPicture.Image = Image.FromFile(DisplayIt.ProfilePath);
                picPicture.SizeMode = PictureBoxSizeMode.StretchImage; // Set the SizeMode to StretchImage
            }

            lblActiveCount.Text = showCount(13, "1").ToString();
            lblMaleCount.Text = showCount(2, "Male").ToString();
            lblInactiveCount.Text = showCount(13, "0").ToString();
            lblFemaleCount.Text = showCount(2, "Female").ToString();
            lblRedCount.Text = showCount(10, "Red").ToString();
            lblYellowCount.Text = showCount(10, "Yellow").ToString();
            lblBlueCount.Text = showCount(10, "Blue").ToString();
            lblOrangeCount.Text = showCount(10, "Orange").ToString();
            lblGreenCount.Text = showCount(10, "Green").ToString();
            lblPurpleCount.Text = showCount(10, "Purplw").ToString();
            lblBlackCount.Text = showCount(10, "Black").ToString();
            lblBasketballCount.Text = showCount(9, "Basketball").ToString();
            lblVolleyballCount.Text = showCount(9, "Volleyball").ToString();
            lblSoccerCount.Text = showCount(9, "Soccer").ToString();
            lblBSITCount.Text = showCount(12, "BSIT").ToString();
            lblBEEDCount.Text = showCount(12, "BEED").ToString();
            lblBSCSCount.Text = showCount(12, "BSCS").ToString();
            lblBSCPECount.Text = showCount(12, "BSCPE").ToString();
            lblBSHMCount.Text = showCount(12, "BSHM").ToString();
            lblBSTMCount.Text = showCount(12, "BSTM").ToString();

            lblDate.Text = DateTime.Now.ToString("MM/dd/yyyy");
            lblProfileName.Text = DisplayIt.DisplayName;
        }
       
        public int showCount(int c, string field)
        {
            Workbook book = new Workbook();
            book.LoadFromFile(@"C:\Users\Computer\Desktop\EVENTDRIVEN\sint\EVENTDRIVE_ALEGADO\BOOKDB.xlsx");
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
            Mylogs logs = new Mylogs();
            logs.insertLogs(DisplayIt.CurrentUser, "Logged Out.");
            Form3 frm3 = new Form3();
            frm3.Show();
            this.Hide();
            //Mylogs mylogs = new Mylogs();
            //Form3 f3 = new Form3();
            //DialogResult Yes = MessageBox.Show("Are you sure you want to logout?", "Notice", MessageBoxButtons.YesNo);
            //if (Yes == DialogResult.Yes)
            //{
            //    f3.Show();
            //}

            //this.Hide();
        }
    }
}
