using System;

using UIKit;
using ObjCRuntime;
using CoreGraphics;

namespace XamarinSample
{
    public class MainViewController : UIViewController
    {
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.
            View.BackgroundColor = UIColor.Orange;

            const int width = 200;
            const int height = 40;
            var button = UIButton.FromType(UIButtonType.System);
            button.Frame = new CGRect((View.Bounds.Width - width) / 2, (View.Bounds.Height - height) / 2, width, height);
            button.SetTitle("UIPageView Sample", UIControlState.Normal);

            button.TouchDown += (sender, e) =>
            {
                var vc = new SamplePageController();
                vc.View.Frame = View.Bounds;
                vc.EdgesForExtendedLayout = UIRectEdge.None;
                NavigationController?.PushViewController(vc, true);
            };
            View.AddSubview(button);
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}
