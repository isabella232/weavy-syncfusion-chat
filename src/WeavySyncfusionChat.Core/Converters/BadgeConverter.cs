using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Syncfusion.XForms.BadgeView;
using Xamarin.Forms;

namespace WeavySyncfusionChat.Core.Converters
{
    public class BadgeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var isRead = (bool)value;
            return isRead ? BadgeIcon.None: BadgeIcon.Dot ;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
            //throw new NotImplementedException();
        }
    }
}
