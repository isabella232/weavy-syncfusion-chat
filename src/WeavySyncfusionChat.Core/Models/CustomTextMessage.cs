using System;
using System.Collections.Generic;
using System.Text;
using Syncfusion.XForms.Chat;
using Xamarin.Forms;

namespace WeavySyncfusionChat.Core.Models
{
    public class CustomTextMessage: TextMessage
    {

        public static readonly BindableProperty IsByMeProperty = BindableProperty.Create(nameof(IsByMe), typeof(bool), typeof(CustomTextMessage), default(bool), propertyChanged: OnIsByMeChanged);

        public bool IsByMe {
            get => (bool)GetValue(IsByMeProperty);
            set => SetValue(IsByMeProperty, value);
        }

        private static void OnIsByMeChanged(BindableObject bindable, object oldValue, object newValue)
        {
            
        }
    }
}
