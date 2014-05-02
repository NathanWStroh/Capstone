using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace com.Farouche.Commons
{
    class PoundsUpDown : NumericUpDown
    {
        protected override void UpdateEditText()
        {
            base.UpdateEditText();
            ChangingText = true;
            this.Text = this.Text + "lbs";
        }
    }
}
