using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using ReactiveUI.Android;
using ReactiveUI;
using Starter.Core.ViewModels;

namespace Starter.Views
{
    [Activity (Label = "Starter-Android", MainLauncher = true)]
    public class TestActivity : ReactiveActivity, IViewFor<TestViewModel>
    {
        int count = 1;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            Button button = FindViewById<Button>(Resource.Id.myButton);
            
            button.Click += delegate
            {
                button.Text = string.Format("{0} clicks!", count++);
            };

            this.TheGuidLabel = FindViewById<TextView>(Resource.Id.TheGuid);
            this.MyNameText = FindViewById<EditText>(Resource.Id.editMyName);
            this.MyNameLabel = FindViewById<TextView>(Resource.Id.labelMyName);

            this.OneWayBind(ViewModel, vm => vm.TheGuid, v => v.TheGuidLabel.Text);
            this.Bind(this.ViewModel, vm => vm.MyName, v => v.MyNameText.Text);
            this.OneWayBind(ViewModel, vm => vm.MyName, v => v.MyNameLabel.Text);

            this.ViewModel = new TestViewModel();
        }

        TestViewModel _ViewModel;
        public TestViewModel ViewModel {
            get { return _ViewModel; }
            set { this.RaiseAndSetIfChanged(ref _ViewModel, value); }
        }

        object IViewFor.ViewModel {
            get { return ViewModel; }
            set { ViewModel = (TestViewModel)value; }
        }

        public TextView TheGuidLabel { get; protected set; }
        public EditText MyNameText { get; protected set; }
        public TextView MyNameLabel { get; protected set; }
    }
}


