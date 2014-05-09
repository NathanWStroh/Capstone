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
 
    public partial class frmReorderChangeLevels : Form
    {
        private Reorder _curProduct;

        public frmReorderChangeLevels(Reorder _product, AccessToken _myAccessToken)
        {
            InitializeComponent();
            _curProduct = _product;
            var RoleAccess = new RoleAccess(_myAccessToken, this);
        }

        private void frmReorderChangeLevels_Load(object sender, EventArgs e)
        {
            txtProduct.Text = _curProduct.Product.Name;
            txtROThreshold.Text = _curProduct.Product._reorderThreshold.ToString();
            txtROAmount.Text = _curProduct.CasesToOrder.ToString();
            numericROThreshold.Value = (int)_curProduct.Product._reorderThreshold;
            numericROAmount.Value = (int)_curProduct.CasesToOrder;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //updates to the product at database level
            var _pManager = new ProductManager();
            _pManager.UpdateThreshold((int)numericROThreshold.Value, _curProduct.VendorSourceItem.ProductID);
            _pManager.UpdateReorderAmount((int)numericROAmount.Value, _curProduct.VendorSourceItem.ProductID);
            _curProduct.Product._reorderThreshold = (int)numericROThreshold.Value;
            _curProduct.Product._reorderAmount = (int)numericROAmount.Value;
            _curProduct.ReorderTotal = (double)_curProduct.VendorSourceItem.UnitCost * (double)_curProduct.Product._reorderAmount;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
