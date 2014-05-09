using System;
using System.Collections.Generic;
using System.Windows.Forms;
using com.Farouche.BusinessLogic;
using com.Farouche.Commons;

/*
*                               Changelog
* Date         By               Ticket          Version          Description
* 04/19/2014   Kaleb Wendel                                      Adjusted class to implement a singleton pattern so only one form can be instantiated.
*
* 5/1/2014     Kaleb                                             Added the ability to activate/deactivate a term.
*/

namespace com.Farouche
{
    public partial class FrmShippingTerm : Form
    {
        private readonly AccessToken _myAccessToken;
        private ShippingTermManager _myTermManager;
        public static FrmShippingTerm Instance;

        public FrmShippingTerm(AccessToken acctoken)
        {
            InitializeComponent();
            _myAccessToken = acctoken;
            _myTermManager = new ShippingTermManager();
            Instance = this;
        }

        private void FrmShippingTerm_Load(object sender, EventArgs e)
        {
            PopulateActiveCombo();
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
                //item.SubItems.Add(term.ShippingVendorId.ToString());
                item.SubItems.Add(term.ShippingVendorName);
                if (term.Description.Length > 25)
                {
                    item.SubItems.Add(term.Description.Substring(0, 25));
                }
                else
                {
                    item.SubItems.Add(term.Description);
                } 
                item.SubItems.Add(term.Active.ToString());
                lv.Items.Add(item);
            }
            lv.Columns.Add("Term ID");
            //lv.Columns.Add("Vendor ID");
            lv.Columns.Add("Vendor Name");
            lv.Columns.Add("Description");
            lv.Columns.Add("Active");
            lv.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }//End of PopulateVendorListView(..)

        //Restores default control properties.
        private void SetDefaults()
        {
            btnUpdateTerm.Enabled = false;
            btnActivateTerm.Enabled = false;
            btnDeactivateTerm.Enabled = false;
            btnDeleteTerm.Enabled = false;
        }//End of setDefaults()

        private void btnAddTerm_Click(object sender, EventArgs e)
        {
            FrmAddShippingTerm form = new FrmAddShippingTerm(_myAccessToken);
            form.ShowDialog();
            SetDefaults();
            PopulateTermListView(this.lvShippingTerms, _myTermManager.GetTerms());
            FindActiveSelection();
        }//End of btnAddTerm_Click(..)

        private void btnUpdateTerm_Click(object sender, EventArgs e)
        {
            var currentIndex = this.lvShippingTerms.SelectedIndices[0];
            FrmUpdateShippingTerm form = new FrmUpdateShippingTerm(_myTermManager.ShippingTerms[currentIndex]);
            form.ShowDialog();
            SetDefaults();
            PopulateTermListView(this.lvShippingTerms, _myTermManager.GetTerms());
            FindActiveSelection();
        }//End of btnUpdateTerm_Click(..)

        private void lvShippingTerms_Click_1(object sender, EventArgs e)
        {
            int currentIndex = this.lvShippingTerms.SelectedItems[0].Index;
            ShippingTerm thisTerm = _myTermManager.ShippingTerms[currentIndex];
            if (thisTerm.Active == true)
            {
                btnActivateTerm.Enabled = false;
                btnDeactivateTerm.Enabled = true;
            }
            else
            {
                btnActivateTerm.Enabled = true;
                btnDeleteTerm.Enabled = true;
                btnDeactivateTerm.Enabled = false;
            }
            btnUpdateTerm.Enabled = true;
        }

        private void FrmShippingTerm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Instance = null;
        }

        private void PopulateActiveCombo()
        {
            Active active;
            for (int i = 1; i >= 0; i--)
            {
                active = (Active)i;
                this.cbTermStatusSearch.Items.Add(active);
            }
            this.cbTermStatusSearch.Items.Add("Both");
            this.cbTermStatusSearch.SelectedIndex = 0;
        }//End of populateActiveCombo()

        private void FindActiveSelection()
        {
            Boolean active;
            switch (this.cbTermStatusSearch.SelectedIndex)
            {
                case 0:
                    active = true; //True
                    PopulateTermListView(this.lvShippingTerms, _myTermManager.GetShippingTermsByActive(active));
                    break;
                case 1:
                    active = false; //False
                    PopulateTermListView(this.lvShippingTerms, _myTermManager.GetShippingTermsByActive(active));
                    break;
                case 2:
                    PopulateTermListView(this.lvShippingTerms, _myTermManager.GetTerms());
                    break;
            }
            SetDefaults();
        }

        private void cbTermStatusSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            FindActiveSelection();
        }

        private void cbTermStatusSearch_Click(object sender, EventArgs e)
        {
            SetDefaults();
        }

        private void btnActivateTerm_Click(object sender, EventArgs e)
        {
            int currentIndex = this.lvShippingTerms.SelectedIndices[0];
            Boolean success = _myTermManager.ReactivateTerm(_myTermManager.ShippingTerms[currentIndex]);
            if (success == true)
            {
                MessageBox.Show("The term was activated");
            }
            FindActiveSelection();
        }

        private void btnDeactivateTerm_Click(object sender, EventArgs e)
        {
            int currentIndex = this.lvShippingTerms.SelectedIndices[0];
            Boolean success = _myTermManager.DeactivateTerm(_myTermManager.ShippingTerms[currentIndex]);
            if (success == true)
            {
                MessageBox.Show("The term was made inactive.");
            }
            FindActiveSelection();
        }

        private void btnDeleteTerm_Click(object sender, EventArgs e)
        {
            int currentIndex = this.lvShippingTerms.SelectedIndices[0];
            Boolean success = _myTermManager.DeleteTerm(_myTermManager.ShippingTerms[currentIndex]);
            if (success == true)
            {
                MessageBox.Show("The term was removed.");
            }
            FindActiveSelection();
        }
    }
}
