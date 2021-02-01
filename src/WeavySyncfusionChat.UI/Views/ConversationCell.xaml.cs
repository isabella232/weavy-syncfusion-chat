using FFImageLoading.Svg.Forms;
using WeavySyncfusionChat.Core.ViewModels.Conversation;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WeavySyncfusionChat.UI.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ConversationCell : ContentView
    {
        public ConversationCell()
        {
            InitializeComponent();
        }

        protected override void OnBindingContextChanged()
        {
            // you can also put cachedImage.Source = null; here to prevent showing old images occasionally
            CachedImage.Source = null;

            if (!(BindingContext is ConversationItem conversation))
            {
                return;
            }
            
            // handle .svg images
            CachedImage.Source = conversation.ThumbUrl.Contains(".svg") ? new SvgImageSource(conversation.ThumbUrl, 0, 0, true) : conversation.ImageSource;

            base.OnBindingContextChanged();
        }
    }
}
