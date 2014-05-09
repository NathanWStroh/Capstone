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
    public partial class FrmRoles : Form
    {
        private const int EDIT = 1;
        private const int NEW = 0;
        public enum Active { No = 0, Yes = 1 };
        public static FrmRoles Instance;
        private readonly AccessToken _myAccessToken;
        private RoleManager _roleManager;
       // private List<Role> roles = new List<Role>();
        public FrmRoles(AccessToken acctoken)
        {
            InitializeComponent();
            var RoleAccess = new RoleAccess(acctoken, this);
            _roleManager = new RoleManager();
            _myAccessToken = acctoken;
           
            Instance = this;
        }


        private void FrmRoles_Load(object sender, EventArgs e)
        {
            try
            {
                fillRoleListView(RoleManager.GetAllRoles());
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

        private void FrmRoles_FormClosed(object sender, FormClosedEventArgs e)
        {
            Instance = null;
        }

        private void addRoleBtn_Click(object sender, EventArgs e)
        {
            FrmRoleView frm = new FrmRoleView(_myAccessToken);
            frm.Mode = "NEW";
            frm.ShowDialog();
            updateRoleListViewByActive(this.comboBox1.SelectedItem.ToString());
        }
        private void fillRoleListView(List<Role> roles)
        {
            roleLv.Clear();

            foreach (var role in roles)
            {
                var item = new ListViewItem();
                item.Text = role.Id.ToString();
                item.SubItems.Add(role.Name);
                item.SubItems.Add(role.Description);
                item.SubItems.Add(role.Active.ToString());
                item.Tag = role;
                roleLv.Items.Add(item);
            }
            roleLv.Columns.Add("Role ID");
            roleLv.Columns.Add("Title");
            roleLv.Columns.Add("Description");
            roleLv.Columns.Add("Active");
            roleLv.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            resetRoleButtons();
        }

        private void roleLv_SelectedIndexChanged(object sender, EventArgs e)
        {
            resetRoleButtons();
            if (roleLv.SelectedItems.Count > 0)
            {
                updateRoleButtons(GetSelectedRole().Active);
            }
        }

        private void updateRoleListViewByActive(string active)
        {
            try
            {
                switch (active)
                {
                    case "No":
                        fillRoleListView(RoleManager.GetRolesByActive(false));
                        break;
                    case "Yes":
                        fillRoleListView(RoleManager.GetRolesByActive(true));
                        break;
                    default:
                        fillRoleListView(RoleManager.GetAllRoles());
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error retriving roles");
            }
           
        }

        private void updateRoleBtn_Click(object sender, EventArgs e)
        {
            FrmRoleView frm = new FrmRoleView(_myAccessToken, GetSelectedRole());
            frm.Mode = "EDIT";
            frm.ShowDialog();
            updateRoleListViewByActive(this.comboBox1.SelectedItem.ToString());
        }

        private void activateBtn_Click(object sender, EventArgs e)
        {
            RoleManager.ActivateRole(GetSelectedRole());
            updateRoleListViewByActive(this.comboBox1.SelectedItem.ToString());
        }

        private void deactivateBtn_Click(object sender, EventArgs e)
        {
            RoleManager.DeactivateRole(GetSelectedRole());
            updateRoleListViewByActive(this.comboBox1.SelectedItem.ToString());
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateRoleListViewByActive(this.comboBox1.SelectedItem.ToString());
            resetRoleButtons();
        }

        private void roleLv_Click(object sender, EventArgs e)
        {
            resetRoleButtons();
            updateRoleButtons(GetSelectedRole().Active);
        }

        private Role GetSelectedRole()
        {
            var selectedRole = roleLv.SelectedItems[0];
            var current = (Role)selectedRole.Tag;
            return current;
        }

        private void updateRoleButtons(bool active)
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
            updateRoleBtn.Enabled = true;
        }
        private void resetRoleButtons()
        {
            activateBtn.Enabled = false;
            deactivateBtn.Enabled = false;
            updateRoleBtn.Enabled = false;
        }

        private void comboBox1_Click(object sender, EventArgs e)
        {
            resetRoleButtons();
        }
    }
}
