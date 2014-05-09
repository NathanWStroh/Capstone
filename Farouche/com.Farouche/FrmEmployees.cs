using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using com.Farouche.BusinessLogic;
using com.Farouche.Commons;

namespace com.Farouche
{
    public partial class FrmEmployees : Form
    {
        private const int EDIT = 1;
        private const int NEW = 0;
        public enum Active { No = 0, Yes = 1 };
        public static FrmEmployees Instance;
        private readonly AccessToken _myAccessToken;
        private List<Role> _roles;
        public FrmEmployees(AccessToken acctoken)
        {
            _myAccessToken = acctoken;
            InitializeComponent();
            Instance = this;
        }


        private void FrmEmployees_Load(object sender, EventArgs e)
        {
            try
            {
                _roles = RoleManager.GetAllRoles();
                fillEmployeeListView(EmployeeManager.GetAllEmployees());
                fillActiveComboBox();
            }
            catch (Exception ex)
            {
                MessageBox.Show("There Has Been an Exception");
                Console.WriteLine(ex.Message);
                this.Close();
            }
        }

        private void fillActiveComboBox()
        {
            comboBox1.Items.Add("All");
            comboBox1.Items.Add("Yes");
            comboBox1.Items.Add("No");
            comboBox1.SelectedIndex = 0;
        }

        private void FrmEmployees_FormClosed(object sender, FormClosedEventArgs e)
        {
            Instance = null;
        }

        private void addEmployeeBtn_Click(object sender, EventArgs e)
        {
           // FrmEmployeeView frm = new FrmEmployeeView(_myAccessToken);
           // frm.Mode = "NEW";
           // frm.ShowDialog();
            FrmAddEmployee frm = new FrmAddEmployee();
            frm.ShowDialog();
            updateEmployeeListViewByActive(this.comboBox1.SelectedItem.ToString());
        }
        private void fillEmployeeListView(List<Employee> Employees)
        {
            employeeLv.Clear();

            foreach (var Employee in Employees)
            {
                Role role = _roles.First(c => c.Id == Employee.RoleID);

                var item = new ListViewItem();
                item.Text = Employee.Id.ToString();
                item.SubItems.Add(role != null ? role.Name : "");
                item.SubItems.Add(Employee.FirstName);
                item.SubItems.Add(Employee.LastName);
                item.SubItems.Add(Employee.PhoneNumber);
                item.SubItems.Add(Employee.Active.ToString());
                item.Tag = Employee;
                employeeLv.Items.Add(item);
            }
            employeeLv.Columns.Add("Employee ID");
            employeeLv.Columns.Add("Role");
            employeeLv.Columns.Add("First Name");
            employeeLv.Columns.Add("Last Name ");
            employeeLv.Columns.Add("Phone Number");
            employeeLv.Columns.Add("Active");
            employeeLv.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            resetEmployeeButtons();
        }

        private void employeeLv_SelectedIndexChanged(object sender, EventArgs e)
        {
            resetEmployeeButtons();
            if (employeeLv.SelectedItems.Count > 0)
            {
                updateEmployeeButtons(GetSelectedEmployee().Active);
            }
        }

        private void updateEmployeeListViewByActive(string active)
        {
            try
            {
                switch (active)
                {
                    case "No":
                        fillEmployeeListView(EmployeeManager.GetEmployeesByActive(false));
                        break;
                    case "Yes":
                        fillEmployeeListView(EmployeeManager.GetEmployeesByActive(true));
                        break;
                    default:
                        fillEmployeeListView(EmployeeManager.GetAllEmployees());
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error retriving Employees");
            }
           
        }

        private void activateBtn_Click(object sender, EventArgs e)
        {
            EmployeeManager.Activate(GetSelectedEmployee());
            updateEmployeeListViewByActive(this.comboBox1.SelectedItem.ToString());
        }

        private void deactivateBtn_Click(object sender, EventArgs e)
        {
            EmployeeManager.Deactivate(GetSelectedEmployee());
            updateEmployeeListViewByActive(this.comboBox1.SelectedItem.ToString());
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateEmployeeListViewByActive(this.comboBox1.SelectedItem.ToString());
            resetEmployeeButtons();
        }

        private Employee GetSelectedEmployee()
        {
            var selectedEmployee = employeeLv.SelectedItems[0];
            var current = (Employee)selectedEmployee.Tag;
            return current;
        }

        private void updateEmployeeButtons(bool active)
        {

            if (active)
            {
                activateBtn.Enabled = false;
                deactivateBtn.Enabled = true;
            }
            else 
            { 
                activateBtn.Enabled = true;
                deactivateBtn.Enabled = false;
            }
            updateEmployeeBtn.Enabled = true;
        }
        private void resetEmployeeButtons()
        {
            activateBtn.Enabled = false;
            deactivateBtn.Enabled = false;
            updateEmployeeBtn.Enabled = false;
        }

        private void comboBox1_Click(object sender, EventArgs e)
        {
            resetEmployeeButtons();
        }

        private void employeeLv_Click(object sender, EventArgs e)
        {
            resetEmployeeButtons();
            updateEmployeeButtons(GetSelectedEmployee().Active);
        }

        private void updateEmployeeBtn_Click(object sender, EventArgs e)
        {
            //Open Employee form
            //frm.Mode = "EDIT";
            //frm.ShowDialog();
            updateEmployeeListViewByActive(this.comboBox1.SelectedItem.ToString());
        }
    }
}
