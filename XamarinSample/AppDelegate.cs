using Foundation;
using UIKit;

namespace XamarinSample
{
    [Register("AppDelegate")]
    public class AppDelegate : UIApplicationDelegate
    {
        UINavigationController navigationController = new UINavigationController();

        public override UIWindow Window { get; set; }

        public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
        {
            var mainViewController = new MainViewController();
            navigationController.AddChildViewController(mainViewController);
            Window = new UIWindow(UIScreen.MainScreen.Bounds);
            Window.RootViewController = navigationController;
            Window.MakeKeyAndVisible();

            return true;
        }
    }
}
