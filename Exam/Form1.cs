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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            List<Employee> employees;
            Employee em = new Employee();
            using (HREntities db = new HREntities())
            {
                employees = db.Employees.ToList();
            }

            comboBox1.DataSource = employees;
            comboBox1.DisplayMember = "ID";
            comboBox1.ValueMember = "ID";

        }

     

        private void GetAllEmployees()
        {
            dataGridView1.Rows.Clear();
            dataGridView1.ColumnCount = 4;
            dataGridView1.ColumnHeadersVisible = true;

            // Set the column header style.
            DataGridViewCellStyle columnHeaderStyle = new DataGridViewCellStyle();

            columnHeaderStyle.BackColor = Color.Beige;
            columnHeaderStyle.Font = new Font("Verdana", 10, FontStyle.Bold);
            dataGridView1.ColumnHeadersDefaultCellStyle = columnHeaderStyle;
            dataGridView1.Columns[0].Name = "ID";
            dataGridView1.Columns[1].Name = "NAME";
            dataGridView1.Columns[2].Name = "SURNAME";
            dataGridView1.Columns[3].Name = "PHOTO";

            List<Employee> employees;
            Employee em = new Employee();
            using (HREntities db = new HREntities())
            {
                employees = db.Employees.ToList();
                foreach (Employee st in employees)
                {
                    dataGridView1.Rows.Add(st.ID, st.NAME, st.SURNAME, st.Work_hystory.ElementAt(0).Photo);
                }
            }
        }

        private void AllEmploees_Click(object sender, EventArgs e)
        {
            GetAllEmployees();
        }

        private void grafic_Click(object sender, EventArgs e)
        {
            Grafic f = new Grafic((int)comboBox1.SelectedValue);
            Console.WriteLine("Id from oaret: " + (int)comboBox1.SelectedValue);
            f.ShowDialog();
           
        }
    }
}
