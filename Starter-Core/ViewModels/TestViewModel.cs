using System;
using ReactiveUI;
using System.Runtime.Serialization;
using System.Reactive.Linq;
using System.Diagnostics;
using StarterCorePcl;
using System.Windows.Input;

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

        public ICommand GotoNextCommand 
        {
            get;
            private set;
        }

        public TestViewModel()
        {
            _theTime = Observable.Interval(TimeSpan.FromSeconds(1))
                .Select(x => DateTime.Now)
                .ToProperty(this, vm => vm.TheTime);
            
//            this.Clock = Guid.NewGuid().ToString();
            var isAgreed = this.ObservableForProperty(vm => vm.IsAgreed).Select(x => x.Value).ToCommand();
            
            this.MyName = "Enter your name";

            var calclator = RxApp.MutableResolver.GetService<IMyService>();
            var calclator2 = RxApp.MutableResolver.GetService<IMyService>();
            
            var isSame = Object.ReferenceEquals(calclator, calclator2);
            
            var result = calclator.Calc(1, 2);
            
            
            IObservable<bool> canExec = this.ObservableForProperty(vm=>vm.IsAgreed).Select(x => x.Value);
            var cmd = this.WhenAny(vm => vm.TheTime, x => x.Value.Second % 2 == 0).ToCommand();
            
//            var cmd = new ReactiveCommand();
//            cmd.CanExecute
            cmd.Subscribe(x =>
            {
                Debug.WriteLine("command executed.");    
            });
            this.GotoNextCommand = cmd;
            
        }
    }
}