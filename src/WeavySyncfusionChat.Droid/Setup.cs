using Android.App;
using MvvmCross.Forms.Platforms.Android.Core;

#if DEBUG
[assembly: Application(Debuggable = true)]
#else
[assembly: Application(Debuggable = false)]
#endif

namespace WeavySyncfusionChat.Droid
{
    public class Setup : MvxFormsAndroidSetup<Core.App, UI.App>
    {

        public Setup()
        {
            FFImageLoading.Forms.Platform.CachedImageRenderer.Init(true);
        }
    }
}
