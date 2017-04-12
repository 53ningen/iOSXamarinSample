using System;
using MvvmCross.iOS.Views;
using XamarinSample.MvvmCross.ViewModels;
using MvvmCross.Core.ViewModels;
using MvvmCross.Binding.BindingContext;
using UIKit;
namespace XamarinSample
{
    public class SampleViewController : MvxViewController
    {

        UIStackView stackView;

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            EdgesForExtendedLayout = UIRectEdge.None;
            View.BackgroundColor = UIColor.Yellow;

            stackView = new UIStackView(View.Bounds);
            View.AddSubview(stackView);

            this.Request = new MvxViewModelRequest<SampleViewModel>(null, null, new MvxRequestedBy());
            var set = this.CreateBindingSet<SampleViewController, SampleViewModel>();
            set.Apply();
        }

        public override void ViewWillLayoutSubviews()
        {
            base.ViewWillLayoutSubviews();
            stackView.Frame = View.Bounds;
        }

    }
}
