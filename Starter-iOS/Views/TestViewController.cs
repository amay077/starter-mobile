using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using ReactiveUI.Cocoa;
using ReactiveUI;
using Starter.Core.ViewModels;
using Akavache;
using System.Reactive.Linq;
using System.Diagnostics;

namespace Starter.Views
{
    public partial class TestViewController : ReactiveViewController, IViewFor<TestViewModel>
    {
        static bool UserInterfaceIdiomIsPhone
        {
            get { return UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone; }
        }

        public TestViewController()
            : base (UserInterfaceIdiomIsPhone ? "TestViewController_iPhone" : "TestViewController_iPad", null)
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
            this.OneWayBind(this.ViewModel, vm => vm.TheTime, v => v.TheGuid.Text, x => x.ToShortTimeString());

            this.Bind(this.ViewModel, vm=> vm.MyName, v => v.MyText.Text);
            this.OneWayBind(this.ViewModel, vm => vm.MyName, v => v.MyLabel.Text);
            this.ObservableForProperty(v => v.ViewModel)
                .Select(x => x.Value)
                .SelectMany(vm => vm.ObservableForProperty(x => x.MyName))
                .Subscribe(x => Debug.WriteLine(x.Value));
            
            this.ViewModel = new TestViewModel();
        }

        TestViewModel _viewModel;
        public TestViewModel ViewModel {
            get { return _viewModel; }
            set { this.RaiseAndSetIfChanged(ref _viewModel, value); }
        }

        object IViewFor.ViewModel {
            get { return ViewModel; }
            set { ViewModel = (TestViewModel)value; }
        }
    }
}

