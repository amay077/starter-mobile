using System;
using ReactiveUI;
using System.Runtime.Serialization;
using System.Reactive.Linq;
using System.Diagnostics;

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
        
        public TestViewModel()
        {
            _theTime = Observable.Interval(TimeSpan.FromSeconds(1))
                .Select(x => DateTime.Now)
                .ToProperty(this, vm => vm.TheTime);
            
//            this.Clock = Guid.NewGuid().ToString();
            
            this.MyName = "Enter your name";
            
            var cmd = new ReactiveCommand();
            
        }
    }
}