using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using com.Farouche.Commons;
using com.Farouche.BusinessLogic;

namespace com.Farouche
{
    public partial class FrmAddEmployee : Form
    {
        private List<Role> _roleList;

        public FrmAddEmployee()
        {
            InitializeComponent();
            PopulateActiveCombo();
            PopulateRoleCombo();
        }

        //Populates the active combo and sets the appropriate index based off of what function the user is performing.
        private void PopulateActiveCombo()
        {
            Active active;
            var index = 0;
            for (int i = 1; i >= 0; i--)
            {
                active = (Active)i;
                this.cbActive.Items.Add(active);
            }
            this.cbActive.SelectedIndex = index;
        }//End of populateActiveCombo()

        //Populates role combo box.
        private void PopulateRoleCombo()
        {
            Dictionary<int, String> rolesDictionary = new Dictionary<int, string>();
            _roleList = RoleManager.GetRolesByActive(true);
            foreach (var role in _roleList)
            {
                rolesDictionary.Add(role.Id, role.Name);
            }
            cbRole.DataSource = new BindingSource(rolesDictionary, null);
            cbRole.DisplayMember = "Value";
            cbRole.ValueMember = "Key";
            this.cbRole.SelectedIndex = 0;
        }

        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            Employee newEmployee;
            bool validEmployee = true;
            string errorMessage = "Please correct the following errors:\n";
            if (txtPassword.TextLength > 50)
            {
                validEmployee = false;
                errorMessage += "\nThe password must not exceed 50 characters.";
                txtPhone.Focus();
            }
            if (Validation.IsNullOrEmpty(txtPassword.Text) || Validation.IsBlank(txtPassword.Text))
            {
                validEmployee = false;
                errorMessage += "\nPlease enter a password.";
                txtPassword.Focus();
            }
            if (txtPhone.TextLength > 14)
            {
                validEmployee = false;
                errorMessage += "\nThe phone number must not exceed 14 characters.";
                txtPhone.Focus();
            }
            if (Validation.IsNullOrEmpty(txtPhone.Text) || Validation.IsBlank(txtPhone.Text))
            {
                validEmployee = false;
                errorMessage += "\nPlease enter a phone number.";
                txtPhone.Focus();
            }
            if (txtLName.TextLength > 25)
            {
                validEmployee = false;
                errorMessage += "\nThe last name must not exceed 25 characters.";
                txtLName.Focus();
            }
            if (Validation.IsNullOrEmpty(txtLName.Text) || Validation.IsBlank(txtLName.Text))
            {
                validEmployee = false;
                errorMessage += "\nPlease enter a last name.";
                txtLName.Focus();
            }
            if (txtFName.TextLength > 25)
            {
                validEmployee = false;
                errorMessage += "\nThe first name must not exceed 25 characters.";
                txtFName.Focus();
            }
            if (Validation.IsNullOrEmpty(txtFName.Text) || Validation.IsBlank(txtFName.Text))
            {
                validEmployee = false;
                errorMessage += "\nPlease enter a first name.";
                txtFName.Focus();
            }
            if (validEmployee)
            {
                newEmployee = new Employee()
                {
                    FirstName = txtFName.Text,
                    LastName = txtLName.Text,
                    PhoneNumber = txtPhone.Text,
                    RoleID = ((KeyValuePair<int, string>)cbRole.SelectedItem).Key,
                    Active = Convert.ToBoolean(cbActive.SelectedItem)
                };
                if (EmployeeManager.Add(newEmployee, txtPassword.Text))
                {
                    this.DialogResult = DialogResult.OK;
                    MessageBox.Show("The employee was created.");
                }
                else
                {
                    MessageBox.Show("The employee was not created.");
                }
            }
            else
            {
                MessageBox.Show(errorMessage);
            }
        }

        private void btnClear_Click_1(object sender, EventArgs e)
        {
            txtFName.Text = "";
            txtLName.Text = "";
            txtPassword.Text = "";
            txtPhone.Text = "";
            cbActive.SelectedIndex = 0;
            cbRole.SelectedIndex = 0;
        }
    }
}
