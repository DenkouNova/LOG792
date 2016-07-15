using System;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace CustomControls
{
    public partial class ValidatedTextBox : TextBox
    {
        public enum StTextBoxDataType
        {
            DateFormatYYYYMMDD,
            PositiveNumeric
        }

        public StTextBoxDataType DataType { get; set; }
        public string ErrorMessage { get; set; }
        public string TextBoxName { get; set; }
        public bool CanBeEmpty { get; set; }

        public ValidatedTextBox() : base()
        {
            ErrorMessage = "";
            TextBoxName = "";
            CanBeEmpty = true;
        }


        public bool Validate()
        {
            this.ErrorMessage = "";
            string controlDisplayedName = "\"" + (String.IsNullOrEmpty(this.TextBoxName) ? this.Name : this.TextBoxName) + "\"";

            if (CanBeEmpty && String.IsNullOrEmpty(this.Text))
            {
                // field is empty, and this is allowed, so no further validation is needed.
            }
            else
            {
                if (this.DataType == StTextBoxDataType.PositiveNumeric && !textIsPositiveNumeric())
                {
                    this.ErrorMessage = String.Format("Field {0} must be an integer higher than zero and no more than 9 digits long.", controlDisplayedName);
                }
                else if (this.DataType == StTextBoxDataType.DateFormatYYYYMMDD && !textIsDateFormatYYYYMMDD())
                {
                    this.ErrorMessage = String.Format("Field {0} must be a YYYYMMDD format date.", controlDisplayedName);
                }
            }

            if (!String.IsNullOrEmpty(ErrorMessage))
                ErrorMessage += (CanBeEmpty ? " It can also be empty." : " It cannot be empty.");

            return String.IsNullOrEmpty(ErrorMessage);
        }


        private bool textIsPositiveNumeric()
        {
            bool blnSuccess = false;
            int tempInt;

            if (!String.IsNullOrEmpty(this.Text))
            {
                if (int.TryParse(this.Text, out tempInt))
                {
                    if (tempInt > 0)
                    {
                        blnSuccess = true;
                    }
                }
            }

            return blnSuccess;
        }


        private bool textIsDateFormatYYYYMMDD()
        {
            bool blnSuccess = false;

            if (!String.IsNullOrEmpty(this.Text))
            {
                if (Regex.IsMatch(this.Text, "20[0-9][0-9](0[1-9]|1[1-2])([0][1-9]|[1-2][0-9]|3[0-1])"))
                {
                    blnSuccess = true;
                }
            }

            return blnSuccess;
        }


    }
}
