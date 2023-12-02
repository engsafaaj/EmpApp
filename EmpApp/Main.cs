using EmpApp.Core;
using EmpApp.Data;
using EmpApp.Data.Migrations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmpApp
{
    public partial class Main : Form
    {
        private IDataHelper<EmployeeData> dataHelper;
        public Main()
        {
            InitializeComponent();
            dataHelper = new EmpEnitty();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            EmpAddForm empAddForm = new EmpAddForm(0, this);
            empAddForm.Show();
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            int Id = Convert.ToInt32(dataGridViewEmployees.CurrentRow.Cells[0].Value);
            EmpAddForm empAddForm = new EmpAddForm(Id, this);
            empAddForm.Show();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("هل انت متأكد من هذة الاجراء", "اجراء حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                int Id = Convert.ToInt32(dataGridViewEmployees.CurrentRow.Cells[0].Value);

                EmployeeData employeeData = dataHelper.GetById(Id);
                var res = dataHelper.Delete(employeeData);
                if (res == 1)
                {
                    LoadData();
                    MessageBox.Show("تم حذف البيانات");
                }
            }


        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            if (textBoxSearch.Text != string.Empty)
            {
                Search(textBoxSearch.Text);
            }
        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            if (textBoxSearch.Text != string.Empty)
            {
                Search(textBoxSearch.Text);
            }
        }

        private void Main_Load(object sender, EventArgs e)
        {
            LoadData();
        }


        //
        public async void LoadData()
        {
            dataGridViewEmployees.DataSource = await Task.Run(() => dataHelper.GetAll());
            SetColsHeader();
        }

        private void SetColsHeader()
        {
            dataGridViewEmployees.Columns[0].HeaderText = "المعرف";
            dataGridViewEmployees.Columns[1].HeaderText = "الاسم الكامل";
            dataGridViewEmployees.Columns[2].HeaderText = "اسم الام";
            dataGridViewEmployees.Columns[3].HeaderText = "تاريخ الميلاد";
            dataGridViewEmployees.Columns[4].HeaderText = "العنوان";
            dataGridViewEmployees.Columns[5].HeaderText = "رقم الهاتف";
            dataGridViewEmployees.Columns[6].HeaderText = "البريد الالكتروني";
        }


        private async void Search(string SearchIteam)
        {
            dataGridViewEmployees.DataSource = await Task.Run(() => dataHelper.Search(SearchIteam));
        }
    }
}
