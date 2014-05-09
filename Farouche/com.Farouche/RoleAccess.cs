using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using com.Farouche.Commons;
using com.Farouche.BusinessLogic;
using System.ComponentModel;

namespace com.Farouche
{
    public class RoleAccess
    {
        private List<Control> _controls;
        private List<RoleControl> _editingRoleControls;
        private string _formName;
        private List<RoleControl> _accessControls;
        private Boolean editing = false;
        private Control _currentForm;
        private MenuStrip _roleMenuStrip;
        private RoleControl _currentControl;
        private Boolean _madeChanges = false;
        private int _currentRoleID;

        public RoleAccess(AccessToken accessToken, Control form)
        {
            try
            {
                _controls = GetControls(form);
                _formName = form.Name;
                _currentForm = form;
                _accessControls = accessToken.Role.Controls;
                if (accessToken.Role.Id == 1000)
                {
                    AddEditRoleMenuStrip();
                }
                HasAccess();
            }
            catch (Exception)
            {
                throw new ApplicationException("Error setting up role access");
            }
        }

        private void AddEditRoleMenuStrip()
        {
            _roleMenuStrip = new MenuStrip();
            var editRoleItem = new ToolStripMenuItem("Edit Roles");
            var saveItem = new ToolStripMenuItem("Save");
            saveItem.Enabled = false;
            saveItem.ToolTipText = "Save changes to role";
            _roleMenuStrip.Items.Add(editRoleItem);
            _roleMenuStrip.Items.Add(saveItem);
            _currentForm.Controls.Add(_roleMenuStrip);
            editRoleItem.Click += new System.EventHandler(editRoles_Click);
            saveItem.Click += new System.EventHandler(saveItem_Click);
        }
        private void PopupContextMenu(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                if (editing == false)
                {

                    ContextMenuStrip roleMenu = new ContextMenuStrip();
                    String controlName;
                    if (sender is ToolStripMenuItem)
                    {
                        var toolStrip = (ToolStripMenuItem)sender;
                        controlName = toolStrip.Name;
                    }
                    else
                    {
                        var c = (Control)sender;
                        controlName = c.Name;
                    }

                    var foundControl = _editingRoleControls.Where(c => c.FormName == _formName && c.Name == controlName);
                    if (foundControl.Count() > 0)
                    {
                        foreach (var controlAccess in foundControl)
                        {
                            Console.WriteLine(controlName);
                            roleMenu.Items.Add(controlName);
                            roleMenu.Items.Add("-");
                            roleMenu.Items.Add(!controlAccess.Disabled ? "Disable" : "Enable", null, new System.EventHandler(enable_click));
                            roleMenu.Items.Add(controlAccess.Visible ? "Hide" : "Show", null, new System.EventHandler(visible_click));
                            _currentControl = controlAccess;
                            _currentControl.RoleID = _currentRoleID;
                            _currentControl.status = "UPDATE";
                        }
                    }
                    else
                    {
                        Console.WriteLine(controlName);
                        roleMenu.Items.Add(controlName);
                        roleMenu.Items.Add("-");
                        roleMenu.Items.Add("Disable", null, new System.EventHandler(enable_click));
                        roleMenu.Items.Add("Hide", null, new System.EventHandler(visible_click));
                        _currentControl = new RoleControl() {Name = controlName, FormName = _formName, Disabled = false, Active = true, Visible = true,  RoleID = _currentRoleID,status = "NEW"};
                    }
                    if (sender is ToolStripMenuItem)
                    {
                        roleMenu.Show(Cursor.Position);
                    }
                    else
                    {
                        roleMenu.Show((Control)sender, e.Location);
                    }
                   
                }
            }
        }
        private List<Control> GetControls(Control form)
        {
            var controls = new List<Control>();

            foreach (Control childControl in form.Controls)
            {
                controls.AddRange(GetControls(childControl));
                controls.Add(childControl);
            }
            return controls;
        }

        public List<Control> Controls
        {
            get { return _controls; }
        }

