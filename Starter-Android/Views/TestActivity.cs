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

            this.OneWayBind(TypedViewModel, vm => vm.Clock, v => v.TheGuidLabel.Text);
            this.Bind(this.TypedViewModel, vm => vm.MyName, v => v.MyNameText.Text);
            this.OneWayBind(TypedViewModel, vm => vm.MyName, v => v.MyNameLabel.Text);

            this.TypedViewModel = new TestViewModel();
        }

        TestViewModel _ViewModel;
        public TestViewModel TypedViewModel {
            get { return _ViewModel; }
            set { this.RaiseAndSetIfChanged(ref _ViewModel, value); }
        }

        object IViewFor.TypedViewModel {
            get { return TypedViewModel; }
            set { TypedViewModel = (TestViewModel)value; }
        }

        public TextView TheGuidLabel { get; protected set; }
        public EditText MyNameText { get; protected set; }
        public TextView MyNameLabel { get; protected set; }
    }
}


