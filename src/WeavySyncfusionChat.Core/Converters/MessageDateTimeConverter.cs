using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace WeavySyncfusionChat.Core.Converters
{

    public class MessageDateTimeConverter : IValueConverter
    {
     
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return string.Empty;

            var relativeDate = GetRelativeDate(value);

            return $"{relativeDate}";


        }

        private object GetRelativeDate(object value)
        {
            var current_day = DateTime.Today;
            var postedData = (DateTime)value;

            if(postedData.Date == current_day.Date)
            {
                return postedData.ToShortTimeString();
            }

            return postedData;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