        private void UpdateControl(Control control)
        {
            var foundControl = _accessControls.Where(c => c.FormName == _formName && c.Name == control.Name);
            foreach (var controlAccess in foundControl)
            {
                control.Enabled = !controlAccess.Disabled;
                control.Visible = controlAccess.Visible;
            }
        }

        private void UpdateItem(ToolStripMenuItem item)
        {
            var foundControl = _accessControls.Where(c => c.FormName == _formName && c.Name == item.Name);
            foreach (var controlAccess in foundControl)
            {
                item.Enabled = !controlAccess.Disabled;
                item.Visible = controlAccess.Visible;
            }
        }

        private void HasAccess()
        {
            foreach (var control in _controls)
            {
                if (control is MenuStrip)
                {
                    UpdateControl(control);
                    var menuStrip = (MenuStrip)control;
                    foreach (var item in menuStrip.Items)
                    {
                        var itemControl = (ToolStripMenuItem)item;
                        UpdateItem(itemControl);
                    }
                }
                else 
                {
                    UpdateControl(control);
                }

            }
        }
        private void enable_click(object sender, EventArgs e)
        {
            if (!_madeChanges)
            {
                _madeChanges = true;
                _roleMenuStrip.Items[1].Enabled = true;
            }
            _currentControl.Disabled = !_currentControl.Disabled;
            if (!_editingRoleControls.Contains(_currentControl))
            {
                 _editingRoleControls.Add(_currentControl);
            }
        }
        private void visible_click(object sender, EventArgs e)
        {
            _madeChanges = true;
            _roleMenuStrip.Items[1].Enabled = true;
            _currentControl.Visible = !_currentControl.Visible;
            if (!_editingRoleControls.Contains(_currentControl))
            {
                _editingRoleControls.Add(_currentControl);
            }
        }
        private void saveItem_Click(object sender, EventArgs e)
        {
            if (_madeChanges)
            {
                if (RoleManager.ProcessControls(_editingRoleControls))
                {
                    MessageBox.Show("Changes Saved");
                    _roleMenuStrip.Items[1].Enabled = false;
                }
                else {
                    MessageBox.Show("There was an unknown error saving your changes");
                }
            }
            else {
                MessageBox.Show("No changes have been made.");
                _roleMenuStrip.Items[1].Enabled = false;
            }
        
        }
        private void editRoles_Click(object sender, EventArgs e)
        {
            using (var frmRoleDialog = new FrmRoleDialog())
            {
                var result = frmRoleDialog.ShowDialog();
                if (result == DialogResult.OK)
                {
                    _editingRoleControls = RoleManager.GetControlsByRole(frmRoleDialog.SelectedRole.Id);
                    _currentRoleID = frmRoleDialog.SelectedRole.Id;
                    foreach (var control in _controls)
                    {
                        if (control is MenuStrip)
                        {
                            var menuStrip = (MenuStrip)control;
                            menuStrip.Enabled = true;
                            menuStrip.Visible = true;
                            menuStrip.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PopupContextMenu);
                            foreach (var item in menuStrip.Items)
                            {
                                var itemControl = (ToolStripMenuItem)item;
                                itemControl.Enabled = true;
                                itemControl.Visible = true;
                                itemControl.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PopupContextMenu);

                            }
                        }
                        else
                        {
                            if (control is Button || control is ComboBox || control is TextBox ||
                                control is ListBox || control is DataGridView || control is RadioButton ||
                                control is RichTextBox || control is TabPage || control is ListView)
                            {
                                RemoveEvents(control);
                                control.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PopupContextMenu);
                                control.Enabled = true;
                                control.Visible = true;
                            }
                        }
                    }
                    _roleMenuStrip.Items[0].Text = "Editing " + frmRoleDialog.SelectedRole.Name + " Role";
                    _currentForm.Text = "Admin Edit Mode Enabled";
                }
            }
        }
        private void RemoveEvents(Control control)
        { 
              EventHandlerList list = (EventHandlerList) typeof(Control).GetProperty("Events", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).GetValue(control, null);
              typeof(EventHandlerList).GetMethod("Dispose").Invoke(list, null);
        }
    }
}
