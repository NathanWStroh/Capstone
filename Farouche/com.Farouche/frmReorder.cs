using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Forms;
using com.Farouche.BusinessLogic;
using com.Farouche.Commons;

namespace com.Farouche
{
    public partial class frmReorder : Form
    {
        private readonly AccessToken _myAccessToken;
        private VendorManager _vendorManager;
        private ProductManager _productManager;
        private ReorderManager _report;
        public static frmReorder Instance;        
        private Boolean dgvBool = false;    //Boolean used to determine if the dgv has been populated or not.
        private Boolean cbCanClick = false; //Hack: makes sure cellValuechanged Event wont run calcAmount function at odd times.
        private Boolean _vendorOrdered = true; //used to check if current Vendor Order has been ordered before moving to new Vendor Order
        private Boolean devState = true;
        private List<Reorder> lreport;
        //Constructor with AccessToken as the only parameter.
        public frmReorder(AccessToken acctoken)
        {
            var RoleAccess = new RoleAccess(acctoken, this);
            InitializeComponent();
            _myAccessToken = acctoken;
            Instance = this;
        }

        private void frmReorder_Load(object sender, EventArgs e)
        {
            var venManager = new VendorManager();
            fillVendorsComboBox();        
        }      

        //populates Vendor Combobox with list of Vendors 
        private void fillVendorsComboBox()
        {
            _vendorManager = new VendorManager();
            List<Vendor> lVendors = new List<Vendor>();
            lVendors = _vendorManager.GetVendors();
            cbVendors.DataSource = lVendors;
            cbVendors.DisplayMember = "Name";
            cbVendors.ValueMember = "ID";
            cbVendors.SelectedIndex = 0;
        }

        //populates the "Reorder Amount" ComboBox's Cell per row/Column 4
        private void populate_dgvROComboBox(int _reorderAmount, DataGridViewComboBoxCell cb)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("reorderAmount");
            int _orderAmount = _reorderAmount;
            for (int i = 1; i < 5; i++)
            {
                dt.Rows.Add(_reorderAmount * i);
            }
            cb.DataSource = dt;
            cb.ValueMember = "reorderAmount";
            cb.DisplayMember = "reorderAmount";
           
        }
        //populates the "Product" ComboBoxColumn with a list of Products
        private void populateNewLineProductComboBox(DataGridViewComboBoxColumn cb)
        {
            cb.Items.Clear();
            var unorderProducts = new List<Reorder>();
            var _unordered = new ReorderManager(unorderProducts);
            unorderProducts = _unordered.GetReordersForVendor((int)cbVendors.SelectedValue, 1);
            foreach (Reorder product in unorderProducts)
            {
                cb.Items.Add(product.Product.Name);
            }
        }

        //populates datagridview = dgvReord
        private void populateDataGridView(int vendor)
        {
            ReorderManager _reportNull = new ReorderManager(new List<Reorder>());

            //  0 will return all products that are under the reorderthreshold
            lreport = _reportNull.GetReordersForVendor(vendor, 0);
            
            _report = new ReorderManager(lreport);
            populateDGV();
        }

