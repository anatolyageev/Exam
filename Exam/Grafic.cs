using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Exam
{
    public partial class Grafic : Form
    {

        //int startX = 0;
        //int startY = 400;

        public int EmploeeID;
        public Grafic(int EmploeeID)
        {
            this.EmploeeID = EmploeeID;
            InitializeComponent();
            Console.WriteLine("Id in chold: " + EmploeeID);
            List <Time_table> timeTable;
            
            using (HREntities db = new HREntities())
            {
                timeTable = db.Time_table.ToList();
            }

            //var result = from c in timeTable
            //             where c.ID_Employees.Equals(EmploeeID)
            //             orderby c.working_day_start
            //             select c;

            foreach (Time_table tt in timeTable)
            {
                if (tt.ID_Employees == EmploeeID)
                {
                    Console.WriteLine("tt: " + tt.ID_Employees);
                    this.chart1.Series[0].Points.AddXY(tt.working_day_start, tt.working_day_finish.Subtract(tt.working_day_start).Hours);
            }
        }
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }


       
    }
}
