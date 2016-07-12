using System;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections.Generic;

namespace CustomControls
{
    public static class CustomFormValidation
    {

        public static bool ControlIsValid(Control c)
        {
            bool formIsValid = true;
            ValidatedTextBox currentVtb;

            foreach (Control oneControl in c.Controls)
            {
                if (oneControl is ValidatedTextBox)
                {
                    // Control is a validatable control. Call the validate function
                    currentVtb = ((ValidatedTextBox)oneControl);
                    if (!currentVtb.Validate())
                    {
                        formIsValid = false;
                        MessageBox.Show(currentVtb.ErrorMessage);
                        break;
                    }
                }
                else
                {
                    // Control is not a validatable control, but could contain validatable controls.
                    // Call the validation function recursively
                    if (!ControlIsValid(oneControl))
                    {
                        // Message Box will be shown when validating validatable controls in the inner function
                        formIsValid = false;
                        break;
                    }
                }
            }

            return formIsValid;
        }
    }
}