        //EventHandler for clicking on a new line of the "Product" Column
        private void dgvReorder_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == dgvReorder.Rows.Count - 1)
            {
                dgvReorder.Rows[e.RowIndex].Cells[0].ReadOnly = true;
                dgvReorder.Rows[e.RowIndex].Cells[1].ReadOnly = false;
            }
        }

        //EventArg for dgv ComboBox statechange
        private void dgvReorder_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dgvReorder.CurrentCell.ColumnIndex == 4)
            {
             
                ComboBox cb = e.Control as ComboBox;
                if (null != cb)
                {
                cb.SelectedIndexChanged += new EventHandler(dgvComboBox_SelectedIndexChanged);
                }
            }
            else if (dgvReorder.CurrentCell.ColumnIndex == 1 & dgvReorder.CurrentRow.IsNewRow)
            {
                ComboBox cbm = e.Control as ComboBox;
                if (null != cbm)
                {
                    dgvReorder.CurrentCell.ReadOnly = false;
                    cbm.SelectedIndexChanged += new EventHandler(dgvComboBox_SelectedIndexChanged);
                }
            }
        }
        //EventArg for ComboBox SelectedIndexChanged     
        private void dgvComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
            try
            {
                if (dgvReorder.CurrentRow.IsNewRow)
                {
                    if (cb.SelectedIndex >= 0 & dgvReorder.CurrentRow.Cells[1].ReadOnly == false)
                    {

                        try
                        {
                            var valid = true;
                            foreach (var _curProduct in _report.Reorders)
                            {
                                if (_curProduct.Product.Name == cb.SelectedItem.ToString())
                                {
                                    MessageBox.Show("That Product has already been added.", "Error",
                                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    valid = false;
                                    break;
                                }
                            }
                            if (valid)
                            {
                                var _product = _report.GetProductToReorder(cb.SelectedItem.ToString());
                                _report.AddNewLineItem(_product.Product, _product.VendorSourceItem, (int)_product.Product._reorderAmount);
                                _product.CasesToOrder = (int)_product.Product._reorderAmount;
                                _report.AddToOrder(_product);
                                _product.ReorderTotal = _report.UpdateReorderAmount(_product, _product.CasesToOrder);
                                dgvReorder.CurrentRow.Cells[0].Value = _product.ShouldReorder;
                                dgvReorder.CurrentRow.Cells[1] = new DataGridViewTextBoxCell();
                                dgvReorder.CurrentRow.Cells[1].Value = _product.Product.Name;
                                dgvReorder.CurrentRow.Cells[2].Value = _product.VendorSourceItem.UnitCost;
                                dgvReorder.CurrentRow.Cells[3].Value = _product.Product._reorderThreshold;
                                populate_dgvROComboBox((int)_product.Product._reorderAmount, (DataGridViewComboBoxCell)dgvReorder.CurrentRow.Cells[4]);
                                dgvReorder.CurrentRow.Cells[5].Value = _product.ReorderTotal;
                                dgvReorder.CurrentRow.Cells[0].ReadOnly = false;
                                dgvReorder.CurrentRow.Cells[1].ReadOnly = true;
                                txtTotalAmount.Text = _report.GetReportTotal().ToString("C2");                                
                            }
                        }
                        catch (ApplicationException ex) { MessageBox.Show(ex.Message); }

                    }
                }
                else if (null != cb | cb.SelectedIndex != -1 & (bool)dgvReorder.CurrentRow.Cells[0].Value == true)
                {
                    foreach (var product in _report.Reorders)
                    {
                        if (product.Product.Name == dgvReorder.CurrentRow.Cells[1].Value.ToString())
                        {
                            var _reorderAmount = 0;
                            int.TryParse(cb.SelectedValue.ToString(), out _reorderAmount);
                            var _updatedRowTotal = _report.UpdateReorderAmount(product, _reorderAmount);
                            dgvReorder.CurrentRow.Cells[5].Value = _updatedRowTotal;
                            product.ReorderTotal = _updatedRowTotal;
                            txtTotalAmount.Text = _report.GetReportTotal().ToString("C2");
                        }
                    }
                } //end outer if else  
            }
            catch (NullReferenceException ex)
            {
                // MessageBox.Show("Stop clicking things so quickly!"); 
            }
            cb.SelectedIndexChanged -= dgvComboBox_SelectedIndexChanged;
        }

        //EventArg for the Checkbox Column to update txtTotalAmount on StateChange
        private void dgvReorder_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 & cbCanClick == true & dgvReorder.CurrentRow.Cells[1].Value != null)
           {
               if ((bool)dgvReorder.CurrentRow.Cells[0].Value == true)
               {
                   foreach (var product in _report.Reorders)
                   {
                       if (product.Product.Name == dgvReorder.CurrentRow.Cells[1].Value.ToString())
                       {
                           product.ShouldReorder = true;
                           dgvReorder.CurrentRow.Cells[5].Value = product.ReorderTotal;
                           txtTotalAmount.Text = _report.GetReportTotal().ToString("C2");
                           dgvReorder.CurrentRow.DefaultCellStyle.BackColor = Color.White;
                       }
                   }
               }
               else if ((bool)dgvReorder.CurrentRow.Cells[0].Value == false)
               {
                   foreach (var product in _report.Reorders)
                   {
                       if (product.Product.Name == dgvReorder.CurrentRow.Cells[1].Value.ToString())
                       {
                           product.ShouldReorder = false;
                           dgvReorder.CurrentRow.Cells[5].Value = 0;
                           txtTotalAmount.Text = _report.GetReportTotal().ToString("C2");
                           dgvReorder.CurrentRow.DefaultCellStyle.BackColor = Color.Gray;
                       }
                   }
               }
           }          
        }

        //EventArg for the Checkbox Column to update txtTotalAmount on StateChange
        private void dgvReorder_CurrentCellDirtyChanged(object sender, EventArgs e)
        {
            if (dgvReorder.IsCurrentCellDirty)
            {
                dgvReorder.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }       

        //populates each row of the Datagridview
        private void populateDGV()
        {
            cbCanClick = false; //HACK
            dgvReorder.Rows.Clear();
            //users unable to add Products until report has been run.
            dgvReorder.AllowUserToAddRows = true;

            foreach (Reorder product in _report.Reorders)
            {
                int n = dgvReorder.Rows.Add();
                dgvReorder.Rows[n].Cells[0].Value = product.ShouldReorder;
               
                //replaces the ComboboxCell with a textbox so user is unable to change product for that row.
                DataGridViewTextBoxCell tbc = new DataGridViewTextBoxCell();
                dgvReorder[1, n] = tbc;
                dgvReorder.Rows[n].Cells[1].Value = product.Product.Name;
                dgvReorder.Rows[n].Cells[1].ReadOnly = true;
                dgvReorder.Rows[n].Cells[2].Value = product.VendorSourceItem.UnitCost;
                dgvReorder.Rows[n].Cells[3].Value = product.Product._reorderThreshold;
                populate_dgvROComboBox((int)product.Product._reorderAmount, (DataGridViewComboBoxCell)this.dgvReorder.Rows[n].Cells[4]);
                if (product.ShouldReorder)
                {
                    dgvReorder.Rows[n].Cells[5].Value = product.ReorderTotal;
                }
                else
                {
                    dgvReorder.Rows[n].Cells[5].Value = 0;
                }
            }
            //C2 converts it to US currency
            txtTotalAmount.Text = _report.GetReportTotal().ToString("C2");

            // populates the ComboBox Column for "Products"
            populateNewLineProductComboBox((DataGridViewComboBoxColumn)dgvReorder.Columns[1]);
            
            //adding EventHandlers to the DataGridView
            cbCanClick = true; //HACK
            dgvReorder.CellClick += new DataGridViewCellEventHandler(dgvReorder_CellClick);
            dgvReorder.EditingControlShowing += new DataGridViewEditingControlShowingEventHandler(dgvReorder_EditingControlShowing);
            dgvReorder.CurrentCellDirtyStateChanged += new EventHandler(dgvReorder_CurrentCellDirtyChanged);
            dgvReorder.CellValueChanged += new DataGridViewCellEventHandler(dgvReorder_CellValueChanged);
        }


        //Button methods
        //makes a call to populate the dgv
        private void btnGo_Click(object sender, EventArgs e)
        {
            try
            {
                //_vendorOrdered is used to determine if the current Order has been sent out.
                if (_vendorOrdered)
                {
                    populateDataGridView((int)cbVendors.SelectedValue);
                }
                else
                {
                    DialogResult result = MessageBox.Show("You are about to start a new Vendor Order without Saving your current Order, would you like to Proceed?",
                        "Vendor Reorder", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    switch (result)
                    {
                        case DialogResult.Yes:
                            populateDataGridView((int)cbVendors.SelectedValue);
                            break;
                        case DialogResult.No:
                            break;
                    }
                }
            }
            catch (ArgumentNullException ex)
            { MessageBox.Show(ex.Message); }
            dgvBool = true;
            _vendorOrdered = false;
        }

        //Changing Reorder Level Form Button
        private void btnReorderChangeLevel_Click(object sender, EventArgs e)
        {
            if (dgvBool == true && dgvReorder.CurrentRow.Selected == true)
            {
                foreach (var product in _report.Reorders)
                {
                    if (product.Product.Name == dgvReorder.CurrentRow.Cells[1].Value.ToString())
                    {
                        frmReorderChangeLevels _myForm = new frmReorderChangeLevels(product, _myAccessToken);
                        _myForm.ShowDialog();
                        populateDGV();
                    }
                }
            }
            else
            {
                MessageBox.Show("To select a Product, click on the Row Header OR\n Go! to start the report.",
                    "No Product Selected!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReorder_Click(object sender, EventArgs e)
        {
            try
            {
                if (_vendorOrdered == false)
                {
                    _vendorOrdered = _report.OrderReorders();
                    _productManager = new ProductManager();
                    foreach (Reorder reorder in _report.Reorders)
					{
						_productManager.AddToOnOrder(reorder.CasesToOrder * reorder.VendorSourceItem.ItemsPerCase, reorder.VendorSourceItem.ProductID);
					}
                    MessageBox.Show("Your order has been sent.", "Vendor Reorder");
                    _vendorOrdered = true;
				}
            }
            catch (ApplicationException ex)
            {
                if (devState)
                { MessageBox.Show(ex.Message); }
            }
            catch (NullReferenceException ex) 
            { 
                MessageBox.Show("No Order to send.","Vendor Reorder");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            _vendorOrdered = true;
            dgvReorder.Rows.Clear();
            _report = null;
        }

        private void frmReorder_FormClosed(object sender, FormClosedEventArgs e)
        {
            Instance = null;
        }

    }//end frmReorder
}//end Namespace
