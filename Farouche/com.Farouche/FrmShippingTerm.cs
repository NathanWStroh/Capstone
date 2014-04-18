using System;
using System.Collections.Generic;
using System.Windows.Forms;
using com.Farouche.BusinessLogic;
using com.Farouche.Commons;


namespace com.Farouche
{
    public partial class FrmShippingTerm : Form
    {
        private readonly AccessToken _myAccessToken;
        private ShippingTermManager _myTermManager;

        public FrmShippingTerm(AccessToken acctoken)
        {
            InitializeComponent();
            _myAccessToken = acctoken;
            _myTermManager = new ShippingTermManager();
            PopulateTermListView(this.lvShippingTerms, _myTermManager.GetTerms());
        }

        //Populates a list view.
        private void PopulateTermListView(ListView lv, List<ShippingTerm> termList)
        {
            _myTermManager.ShippingTerms = termList;
            lv.Items.Clear();
            lv.Columns.Clear();
            foreach (var term in termList)
            {
                var item = new ListViewItem();
                item.Text = term.Id.ToString();
                item.SubItems.Add(term.ShippingVendorId.ToString());
                if (term.Description.Length > 25)
                {
                    item.SubItems.Add(term.Description.Substring(0, 25));
                }
                else
                {
                    item.SubItems.Add(term.Description);
                }
                lv.Items.Add(item);
            }
            lv.Columns.Add("Term ID");
            lv.Columns.Add("Vendor ID");
            lv.Columns.Add("Description");
            lv.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }//End of PopulateVendorListView(..)

        //Restores default control properties.
        private void SetDefaults()
        {
            btnUpdateTerm.Enabled = false;
            btnActivateTerm.Enabled = false;
            btnDeactivateTerm.Enabled = false;
        }//End of setDefaults()

        private void btnAddTerm_Click(object sender, EventArgs e)
        {
            FrmAddShippingTerm form = new FrmAddShippingTerm();
            form.ShowDialog();
            SetDefaults();
            PopulateTermListView(this.lvShippingTerms, _myTermManager.GetTerms());
        }//End of btnAddTerm_Click(..)

        private void btnUpdateTerm_Click(object sender, EventArgs e)
        {
            var currentIndex = this.lvShippingTerms.SelectedIndices[0];
            FrmUpdateShippingTerm form = new FrmUpdateShippingTerm(_myTermManager.ShippingTerms[currentIndex]);
            form.ShowDialog();
            SetDefaults();
            PopulateTermListView(this.lvShippingTerms, _myTermManager.GetTerms());
        }//End of btnUpdateTerm_Click(..)

        private void lvShippingTerms_Click(object sender, EventArgs e)
        {
            btnUpdateTerm.Enabled = true;
        }

        private void lvShippingTerms_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnUpdateTerm.Enabled = true;
        }

        private void cbTermStatusSearch_SelectedIndexChanged(object sender, EventArgs e)
        {

        }//End of lvShippingTerms_Click(..)
    }
}
