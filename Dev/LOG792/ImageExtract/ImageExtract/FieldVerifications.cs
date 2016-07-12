using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ImageExtract
{
    public class FieldVerifications
    {
        public static bool FieldIsPositiveNumeric(string field, out int intField, out string errorMessage)
        {
            errorMessage = "";
            intField = -1;
            
            if (!int.TryParse(field, out intField))
            {
                errorMessage = "'" + field + "' must be a positive numeric.";
            }

            return String.IsNullOrEmpty(errorMessage);
        }
    }
}
