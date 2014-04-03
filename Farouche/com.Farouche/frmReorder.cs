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
    public partial class frmReorder : Form
    {
        private readonly AccessToken _myAccessToken;
        private ProductManager _myProductManager;
        private VendorManager _vendorManager;
        //private ReportManager _reportManager;        
        private decimal _totalAmount = 0;   //amount used for txtTotalAmount
        private Boolean dgvBool = false;    //Boolean used to determin if the dgv has been populated or not.
        private Boolean cbCanClick = false; //Hack: makes sure cellValuechanged Event wont run calcAmount function at odd times.
        
        //Constructor with AccessToken as the only parameter.
        public frmReorder(AccessToken acctoken)
        {
            InitializeComponent();
            _myAccessToken = acctoken;
        }

        private void frmReorder_Load(object sender, EventArgs e)
        {
            var venManager = new VendorManager();
            fillVendorsComboBox();
            dgvReorder.AllowUserToAddRows = false;            
        }
         
        //makes a call to populate the dgv
        //TODO: Refactor to take the vendor combobox and filter dgv accordingly
        private void btnGo_Click(object sender, EventArgs e)
        {
            _myProductManager = new ProductManager();
            populateDataGridView(_myProductManager.GetProducts());         
            dgvBool = true;
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
            cb.ValueMember = "reorderAmount";
            cb.DisplayMember = "reorderAmount";
            cb.DataSource = dt;
                      
        }
        //populates the "Product" ComboBoxColumn with a list of Products
        private void populateNewLineProductComboBox(DataGridViewComboBoxColumn cb)
        {
            cb.DataSource = _myProductManager.Products;   
            cb.DisplayMember = "Name";
            cb.ValueMember = "Id";
        }

        //populates datagridview = dgvReord
 //TODO: Refactor functionality to work with Reorder BL/Commons
        private void populateDataGridView(List<Product> lProducts)
        {
            //clears the dgv for to make room for new reorder list & resets totalAmount
            cbCanClick = false; //HACK
            dgvReorder.Rows.Clear();
            _totalAmount = 0;
            //users unable to add Products until report has been run.
            dgvReorder.AllowUserToAddRows = true;
            _myProductManager.Products = lProducts;

            //adds products to the dgv
            foreach (Product product in lProducts)
            {
                var total = product.unitPrice * product._reorderAmount;
                int n = dgvReorder.Rows.Add();
                dgvReorder.Rows[n].Cells[0].Value = true;
                //replaces the ComboboxCell with a textbox so user is unable to change product for that row.
                DataGridViewTextBoxCell tbc = new DataGridViewTextBoxCell();
                dgvReorder[1, n] = tbc;
                dgvReorder.Rows[n].Cells[1].Value = product.Name;
                dgvReorder.Rows[n].Cells[2].Value = product.unitPrice;
                dgvReorder.Rows[n].Cells[3].Value = product._reorderThreshold;                
                populate_dgvROComboBox(product._reorderAmount, (DataGridViewComboBoxCell)this.dgvReorder.Rows[n].Cells[4]);               
                dgvReorder.Rows[n].Cells[5].Value = total;
                _totalAmount = _totalAmount + total;
            }
            //C2 converts it to US currency
            txtTotalAmount.Text = _totalAmount.ToString("C2");

            //populates the ComboBox Column for "Products"
            populateNewLineProductComboBox((DataGridViewComboBoxColumn)dgvReorder.Columns[1]);  
  
            //adding EventHandlers to the DataGridView
            cbCanClick = true; //HACK
            dgvReorder.CellClick += new DataGridViewCellEventHandler(dgvReorder_CellClick); 
            dgvReorder.EditingControlShowing += new DataGridViewEditingControlShowingEventHandler(dgvReorder_EditingControlShowing);
            dgvReorder.CurrentCellDirtyStateChanged += new EventHandler(dgvReorder_CurrentCellDirtyChanged);  
            dgvReorder.CellValueChanged += new DataGridViewCellEventHandler(dgvReorder_CellValueChanged);
        }

        //EventHandler for clicking on a new line of the "Product" Column
        private void dgvReorder_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == dgvReorder.Rows.Count- 1)
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
                cb.SelectedIndexChanged += new EventHandler(dgvComboBox_SelectedIndexChanged);
            }
            else if (dgvReorder.CurrentCell.ColumnIndex == 1 & dgvReorder.CurrentRow.IsNewRow)
            {
                ComboBox cbm = e.Control as ComboBox;
                dgvReorder.CurrentCell.ReadOnly = false;
                cbm.SelectedIndexChanged += new EventHandler(dgvComboBox_SelectedIndexChanged);            
            }
        }
        //EventArg for ComboBox SelectedIndexChanged     
        private void dgvComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
            decimal _oldTotal = 0;
            decimal _reorderAmount = 0;
            
            if (dgvReorder.CurrentRow.IsNewRow)
            {
                if (cb.SelectedIndex >= 0 & dgvReorder.CurrentRow.Cells[1].ReadOnly == false)
                {
                    Product _product = _myProductManager.Products[cb.SelectedIndex];
                    //adds new Product Row to the Product List which populates the "Product" ComboBox"
     //TODO: Refactor to work with Reorder BL/Commons
                    _myProductManager.Products.Add(_product); 
                    dgvReorder.CurrentRow.Cells[0].Value = true;
                    dgvReorder.CurrentRow.Cells[1] = new DataGridViewTextBoxCell();
                    dgvReorder.CurrentRow.Cells[1].Value = _product.Name;
                    dgvReorder.CurrentRow.Cells[2].Value = _product.unitPrice;
                    dgvReorder.CurrentRow.Cells[3].Value = _product._reorderThreshold;
                    populate_dgvROComboBox(_product._reorderAmount, (DataGridViewComboBoxCell)dgvReorder.CurrentRow.Cells[4]);
                    dgvReorder.CurrentRow.Cells[5].Value = _product.unitPrice * _product._reorderAmount;
                    dgvReorder.CurrentRow.Cells[0].ReadOnly = false;
                    dgvReorder.CurrentRow.Cells[1].ReadOnly = true;
                }
            }
            else if (cb != null | cb.SelectedIndex != -1)
            {
                if (cb.SelectedIndex == 0)
                {
                    //sets Total column at selected Row to initial amount
                    dgvReorder.CurrentRow.Cells[5].Value = (_myProductManager.Products[dgvReorder.CurrentRow.Index].unitPrice *
                                    _myProductManager.Products[dgvReorder.CurrentRow.Index]._reorderAmount);
                    calculateTotalAmount();
                }
                else
                {
                    //sets Total column at Selected Row to reorderAmount * the unitprice
                    _oldTotal = (_myProductManager.Products[dgvReorder.CurrentRow.Index].unitPrice *
                                    _myProductManager.Products[dgvReorder.CurrentRow.Index]._reorderAmount);
                    decimal.TryParse(cb.SelectedIndex.ToString(), out _reorderAmount);
                    dgvReorder.CurrentRow.Cells[5].Value = (_reorderAmount + 1) * _oldTotal;
                    calculateTotalAmount();
                }
            } //end outer if else               
            cb.SelectedIndexChanged -= dgvComboBox_SelectedIndexChanged;
        }

        //EventArg for the Checkbox Column to update txtTotalAmount on StateChange
        private void dgvReorder_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 & cbCanClick == true)
            { calculateTotalAmount(); }            
        }

        //EventArg for the Checkbox Column to update txtTotalAmount on StateChange
        private void dgvReorder_CurrentCellDirtyChanged(object sender, EventArgs e)
        {
            if (dgvReorder.IsCurrentCellDirty)
            {
                dgvReorder.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }
        
        //Calculates the Amount to be set in the txtTotalAmount
        private void calculateTotalAmount()
        {
            //total amount of Reorder
            decimal _tAmount = 0;

            //loops thru the datagrid to add up the total for each row
            foreach (DataGridViewRow row in dgvReorder.Rows)
            {
                //MessageBox.Show(row.Cells[5].Value.ToString());
                //MessageBox.Show(row.Index.ToString());
                decimal temp = 0;
                if (row.IsNewRow)
                {
                    //needed to stop nullpointerexception
                     break;
                }
                //checks the checkbox cell state for each row before adding to _tAMount;
                //this was working just fine... now the left side of the if doesnt want to work on btnGo_Click
                else if (decimal.TryParse(row.Cells[5].Value.ToString(), out temp)  & (bool)row.Cells[0].Value == true)
                {
                    _tAmount += temp;
                }
                else { };
            }//end foreach
            //C2 converts it to US currency
            txtTotalAmount.Text = _tAmount.ToString("C2");
        }

        //Changing Reorder Level Form Button
        private void btnReorderChangeLevel_Click(object sender, EventArgs e)
        {
            if (dgvBool == true && dgvReorder.CurrentRow.Selected == true)
            {
                frmReorderChangeLevels _myForm = new frmReorderChangeLevels(_myProductManager.Products[dgvReorder.CurrentRow.Index]);
                _myForm.ShowDialog();                
            }
            else
            {
                MessageBox.Show("To select a Product, click on the Row Header OR\n Go! to start the report.", "No Product Selected!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }//end frmReorder
}//end Namespace
