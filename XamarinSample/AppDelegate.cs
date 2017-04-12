using Foundation;
using UIKit;
using MvvmCross.iOS.Views.Presenters;
using MvvmCross.iOS.Platform;
using System;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;

namespace XamarinSample
{
    [Register("AppDelegate")]
    public class AppDelegate : MvxApplicationDelegate
    {
        public override UIWindow Window { get; set; }

        public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
        {
            Window = new UIWindow(UIScreen.MainScreen.Bounds);
            var presenter = new MvxIosViewPresenter(this, Window);
            var setup = new Setup(this, presenter);
            setup.Initialize();
            var startup = Mvx.Resolve<IMvxAppStart>();
            startup.Start();
            Window.MakeKeyAndVisible();
            return true;
        }
    }
}
