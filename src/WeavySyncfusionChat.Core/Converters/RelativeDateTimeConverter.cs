using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace WeavySyncfusionChat.Core.Converters
{

    public class RelativeDateTimeConverter : IValueConverter
    {
        const int SECOND = 1;
        const int MINUTE = 60 * SECOND;
        const int HOUR = 60 * MINUTE;
        const int DAY = 24 * HOUR;
        const int MONTH = 30 * DAY;

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return string.Empty;

            var relativeDate = GetRelativeDate(value);

            //(return $"・ {relativeDate.ToString()}";
            return $"{relativeDate.ToString()}";
        }

        private object GetRelativeDate(object value)
        {
            var current_day = DateTime.Today;
            var postedData = (DateTime)value;

            var ts = new TimeSpan(DateTime.Now.Ticks - postedData.Ticks);
            double delta = Math.Abs(ts.TotalSeconds);
            var separator = ""; //"・";

            if (delta < 1 * MINUTE)
            {
                if (ts.Seconds < 0)
                {
                    return "now";
                }
                return ts.Seconds == 1 ? "now" : ts.Seconds + " sec ago";
            }

            if (delta < 2 * MINUTE)
                return "1 min";

            if (delta < 45 * MINUTE)
            {
                return ts.Minutes + " min";
            }

            if (delta <= 90 * MINUTE)
                return "1 hour";

            if (delta < 24 * HOUR)
            {
                if (ts.Hours < 0)
                {
                    return ts.Minutes;
                }

                if (ts.Hours == 1)
                    return "1 hour";

                return ts.Hours + " hours";
            }

            if (delta < 48 * HOUR)
                return $"{postedData.ToString("t")}";

            if (delta < 7 * DAY)
            {

                return $"{postedData.DayOfWeek.ToString()}";
            }

            if (delta < 30 * DAY)
            {

                return postedData.ToString("dd MMM");
            }


            if (delta < 12 * MONTH)
            {
                int months = (int)(Math.Floor((double)ts.Days / 30));
                return months <= 1 ? "1 month" : months + " month";
            }
            else
            {
                int years = (int)(Math.Floor((double)ts.Days / 365));
                return years <= 1 ? "1 year" : years + " years";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
