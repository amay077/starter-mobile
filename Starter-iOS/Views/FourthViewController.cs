using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using ReactiveUI;
using ReactiveUI.Cocoa;
using Starter.Core.ViewModels;

namespace Starter.Views
{
    public partial class FourthViewController : ReactiveViewController, IViewFor<FourthViewModel>
    {
        public FourthViewController() : base("FourthViewController", null)
        {
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            
            this.OneWayBind(this.ViewModel, vm => vm.Location, v => v.LatLabel.Text, x => x != null ? x.Lat.ToString("0.00") : "n/a");
            this.OneWayBind(this.ViewModel, vm => vm.Location, v => v.LonLabel.Text, x => x != null ? x.Lon.ToString("0.00") : "n/a");
            
            this.BindCommand(this.ViewModel, vm => vm.StartGps, v => v.StartGpsButton);
            
            this.ViewModel = new FourthViewModel();         
        }
        
        FourthViewModel _viewModel;
        public FourthViewModel ViewModel {
            get { return _viewModel; }
            set { this.RaiseAndSetIfChanged(ref _viewModel, value); }
        }

        object IViewFor.ViewModel {
            get { return ViewModel; }
            set { ViewModel = (FourthViewModel)value; }
        }
    }
}

