using System;
using ReactiveUI;
using System.Runtime.Serialization;
using System.Reactive.Linq;
using System.Diagnostics;
using StarterCorePcl;

namespace Starter.Core.ViewModels
{
    public class TestViewModel : ReactiveObject
    {
        string _TheGuid;
        public string Clock {
            get { return _TheGuid; }
            set { this.RaiseAndSetIfChanged(ref _TheGuid, value); }
        }

        string _myName;
        public string MyName {
            get { return _myName; }
            set { this.RaiseAndSetIfChanged(ref _myName, value); }
        }
        
        ObservableAsPropertyHelper<DateTime> _theTime;
        public DateTime TheTime
        {
            get { return _theTime.Value; }
        }

        bool _isAgreed;
        public bool IsAgreed {
            get { return _isAgreed; }
            set { this.RaiseAndSetIfChanged(ref _isAgreed, value); }
        }

        public IReactiveCommand GotoNextCommand;

        public TestViewModel()
        {
            _theTime = Observable.Interval(TimeSpan.FromSeconds(1))
                .Select(x => DateTime.Now)
                .ToProperty(this, vm => vm.TheTime);
            
//            this.Clock = Guid.NewGuid().ToString();
            
            this.MyName = "Enter your name";

            var calclator = RxApp.MutableResolver.GetService<IMyService>();
            var result = calclator.Calc(1, 2);
            
            this.GotoNextCommand = new ReactiveCommand(
                this.ObservableForProperty(vm=>vm.IsAgreed).Select(x => x.Value));
            this.GotoNextCommand.Subscribe(x =>
            {

            });
            
        }
    }
}