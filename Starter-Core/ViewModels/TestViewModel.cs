using System;
using ReactiveUI;
using System.Runtime.Serialization;

namespace Starter.Core.ViewModels
{
    public class TestViewModel : ReactiveObject
    {
        string _TheGuid;
        public string TheGuid {
            get { return _TheGuid; }
            set { this.RaiseAndSetIfChanged(ref _TheGuid, value); }
        }

        string _myName;
        public string MyName {
            get { return _myName; }
            set { this.RaiseAndSetIfChanged(ref _myName, value); }
        }

        public TestViewModel()
        {
            TheGuid = Guid.NewGuid().ToString();
            
            this.MyName = "Enter your name";
        }
    }
}