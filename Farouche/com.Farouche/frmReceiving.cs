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
 * Date         By          Ticket          Version         Description
 * 
*/

namespace com.Farouche
{
    public partial class frmReceiving : Form
    {
        private readonly AccessToken _myAccessToken;
        private VendorOrder vendorOrder;
        private ReceivingManager _receivingManager = new ReceivingManager();
        private List<VendorOrderLineItem> vendorOrderLineItemList = new List<VendorOrderLineItem>();
        private frmReceivingNotes _frmReceivingNotes;
        private VendorOrderManager _vendorOrderManager = new VendorOrderManager();
        private FrmUpdateVendorOrderLineItem _frmUpdateVendorOrderLineItem;
        private ProductManager _productManager = new ProductManager();
        public static frmReceiving Instance;




        public frmReceiving(AccessToken acctkn)
        {
            var RoleAccess = new RoleAccess(acctkn, this);
            InitializeComponent();
            _myAccessToken = acctkn;
            
        }

        public frmReceiving(VendorOrder vendorOrder, AccessToken acctkn)
        {

            
            InitializeComponent();
            _myAccessToken = acctkn;
            
             VendorManager _vendorManager = new VendorManager();
             this.vendorOrder = vendorOrder;
              
            txtVendorOrderID.Text = vendorOrder.Id.ToString();
            txtVendorName.Text = _vendorManager.GetVendor(vendorOrder.VendorID).Name.ToString();
            txtVendorID.Text = _vendorManager.GetVendor(vendorOrder.VendorID).Id.ToString();
            txtNumberofShipments.Text = _vendorOrderManager.getVendorOrder(vendorOrder.Id).NumberOfShipments.ToString();
            txtDateOrdered.Text = _vendorOrderManager.getVendorOrder(vendorOrder.Id).DateOrdered.ToString();
            vendorOrder = new VendorOrder(Int32.Parse(txtVendorOrderID.Text.ToString()), Int32.Parse(txtVendorID.Text.ToString()));
            populateListView();
            //try
            //{
            //    lvReceiving.Clear();
            //    vendorOrderLineItemList = _receivingManager.GetAllLineItemsByVendorOrder(vendorOrder);
            //    foreach (var vendorOrderLineItem in vendorOrderLineItemList)
            //    {
            //        var item = new ListViewItem();
            //        item.Text = vendorOrderLineItem.ProductID.ToString();
            //        item.SubItems.Add(_productManager.GetProduct(vendorOrderLineItem.ProductID).Name.ToString());
            //        item.SubItems.Add(vendorOrderLineItem.QtyOrdered.ToString());
            //        item.SubItems.Add(vendorOrderLineItem.QtyReceived.ToString());
            //        item.SubItems.Add(vendorOrderLineItem.QtyDamaged.ToString());
            //        item.SubItems.Add(vendorOrderLineItem.Note);
            //        lvReceiving.Items.Add(item);
            //    }
            //    lvReceiving.Columns.Add("ProductID");
            //    lvReceiving.Columns.Add("Product Name");
            //    lvReceiving.Columns.Add("Quantity Ordered");
            //    lvReceiving.Columns.Add("Quantity Received");
            //    lvReceiving.Columns.Add("Quantity Damaged");
            //    lvReceiving.Columns.Add("Note");

            //    lvReceiving.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("An error occured while loading the vendor listView. " + ex.ToString());
            //}
           
        }



        private void frmReceiving_Load(object sender, EventArgs e)

