using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using ReactiveUI.Cocoa;
using ReactiveUI;
using Starter.Core.ViewModels;
using System.Reactive.Linq;

namespace Starter
{
    public partial class SecondViewController : ReactiveViewController, IViewFor<SecondViewModel>
    {
        public SecondViewController() : base("SecondViewController", null)
        {
        }

        public override void DidReceiveMemoryWarning()
        {
            // Releases the view if it doesn't have a superview.
            base.DidReceiveMemoryWarning();
            
            // Release any cached data, images, etc that aren't in use.
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            
            this.Bind(this.ViewModel, vm => vm.IsAgreed, v => v.ToggleAgreed.On);
            
            this.BindCommand(this.ViewModel, vm => vm.Register, v => v.RegisterButton);
            
            
            this.ViewModel = new SecondViewModel();
        }
        
        SecondViewModel _viewModel;
        public SecondViewModel ViewModel {
            get { return _viewModel; }
            set { this.RaiseAndSetIfChanged(ref _viewModel, value); }
        }

        object IViewFor.ViewModel {
            get { return ViewModel; }
            set { ViewModel = (SecondViewModel)value; }
        }

    }
}

