using System;
using UIKit;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
namespace XamarinSample
{
    /// <summary>
    /// UIPageViewController sample code
    /// </summary>
    public class SamplePageController : UIViewController
    {

        SamplePageDelegate pageDelegate;
        SamplePageDataSource dataSource;
        UIPageViewController pageViewController;

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            View.BackgroundColor = UIColor.LightGray;

            pageViewController = new UIPageViewController(UIPageViewControllerTransitionStyle.Scroll, UIPageViewControllerNavigationOrientation.Horizontal);

            pageDelegate = new SamplePageDelegate();
            pageViewController.Delegate = pageDelegate;
            dataSource = new SamplePageDataSource();
            pageViewController.DataSource = dataSource;
            pageViewController.SetViewControllers(new UIViewController[] { dataSource.Pages.ElementAt(0) }, UIPageViewControllerNavigationDirection.Forward, false, null);

            AddChildViewController(pageViewController);
            View.AddSubview(pageViewController.View);
            pageViewController.View.Frame = View.Bounds;
            pageViewController.DidMoveToParentViewController(this);
        }

    }

    public class SamplePageDelegate : UIPageViewControllerDelegate
    {
        public override void DidFinishAnimating(UIPageViewController pageViewController, bool finished, UIViewController[] previousViewControllers, bool completed)
        {
            Console.WriteLine("didFinishAnimating");
        }

    }

    public class SamplePageDataSource : UIPageViewControllerDataSource
    {

        public IList<UIViewController> Pages { get; private set; }

        public SamplePageDataSource()
        {
            var orangeViewController = new UIViewController();
            orangeViewController.View.BackgroundColor = UIColor.Orange;
            var blueViewController = new UIViewController();
            blueViewController.View.BackgroundColor = UIColor.Blue;
            var yellowViewController = new UIViewController();
            yellowViewController.View.BackgroundColor = UIColor.Yellow;
            Pages = new List<UIViewController>() { orangeViewController, blueViewController, yellowViewController };
        }

        public SamplePageDataSource(IList<UIViewController> pages)
        {
            this.Pages = pages;
        }

        public override UIViewController GetPreviousViewController(UIPageViewController pageViewController, UIViewController referenceViewController)
        {
            var index = Pages.IndexOf(referenceViewController);
            return index <= 0 ? null : Pages.ElementAt(index - 1);
        }

        public override UIViewController GetNextViewController(UIPageViewController pageViewController, UIViewController referenceViewController)
        {
            var index = Pages.IndexOf(referenceViewController);
            return index >= Pages.Count() - 1 ? null : Pages.ElementAt(index + 1);
        }

    }

}
