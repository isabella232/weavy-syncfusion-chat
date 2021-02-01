using MvvmCross.Forms.Platforms.Ios.Core;
using Syncfusion.ListView.XForms.iOS;
using Syncfusion.SfAutoComplete.XForms.iOS;
using Syncfusion.SfBusyIndicator.XForms.iOS;
using Syncfusion.SfPullToRefresh.XForms.iOS;
using Syncfusion.XForms.iOS.BadgeView;
using Syncfusion.XForms.iOS.Chat;

namespace WeavySyncfusionChat.iOS
{
    public class Setup : MvxFormsIosSetup<Core.App, UI.App>
    {
        public Setup()
        {
            FFImageLoading.Forms.Platform.CachedImageRenderer.Init();
            new SfAutoCompleteRenderer();
            new SfBusyIndicatorRenderer();
            SfBadgeViewRenderer.Init();
            SfChatRenderer.Init();
            SfListViewRenderer.Init();
            SfPullToRefreshRenderer.Init();
        }
    }
}
