// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;
using System.CodeDom.Compiler;

namespace Starter.Views
{
	[Register ("FifthViewController")]
	partial class FifthViewController
	{
		[Outlet]
		MonoTouch.UIKit.UISlider BlueSlider { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIView ColorView { get; set; }

		[Outlet]
		MonoTouch.UIKit.UISlider GreenSlider { get; set; }

		[Outlet]
		MonoTouch.UIKit.UISlider RedSlider { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (RedSlider != null) {
				RedSlider.Dispose ();
				RedSlider = null;
			}

			if (GreenSlider != null) {
				GreenSlider.Dispose ();
				GreenSlider = null;
			}

			if (BlueSlider != null) {
				BlueSlider.Dispose ();
				BlueSlider = null;
			}

			if (ColorView != null) {
				ColorView.Dispose ();
				ColorView = null;
			}
		}
	}
}