        {

            //vendorOrder = new VendorOrder(Int32.Parse(txtVendorOrderID.Text.ToString()), Int32.Parse(txtVendorID.Text.ToString()));
            //populateListView(lvReceiving, _receivingManager.GetAllLineItemsByVendorOrder(vendorOrder));
            //vendorOrder = new VendorOrder(Int32.Parse(txtVendorOrderID.Text.ToString()), Int32.Parse(txtVendorID.Text.ToString()));
            //populateListView(lvReceiving, _receivingManager.GetAllLineItemsByVendorOrder(vendorOrder));
            try
            {
                lvReceiving.Clear();
                vendorOrderLineItemList = _receivingManager.GetAllLineItemsByVendorOrder(vendorOrder);
                foreach (var vendorOrderLineItem in vendorOrderLineItemList)
                {
                    var item = new ListViewItem();
                    item.Text = vendorOrderLineItem.ProductID.ToString();
                    item.SubItems.Add(_productManager.GetProduct(vendorOrderLineItem.ProductID).Name.ToString());
                    item.SubItems.Add(vendorOrderLineItem.QtyOrdered.ToString());
                    item.SubItems.Add(vendorOrderLineItem.QtyReceived.ToString());
                    item.SubItems.Add(vendorOrderLineItem.QtyDamaged.ToString());
                    item.SubItems.Add(vendorOrderLineItem.Note);
                    lvReceiving.Items.Add(item);
                }
                lvReceiving.Columns.Add("ProductID");
                lvReceiving.Columns.Add("Product Name");
                lvReceiving.Columns.Add("Quantity Ordered");
                lvReceiving.Columns.Add("Quantity Received");
                lvReceiving.Columns.Add("Quantity Damaged");
                lvReceiving.Columns.Add("Note");

                lvReceiving.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occured while loading the vendor listView. " + ex.ToString());
            }
           
            
  
        }


        private void btnAddLineItemtoCurrentListView_Click(object sender, EventArgs e)
        {

            vendorOrder = new VendorOrder(Int32.Parse(txtVendorOrderID.Text), Int32.Parse(txtVendorID.Text));

            FrmAddLineItemToVendorOrder _FrmAddLineItemToVendorOrder = new FrmAddLineItemToVendorOrder(vendorOrder, _myAccessToken);
            _FrmAddLineItemToVendorOrder.ShowDialog();
            populateListView();
            

        }

        private void btnUpdateLineItem_Click(object sender, EventArgs e)
        {

            ListView.SelectedListViewItemCollection selectedVendorOrderLineItem = this.lvReceiving.SelectedItems;
            if (selectedVendorOrderLineItem.Count > 0)
            {
                //int vendorID = Convert.ToInt32(selectedVendor[0].SubItems[0].Text);
                //Vendor thisVendor = _myVendorManager.GetVendor(vendorID);
                //FrmVendorAddUpdate frm = new FrmVendorAddUpdate(_myAccessToken, thisVendor);
                //frm.ShowDialog();
                //findActiveSelection();
                VendorManager _vendorManager = new VendorManager();
                int productID = Convert.ToInt32(selectedVendorOrderLineItem[0].SubItems[0].Text);
                int id = Convert.ToInt32(txtVendorOrderID.Text);
                string vendorName = txtVendorName.Text;
                int vendorID = Convert.ToInt32(txtVendorID.Text);

                VendorOrderLineItem item = new VendorOrderLineItem(id, productID);
                item.ProductID = productID;
                item.Name = selectedVendorOrderLineItem[0].SubItems[1].Text;
                item.QtyOrdered = Convert.ToInt32(selectedVendorOrderLineItem[0].SubItems[2].Text);
                item.QtyReceived = Convert.ToInt32(selectedVendorOrderLineItem[0].SubItems[3].Text);
                item.QtyDamaged = Convert.ToInt32(selectedVendorOrderLineItem[0].SubItems[4].Text);
                item.Note = selectedVendorOrderLineItem[0].SubItems[5].Text;


                _frmUpdateVendorOrderLineItem = new FrmUpdateVendorOrderLineItem(item, vendorName, vendorID, _myAccessToken);
                _frmUpdateVendorOrderLineItem.ShowDialog();
                populateListView();

            }
        }



        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUpdateOrder_Click(object sender, EventArgs e)
        {
            ListView.SelectedListViewItemCollection selectedVendorOrderLineItem = this.lvReceiving.SelectedItems;
            if (selectedVendorOrderLineItem.Count > 0)
            {
                //int vendorID = Convert.ToInt32(selectedVendor[0].SubItems[0].Text);
                //Vendor thisVendor = _myVendorManager.GetVendor(vendorID);
                //FrmVendorAddUpdate frm = new FrmVendorAddUpdate(_myAccessToken, thisVendor);
                //frm.ShowDialog();
                //findActiveSelection();
                VendorManager _vendorManager = new VendorManager();
                int productID = Convert.ToInt32(selectedVendorOrderLineItem[0].SubItems[0].Text);
                int id = Convert.ToInt32(txtVendorOrderID.Text);
                string vendorName = txtVendorName.Text;
                int vendorID = Convert.ToInt32(txtVendorID.Text);

                VendorOrderLineItem item = new VendorOrderLineItem(id, productID);
                item.ProductID = productID;
                item.Name = selectedVendorOrderLineItem[0].SubItems[1].Text;
                item.QtyOrdered = Convert.ToInt32(selectedVendorOrderLineItem[0].SubItems[2].Text);
                item.QtyReceived = Convert.ToInt32(selectedVendorOrderLineItem[0].SubItems[3].Text);
                item.QtyDamaged = Convert.ToInt32(selectedVendorOrderLineItem[0].SubItems[4].Text);
                item.Note = selectedVendorOrderLineItem[0].SubItems[5].Text;


                _frmUpdateVendorOrderLineItem = new FrmUpdateVendorOrderLineItem(item, vendorName, vendorID, _myAccessToken);
                _frmUpdateVendorOrderLineItem.ShowDialog();
                populateListView();
            }
        }



