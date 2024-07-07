using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Xml.Linq;

namespace TestTask1.FolderClasses
{
    internal class ChecksParamDataClass
    {
        public static bool StringIsNotEmpty(string value, TextBlock errorHint)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                if (errorHint != null) errorHint.Visibility = Visibility.Visible;
                return false;
            }

            if (errorHint != null) errorHint.Visibility = Visibility.Collapsed;
            return true;
        }

        public static bool StringIsIntegerMoreZero(string value, TextBlock errorHint)
        {
            Regex isInt = new Regex("^\\d{1,}$");
            if (isInt.IsMatch(value))
            {
                if(Convert.ToInt32(value) > 0)
                {
                    if (errorHint != null) errorHint.Visibility = Visibility.Collapsed;
                    return true;
                }
            }

            if (errorHint != null) errorHint.Visibility = Visibility.Visible;
            return false;
        }

        public static bool StringIsRealMoreZeroLessOne(string value, TextBlock errorHint)
        {
            Regex isReal = new Regex("^\\d{1,}([\\,\\.]\\d{0,})?$");
            if (isReal.IsMatch(value))
            {                
                if (Convert.ToDouble(value.Replace('.', ',')) >= 0.0 && Convert.ToDouble(value.Replace('.', ',')) <= 1.0)
                {
                    if (errorHint != null) errorHint.Visibility = Visibility.Collapsed;
                    return true;
                }
            }

            if (errorHint != null) errorHint.Visibility = Visibility.Visible;
            return false;
        }
    }
}
