using System;
using ReactiveUI;
using System.Reactive.Linq;
using System.Windows.Input;
using System.Diagnostics;
using Starter.Core.Models;

namespace Starter.Core.ViewModels
{
    public class SecondViewModel : ReactiveObject
    {
        bool _isAgreed;
        public bool IsAgreed {
            get { return _isAgreed; }
            set { this.RaiseAndSetIfChanged(ref _isAgreed, value); }
        }
        
        public ICommand Register
        {
            get;
            private set;
        }
        
        readonly MyLocationModel _model = new MyLocationModel();
    
        public SecondViewModel() {
            IObservable<bool> isAgreed = 
                this.ObservableForProperty(vm => vm.IsAgreed)
                .Select(x => x.Value);

            var cmd = isAgreed.ToCommand();
            cmd.Subscribe(_ => Debug.WriteLine("register tapped."));
            this.Register = cmd;
        }
    }
}

