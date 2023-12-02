using EmpApp.Core;
using EmpApp.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace EmpApp
{
    public partial class EmpAddForm : Form
    {
        private int Id;
        private readonly Main main;
        private IDataHelper<EmployeeData> dataHelper;
        public EmpAddForm(int id, Main main)
        {
            InitializeComponent();
            Id = id;
            this.main = main;
            dataHelper = new EmpEnitty();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            // Check TextBox
            if (IsValid())
            {
                Save();
            }
            else
            {
                MessageBox.Show("اكمل متطلبات الادخال");

            }
        }
        private bool IsValid()
        {
            if (textBoxEmpName.Text != string.Empty ||
                textBoxMotherName.Text != string.Empty ||
                textBoxAddress.Text != string.Empty
                )
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void Save()
        {
            // Add
            if (Id == 0)
            {
                EmployeeData employeeData = new EmployeeData
                {
                    FullName = textBoxEmpName.Text,
                    MotherName = textBoxMotherName.Text,
                    Address = textBoxAddress.Text,
                    Phone = textBoxPhone.Text,
                    Birthday = dateTimePickerEmpBirthday.Value.Date,
                    Email = textBoxEmail.Text,
                };

                var result = dataHelper.Add(employeeData);
                if (result == 1)
                {
                    main.LoadData();
                    MessageBox.Show("تمت الاضافة بنجاح");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("لم نتمكن من اضافة البيانات");
                }
            }
            else
            {
                // Edit
                EmployeeData employeeData = new EmployeeData
                {
                    FullName = textBoxEmpName.Text,
                    MotherName = textBoxMotherName.Text,
                    Address = textBoxAddress.Text,
                    Phone = textBoxPhone.Text,
                    Birthday = dateTimePickerEmpBirthday.Value.Date,
                    Email = textBoxEmail.Text,
                    Id = Id
                };

                var result = dataHelper.Update(employeeData);
                if (result == 1)
                {
                    main.LoadData();

                    MessageBox.Show("تم التعديل بنجاح");

                    this.Close();
                }
                else
                {
                    MessageBox.Show("لم نتمكن من تعديل البيانات");
                }
            }
        }

        private void SetDataForEdit()
        {
            EmployeeData employeeData = dataHelper.GetById(Id);
            if (employeeData != null)
            {
                textBoxEmpName.Text = employeeData.FullName;
                textBoxMotherName.Text = employeeData.MotherName;
                textBoxAddress.Text = employeeData.Address;
                textBoxPhone.Text = employeeData.Phone;
                dateTimePickerEmpBirthday.Value = employeeData.Birthday;
                textBoxEmail.Text = employeeData.Email;
            }

        }

        private void EmpAddForm_Load(object sender, EventArgs e)
        {
            if (Id > 0)
            {
                SetDataForEdit();
            }
        }
    }
}
