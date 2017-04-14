using System;
using MvvmCross.iOS.Views;
using XamarinSample.MvvmCross.ViewModels;
using MvvmCross.Core.ViewModels;
using MvvmCross.Binding.BindingContext;
using UIKit;
using CoreGraphics;
namespace XamarinSample
{
    public class SampleView : MvxViewController
    {

        UIStackView stackView;
        UITextField textAField;
        UITextField textBField;
        UIButton button;
        UILabel label;

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            EdgesForExtendedLayout = UIRectEdge.None;
            View.BackgroundColor = UIColor.Gray;

            stackView = getStackView(View.Bounds);
            View.AddSubview(stackView);

            textAField = new UITextField();
            textAField.BackgroundColor = UIColor.White;
            textBField = new UITextField();
            textBField.BackgroundColor = UIColor.White;
            label = new UILabel();
            label.BackgroundColor = UIColor.White;
            label.Text = "hage";
            button = new UIButton(UIButtonType.System);
            button.BackgroundColor = UIColor.Orange;
            button.TouchUpInside += (sender, e) => NavigationController?.PushViewController(new ReactiveUISampleViewController(), true);

            stackView.AddArrangedSubview(textAField);
            stackView.AddArrangedSubview(textBField);
            stackView.AddArrangedSubview(label);
            stackView.AddArrangedSubview(button);

            Request = new MvxViewModelRequest<SampleViewModel>(null, null, new MvxRequestedBy());
            var set = this.CreateBindingSet<SampleView, SampleViewModel>();
            set.Bind(textAField).To(vm => vm.TextA);
            set.Bind(textBField).To(vm => vm.TextB);
            set.Bind(label).To(vm => vm.TextAB).OneWay();
            set.Apply();
        }

        public override void ViewWillLayoutSubviews()
        {
            base.ViewWillLayoutSubviews();
            stackView.Frame = View.Bounds;
        }

        static UIStackView getStackView(CGRect frame)
        {
            var stackView = new UIStackView(frame);
            stackView.Axis = UILayoutConstraintAxis.Vertical;
            stackView.Distribution = UIStackViewDistribution.FillEqually;
            stackView.Alignment = UIStackViewAlignment.Fill;
            stackView.Spacing = 12;
            return stackView;
        }

    }
}
