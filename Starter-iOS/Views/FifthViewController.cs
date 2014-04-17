using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using ReactiveUI.Cocoa;
using ReactiveUI;
using Starter.Core.ViewModels;
using System.Reactive.Linq;

namespace Starter.Views
{
    public partial class FifthViewController : ReactiveViewController, IViewFor<FifthViewModel>
    {
        public FifthViewController() : base("FifthViewController", null)
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
            
            this.Bind(this.ViewModel, vm => vm.Red, v => v.RedSlider.Value);
            this.Bind(this.ViewModel, vm => vm.Green, v => v.GreenSlider.Value);
            this.Bind(this.ViewModel, vm => vm.Blue, v => v.BlueSlider.Value);
            
            var r = this.ObservableForProperty(v => v.ViewModel.Red).Select(x => x.Value);
            var g = this.ObservableForProperty(v => v.ViewModel.Green).Select(x => x.Value);
            var b = this.ObservableForProperty(v => v.ViewModel.Blue).Select(x => x.Value);
            
            Observable.CombineLatest(r, g, b, (x, y, z) => new UIColor(x, y, z, 1f))
                .ObserveOn(RxApp.MainThreadScheduler)
                .Subscribe(x => this.ColorView.BackgroundColor = x);
            
//            this.OneWayBind(this.ViewModel, vm => vm.Color, v => v.ColorView.BackgroundColor, x => x != null ? new UIColor(x.R, x.G, x.B, 1f) : UIColor.Clear);
            
            this.ViewModel = new FifthViewModel();
        }
        
        FifthViewModel _viewModel;
        public FifthViewModel ViewModel {
            get { return _viewModel; }
            set { this.RaiseAndSetIfChanged(ref _viewModel, value); }
        }

        object IViewFor.ViewModel {
            get { return ViewModel; }
            set { ViewModel = (FifthViewModel)value; }
        }
    }
}

