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
	[Register ("MenuViewController")]
	partial class MenuViewController
	{
		[Outlet]
		MonoTouch.UIKit.UIButton FifthViewButton { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton FirstViewButton { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton FourthViewButton { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton SecondViewButton { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton ThirdViewButton { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (FirstViewButton != null) {
				FirstViewButton.Dispose ();
				FirstViewButton = null;
			}

			if (FourthViewButton != null) {
				FourthViewButton.Dispose ();
				FourthViewButton = null;
			}

			if (SecondViewButton != null) {
				SecondViewButton.Dispose ();
				SecondViewButton = null;
			}

			if (ThirdViewButton != null) {
				ThirdViewButton.Dispose ();
				ThirdViewButton = null;
			}

			if (FifthViewButton != null) {
				FifthViewButton.Dispose ();
				FifthViewButton = null;
			}
		}
	}
}
