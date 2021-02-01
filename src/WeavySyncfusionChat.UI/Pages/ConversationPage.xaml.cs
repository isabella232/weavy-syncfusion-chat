using MvvmCross.Forms.Views;
using WeavySyncfusionChat.Core.Models;
using WeavySyncfusionChat.Core.ViewModels.Conversation;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WeavySyncfusionChat.UI.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ConversationPage : MvxContentPage<ConversationViewModel>
    {
        public ConversationPage()
        {
            InitializeComponent();

            MessagingCenter.Subscribe<GenericMessageSender>(this, "CLEAR_EDITOR", (obj) =>
            {
                sfChat.Editor.Text = string.Empty;
            });
        }

        
    }
}