        private void btnAddNote_Click(object sender, EventArgs e)
        {

            

            
             ListView.SelectedListViewItemCollection selectedVendorOrderLineItem = this.lvReceiving.SelectedItems;

                if (selectedVendorOrderLineItem.Count > 0)
            {
                //int vendorID = Convert.ToInt32(selectedVendor[0].SubItems[0].Text);
                //Vendor thisVendor = _myVendorManager.GetVendor(vendorID);
                //FrmVendorAddUpdate frm = new FrmVendorAddUpdate(_myAccessToken, thisVendor);
                //frm.ShowDialog();
                //findActiveSelection();

                var id = Int32.Parse(txtVendorOrderID.Text);
                var vendorID = Int32.Parse(txtVendorID.Text.ToString());
                var productID = Convert.ToInt32(selectedVendorOrderLineItem[0].SubItems[0].Text);
                var note = selectedVendorOrderLineItem[0].SubItems[5].Text;


                _frmReceivingNotes = new frmReceivingNotes(id, productID, vendorID, note, _myAccessToken);
                _frmReceivingNotes.ShowDialog();
                populateListView();
            }
               
                
                

            


        }

        private void btnUpdateLineItem_Click_1(object sender, EventArgs e)
        {

            ListView.SelectedListViewItemCollection selectedVendorOrderLineItem = this.lvReceiving.SelectedItems;
            if (selectedVendorOrderLineItem.Count > 0)
            {
                //int vendorID = Convert.ToInt32(selectedVendor[0].SubItems[0].Text);
                //Vendor thisVendor = _myVendorManager.GetVendor(vendorID);
                //FrmVendorAddUpdate frm = new FrmVendorAddUpdate(_myAccessToken, thisVendor);
                //frm.ShowDialog();
                //findActiveSelection();
                VendorManager _vendorManager = new VendorManager();
                int productID = Convert.ToInt32(selectedVendorOrderLineItem[0].SubItems[0].Text);
                int id = Convert.ToInt32(txtVendorOrderID.Text);
                string vendorName = txtVendorName.Text;
                int vendorID = Convert.ToInt32(txtVendorID.Text);

                VendorOrderLineItem item = new VendorOrderLineItem(id, productID);
                item.ProductID = productID;
                item.Name = selectedVendorOrderLineItem[0].SubItems[1].Text;
                item.QtyOrdered = Convert.ToInt32(selectedVendorOrderLineItem[0].SubItems[2].Text);
                item.QtyReceived = Convert.ToInt32(selectedVendorOrderLineItem[0].SubItems[3].Text);
                item.QtyDamaged = Convert.ToInt32(selectedVendorOrderLineItem[0].SubItems[4].Text);
                item.Note = selectedVendorOrderLineItem[0].SubItems[5].Text;


                _frmUpdateVendorOrderLineItem = new FrmUpdateVendorOrderLineItem(item, vendorName, vendorID, _myAccessToken);
                _frmUpdateVendorOrderLineItem.ShowDialog();
                populateListView();
                
            }
              
        }

