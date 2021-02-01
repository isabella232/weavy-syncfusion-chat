using MvvmCross.IoC;
using MvvmCross.ViewModels;

namespace WeavySyncfusionChat.Core
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();

            //Register Syncfusion license
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Mzg3MjU1QDMxMzgyZTM0MmUzMElEVUFVWWg3RzlROGI2c0FQd2lqOUtMV0FoUTRYSXNYeG45YnNFT0orR1E9");

            RegisterCustomAppStart<AppStart>();
        }
    }
}
