using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace _56_ValidatesOnDataErrors
{
    public class NoEmptyStringValidator : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string valueFromSource = value.ToString();
            if (string.IsNullOrEmpty(valueFromSource))
                return new ValidationResult(false, "Das Feld darf nicht null sein");

            return new ValidationResult(true, null);
        }
    }
}
