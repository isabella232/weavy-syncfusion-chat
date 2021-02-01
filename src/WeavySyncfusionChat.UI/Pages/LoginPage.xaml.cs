using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvvmCross.Forms.Views;
using WeavySyncfusionChat.Core.ViewModels.Login;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WeavySyncfusionChat.UI.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : MvxContentPage<LoginViewModel>
    {
        public LoginPage()
        {
            InitializeComponent();
        }
    }
}
