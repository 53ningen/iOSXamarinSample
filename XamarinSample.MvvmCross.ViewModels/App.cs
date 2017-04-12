using System;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform.IoC;

namespace XamarinSample.MvvmCross.ViewModels
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            base.Initialize();
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsSingleton();
            RegisterAppStart<SampleViewModel>();
        }
    }
}
