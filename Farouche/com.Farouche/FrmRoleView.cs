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
    public partial class FrmRoleView : Form
    {
        private Role _role;
        private AccessToken _accessToken;
        private String _mode = "NEW";

        public FrmRoleView(AccessToken accessToken, Role role = null)
        {
            InitializeComponent();
            _accessToken = accessToken;
            _role = role;
        }


        private void FrmRoleEdit_Load(object sender, EventArgs e)
        {
            switch (Mode)
            { 
                case "NEW":
                    roleIdTxb.Text = "New";
                    titleTxb.Text = "Enter Title";
                    descTxb.Text = "Please enter a description";
                    activeCmb.Text = "True";
                    actionBtn.Text = "Add Role";
                    break;
                case "EDIT":
                    if (_role == null)
                    {
                        throw new ArgumentNullException("Cannot edit an empty role.");
                    }
                    roleIdTxb.Text = _role.Id.ToString();
                    titleTxb.Text = _role.Name;
                    descTxb.Text = _role.Description;
                    activeCmb.Text = _role.Active.ToString();
                    actionBtn.Text = "Save";
                    break;
                default:
                    break;
            }
        }

        private void Save_Button_Click(object sender, EventArgs e)
        {
            string errorMessages = "The following errors accured:\n";
            switch (Mode)
            {
                case "NEW":
                    _role = new Role(0);
                    //TODO VALIDATION 
                    _role.Name = titleTxb.Text;
                    _role.Description = descTxb.Text;
                    _role.Active = true;
                    if (RoleManager.AddRole(_role))
                    {
                        MessageBox.Show("Role Added Successfully");
                        this.Close();
                    }
                    else 
                    {
                        MessageBox.Show("There was an error adding role.");    
                    }
                    break;
                case "EDIT":
                    if (_role.Id > 0)
                    {
                        bool valid = true;
                        if(titleTxb.Text.Length > 25)
                        {
                            valid = false;
                            errorMessages += "Title must be 25 characters or less.\n";
                        }
                        if (descTxb.Text.Length > 250)
                        {
                            valid = false;
                            errorMessages += "Description must be 250 characters or less.\n";
                        }
                        if (!valid)
                        {
                            MessageBox.Show(errorMessages);
                            break;
                        }
                        Role editedRole = new Role(_role.Id)
                        {
                            Name = titleTxb.Text,
                            Description = descTxb.Text,
                            Active = true
                        };
                        try
                        {
                            if (RoleManager.UpdateRole(editedRole, _role))
                            {
                                this.DialogResult = DialogResult.OK;
                                MessageBox.Show("Role updated");
                            }
                            else
                            {
                                MessageBox.Show("Error updating role");
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error has Occured. \n Error Message: \n" + ex.Message);
                        }
                        
                    }
                    break;
                default:
                    break;
            }
        }

        private void Cancel_Button__Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public string Mode
        {
            set { _mode = value;  }
            get { return _mode; }
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
