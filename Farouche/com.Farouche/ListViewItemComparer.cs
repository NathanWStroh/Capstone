using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Windows.Forms;

namespace com.Farouche.BusinessLogic
{
    public class ListViewItemComparer : IComparer
    {
        private int _column;
        private SortOrder _order;
        public ListViewItemComparer()
        {
            _column = 0;
            _order = SortOrder.Ascending;
        }

        public ListViewItemComparer(int column, SortOrder order)
        {
            _column = column;
            _order = order;
        }

        public int Compare(object x, object y)
        {
            int returnVal = -1;
            //compares the text of 2 listviewitems
            returnVal = String.Compare(((ListViewItem)x).SubItems[_column].Text,
            ((ListViewItem)y).SubItems[_column].Text);
            if (_order == SortOrder.Descending)
            {
                //inverts return value for descending
                returnVal *= -1;
            }
            return returnVal;
        }
    }
}
