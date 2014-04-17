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
	[Register ("FourthViewController")]
	partial class FourthViewController
	{
		[Outlet]
		MonoTouch.UIKit.UILabel LatLabel { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel LonLabel { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton StartGpsButton { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (LatLabel != null) {
				LatLabel.Dispose ();
				LatLabel = null;
			}

			if (LonLabel != null) {
				LonLabel.Dispose ();
				LonLabel = null;
			}

			if (StartGpsButton != null) {
				StartGpsButton.Dispose ();
				StartGpsButton = null;
			}
		}
	}
}
