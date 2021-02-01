using System;
using System.Globalization;
using Syncfusion.XForms.Chat;
using Xamarin.Forms;

namespace WeavySyncfusionChat.Core.Converters
{
    public class MessageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return false;

            var message = (ITextMessage)value;
            var me = new Author() { Name = Constants.Me.Profile.Name, Avatar = Constants.Me.ThumbUrlFull };
            if(message.Author == me)
            {
                return true;
            }

            return false;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => throw new NotImplementedException();
    }
}
