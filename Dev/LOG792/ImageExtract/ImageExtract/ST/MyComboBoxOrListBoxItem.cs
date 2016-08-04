using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ImageExtract.ST
{
    public class MyComboBoxOrListBoxItem
    {
        public string Name;
        public object Value;
        public MyComboBoxOrListBoxItem(string name, object value)
        {
            Name = name; Value = value;
        }
        public override string ToString()
        {
            // Generates the text shown in the combo box
            return Name;
        }
    }
}
