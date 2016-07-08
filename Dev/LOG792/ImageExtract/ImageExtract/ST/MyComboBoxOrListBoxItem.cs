using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ImageExtract.ST
{
    class MyComboBoxOrListBoxItem
    {
        public string Name;
        public int Value;
        public MyComboBoxOrListBoxItem(string name, int value)
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
