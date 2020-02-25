using Relogio.UserControls;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace Relogio.Helpers
{
    class SegundoToAngle : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int valor = (int)value;
            return (valor * (360 / 60));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    class HoraToAngle : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double valor = (int)value >=12 ? (int)value % 12 : (int)value;
            double t = (double)(valor * (360 / 12));
            return (double)(valor * (360 / 12));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    class LigadoToCor : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //Type enumType = value.GetType();

            //var allValues = from object arrayItem in Enum.GetValues(enumType)
            //                select System.Convert.ToUInt64(arrayItem);

            //// get all the flag values
            //ulong setValues = System.Convert.ToUInt64(value);


            //var t = from ulong singleValue in allValues
            //       where (setValues & singleValue) == singleValue
            //       select Enum.GetName(enumType, singleValue);

            Ligados lig = (Ligados)value;

            Ligados enumVal = (Ligados)Enum.Parse(typeof(Ligados), parameter.ToString());

            if ((bool)lig.HasFlag(enumVal))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
