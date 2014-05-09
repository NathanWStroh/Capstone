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
    public partial class FrmRoleDialog : Form
    {
        public Role SelectedRole;
        private List<Role>_activeRoles;
        public FrmRoleDialog(AccessToken _myAccessToken)
        {
            var RoleAccess = new RoleAccess(_myAccessToken, this);
            InitializeComponent();
            FillRolesComboBox();
        }
        public void FillRolesComboBox()
        {
            _activeRoles = RoleManager.GetRolesByActive(true);
            roleCmb.DataSource = _activeRoles;
            roleCmb.ValueMember = "ID";
            roleCmb.DisplayMember = "Name";
        }

        private void roleCmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedRole = _activeRoles.First(role => role.Id == (int)roleCmb.SelectedValue);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