        private void populateListView()
        {
            vendorOrderLineItemList = _receivingManager.GetAllLineItemsByVendorOrder(vendorOrder);
            try
            {
                lvReceiving.Clear();

                foreach (var vendorOrderLineItem in vendorOrderLineItemList)
                {
                    var item = new ListViewItem();
                    item.Text = vendorOrderLineItem.ProductID.ToString();
                    item.SubItems.Add(_productManager.GetProduct(vendorOrderLineItem.ProductID).Name.ToString());
                    item.SubItems.Add(vendorOrderLineItem.QtyOrdered.ToString());
                    item.SubItems.Add(vendorOrderLineItem.QtyReceived.ToString());
                    item.SubItems.Add(vendorOrderLineItem.QtyDamaged.ToString());
                    item.SubItems.Add(vendorOrderLineItem.Note);
                    lvReceiving.Items.Add(item);
                }
                lvReceiving.Columns.Add("ProductID");
                lvReceiving.Columns.Add("Product Name");
                lvReceiving.Columns.Add("Quantity Ordered");
                lvReceiving.Columns.Add("Quantity Received");
                lvReceiving.Columns.Add("Quantity Damaged");
                lvReceiving.Columns.Add("Note");

                lvReceiving.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occured while loading the vendor listView. " + ex.ToString());
            }
        }
       

       

        private void btnUpdateLineItem_Click_2(object sender, EventArgs e)
        {
            ListView.SelectedListViewItemCollection selectedVendorOrderLineItem = this.lvReceiving.SelectedItems;
            if (selectedVendorOrderLineItem.Count > 0)
            {
                //int vendorID = Convert.ToInt32(selectedVendor[0].SubItems[0].Text);
                //Vendor thisVendor = _myVendorManager.GetVendor(vendorID);
                //FrmVendorAddUpdate frm = new FrmVendorAddUpdate(_myAccessToken, thisVendor);
                //frm.ShowDialog();
                //findActiveSelection();
                VendorManager _vendorManager = new VendorManager();
                int productID = Convert.ToInt32(selectedVendorOrderLineItem[0].SubItems[0].Text);
                int id = Convert.ToInt32(txtVendorOrderID.Text);
                string vendorName = txtVendorName.Text;
                int vendorID = Convert.ToInt32(txtVendorID.Text);

                VendorOrderLineItem item = new VendorOrderLineItem(id, productID);
                item.ProductID = productID;
                item.Name = selectedVendorOrderLineItem[0].SubItems[1].Text;
                item.QtyOrdered = Convert.ToInt32(selectedVendorOrderLineItem[0].SubItems[2].Text);
                item.QtyReceived = Convert.ToInt32(selectedVendorOrderLineItem[0].SubItems[3].Text);
                item.QtyDamaged = Convert.ToInt32(selectedVendorOrderLineItem[0].SubItems[4].Text);
                item.Note = selectedVendorOrderLineItem[0].SubItems[5].Text;


                _frmUpdateVendorOrderLineItem = new FrmUpdateVendorOrderLineItem(item, vendorName, vendorID, _myAccessToken);
                _frmUpdateVendorOrderLineItem.ShowDialog();
                populateListView();

            }
        }


       
        private void frmReceiving_FormClosed(object sender, FormClosedEventArgs e)
        {
            Instance = null;
        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            VendorOrder thisOrder = new VendorOrder(vendorOrder.Id);
            thisOrder.LineItems = vendorOrderLineItemList;
            _vendorOrderManager.FinalizeVendorOrder(thisOrder);
        }


        
    }
}
