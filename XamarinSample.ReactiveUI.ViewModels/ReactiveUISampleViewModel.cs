using System;
using ReactiveUI;
namespace XamarinSample.ReactiveUI.ViewModels
{
    public class ReactiveUISampleViewModel : ReactiveObject
    {
        string text;
        public string Text
        {
            get { return text; }
            set { this.RaiseAndSetIfChanged(ref text, value); }
        }
    }
}
