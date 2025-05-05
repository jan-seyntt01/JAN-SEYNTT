using Spire.Xls;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EVENTDRIVE_ALEGADO
{
    class Mylogs
    {
        Workbook book = new Workbook();
        public void insertLogs(string user, string message)
        {
            book.LoadFromFile(@"C:\Users\ACT-STUDENT\Desktop\seyntt\EVENTDRIVE_ALEGADO\BOOKDB.xlsx");
            Worksheet sh = book.Worksheets[1];
            int row = sh.Rows.Length + 1;
            sh.Range[row, 1].Value = user;
            sh.Range[row, 2].Value = message;
            sh.Range[row, 3].Value = DateTime.Now.ToString("MM/dd/yyyy");
            sh.Range[row, 4].Value = DateTime.Now.ToString("hh:mm:ss tt");
            book.SaveToFile(@"C:\Users\ACT-STUDENT\Desktop\seyntt\EVENTDRIVE_ALEGADO\BOOKDB.xlsx");
        }
        public void showLogs(DataGridView d)
        {
            Workbook book = new Workbook();
            book.LoadFromFile(@"C:\Users\ACT-STUDENT\Desktop\seyntt\EVENTDRIVE_ALEGADO\BOOKDB.xlsx");
            Worksheet sh = book.Worksheets[1];
            DataTable dt = sh.ExportDataTable();
            d.DataSource = dt;
        }
    }
}
