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

//Author: Justin
//Date Created: 4/10/14
//Last Modified: 5/7/14
//Last Modified By: Justin Pitts

/*
*                               Changelog
* Date         By               Ticket          Version          Description
* 04/19/2014   Kaleb Wendel                                      Adjusted class to implement a singleton pattern so only one form can be instantiated.
*/

namespace com.Farouche.Presentation
{
    public partial class frmOpenVendorOrders : Form
    {
        private readonly AccessToken _myAccessToken;
        private VendorOrderManager _vendorOrdersManager;
        private ReceivingManager _receivingManager;
        private VendorManager _vendorManager;
        private Vendor vendor;
        private VendorOrder vendorOrder;
        private List<VendorOrder> orderList;
        private VendorOrderLineItem vendorOrderLineItem;
        private ReorderManager _reorderManager;
        private List<Reorder> reorderList;
        public static frmOpenVendorOrders Instance;


        public frmOpenVendorOrders(AccessToken acctkn)
        {
            InitializeComponent();
            var RoleAccess = new RoleAccess(acctkn, this);
            
            _myAccessToken = acctkn;
            Instance = this;

            // Add a CellClick handler to handle clicks in the button column.
            dgvOpenVendorOrders.CellClick += new DataGridViewCellEventHandler(dgv_CellClick);


        }

        private void frmOpenVendorOrders_Load(object sender, EventArgs e)
        {
            _receivingManager = new ReceivingManager();

            fillVendorDropDown();

            orderList = _receivingManager.GetAllOpenOrders();


            




           
            fillGridView(dgvOpenVendorOrders, orderList);
            
            
            
        }

        private void fillVendorDropDown()
        {

          
            List<Vendor> vendorList = new List<Vendor>();
            _vendorManager = new VendorManager();

            vendorList = _vendorManager.GetVendors();

            foreach (Vendor v in vendorList)

            {
                cbGetVendorsById.Items.Add(v.Id.ToString() + " " + v.Name);
            }
        }

        private void fillGridView(DataGridView dgv, List<VendorOrder> orderList)

        {

            DataGridViewButtonColumn viewOrderDetailsColumn = new DataGridViewButtonColumn();
            viewOrderDetailsColumn.Text = "View Order Details";
            viewOrderDetailsColumn.Name = "View Order Details";
            viewOrderDetailsColumn.HeaderText = "View Order Details";
            viewOrderDetailsColumn.UseColumnTextForButtonValue = true;
            dgv.Columns.Clear();
            dgv.Rows.Clear();

            dgv.ColumnCount = 5;
            dgv.Columns[0].Name = "Vendor OrderID";
            dgv.Columns[1].Name = "Vendor ID";
            dgv.Columns[2].Name = "Vendor Name";
            dgv.Columns[3].Name = "Date Ordered";
            dgv.Columns[4].Name = "Number of Shipments";
            


            foreach (var vendorOrder in orderList)
            {


                dgv.Rows.Add(vendorOrder.Id, vendorOrder.VendorID, _vendorManager.GetVendor(vendorOrder.VendorID).Name, vendorOrder.DateOrdered, vendorOrder.NumberOfShipments);
                
                
                
            }


            dgvOpenVendorOrders.Columns.Insert(5, viewOrderDetailsColumn);
            
            
        }
        
        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex < 0 || e.ColumnIndex != dgvOpenVendorOrders.Columns["View Order Details"].Index)
            {
                return;
            }
            else
            {
                try
                {

                    vendorOrder = new VendorOrder((Int32)dgvOpenVendorOrders["Vendor OrderID", e.RowIndex].Value, (Int32)dgvOpenVendorOrders["Vendor ID", e.RowIndex].Value);
                    vendorOrder.DateOrdered = (DateTime)dgvOpenVendorOrders["Date Ordered", e.RowIndex].Value;
                    vendorOrder.NumberOfShipments = (Int32)dgvOpenVendorOrders["Number of Shipments", e.RowIndex].Value;
                    frmReceiving _frmReceiving = new frmReceiving(vendorOrder, _myAccessToken);
                    _frmReceiving.Show();
                    _frmReceiving.BringToFront();
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("oops!" + ex.StackTrace.ToString());

                    ex.StackTrace.ToString();
                }
            }
              

        }


        private void btngetAllOpenOrdersByVendor_Click(object sender, EventArgs e)
        {
            try
            {
                int index = cbGetVendorsById.SelectedItem.ToString().IndexOf(" ");
                string id = cbGetVendorsById.SelectedItem.ToString().Substring(0, index);
                vendor = new Vendor(Int32.Parse(id));
                orderList = _receivingManager.GetAllOpenOrdersByVendor(vendor);
                DataGridViewButtonColumn viewOrderDetailsColumn = new DataGridViewButtonColumn();
                viewOrderDetailsColumn.UseColumnTextForButtonValue = true;
                viewOrderDetailsColumn.Text = "View Order Details";
                viewOrderDetailsColumn.HeaderText = "View Order Details";
                fillGridView(dgvOpenVendorOrders, orderList);
                dgvOpenVendorOrders.ClearSelection();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("You must select a vendor to search");
            }
        }


        

        private void cbGetVendorsById_SelectedIndexChanged(object sender, EventArgs e)
        {
            //fillVendorDropDown();
        }

       

        private void btnGellAllOpenOrders_Click(object sender, EventArgs e)
        {
            orderList = _receivingManager.GetAllOpenOrders();
           

            
            
            fillGridView(dgvOpenVendorOrders, orderList);
        }
        


        private void frmOpenVendorOrders_FormClosed(object sender, FormClosedEventArgs e)
        {
            Instance = null;
        }

       

        
    }
}
