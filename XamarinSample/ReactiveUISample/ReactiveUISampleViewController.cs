using System;
using UIKit;
using ReactiveUI;
using XamarinSample.ReactiveUI.ViewModels;
using CoreGraphics;
using System.Reactive.Linq;

namespace XamarinSample
{
    public class ReactiveUISampleViewController : ReactiveViewController, IViewFor<ReactiveUISampleViewModel>
    {
        UIStackView stackView;
        UITextView textView;
        UILabel label;

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            EdgesForExtendedLayout = UIRectEdge.None;
            View.BackgroundColor = UIColor.White;
            ViewModel = new ReactiveUISampleViewModel();

            stackView = getStackView(View.Bounds);
            View.AddSubview(stackView);

            label = new UILabel();
            label.Lines = 10;
            label.BackgroundColor = UIColor.Orange;
            textView = new UITextView();
            textView.BackgroundColor = UIColor.LightGray;

            this
                .WhenAnyValue(x => x.textView.Text)
                .Where(x => x != null)
                .BindTo(viewModel, x => x.Text);
            this
                .WhenAnyValue(x => x.viewModel.Text)
                .Where(x => x != null)
                .BindTo(label, x => x.Text);

            stackView.AddArrangedSubview(label);
            stackView.AddArrangedSubview(textView);
        }

        ReactiveUISampleViewModel viewModel;
        public ReactiveUISampleViewModel ViewModel
        {
            get { return viewModel; }
            set { this.RaiseAndSetIfChanged(ref viewModel, value); }
        }

        object IViewFor.ViewModel
        {
            get { return viewModel; }
            set { ViewModel = (ReactiveUISampleViewModel) value; }
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
