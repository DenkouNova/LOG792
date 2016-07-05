using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ImageExtract.ST
{
    public partial class ImageInclusionListBoxes : UserControl
    {
        public ImageInclusionListBoxes()
        {
            InitializeComponent();
        }



        public void AddToIncludeBox(object o)
        {
            this.lbInclude.Items.Add(o);
        }

        public void AddToAllItemsBox(object o)
        {
            this.lbAllItems.Items.Add(o);
        }

        public void AddToExcludeBox(object o)
        {
            this.lbExclude.Items.Add(o);
        }


    }
}
