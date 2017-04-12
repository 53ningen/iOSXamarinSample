using System;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform.IoC;
namespace XamarinSample.MvvmCross.ViewModels
{
    public class SampleViewModel : MvxViewModel
    {
        string textA;
        string textB;

        public string TextA
        {
            get { return textA; }
            set { textA = value; RaisePropertyChanged(() => TextAB); }
        }

        public string TextB
        {
            get { return textB; }
            set { textB = value; RaisePropertyChanged(() => TextAB); }
        }

        public string TextAB
        {
            get { return textA + textB; }
        }
    }
}
