// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;
using System.CodeDom.Compiler;

namespace Starter
{
	[Register ("SecondViewController")]
	partial class SecondViewController
	{
		[Outlet]
		MonoTouch.UIKit.UILabel LabelStatus { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton RegisterButton { get; set; }

		[Outlet]
		MonoTouch.UIKit.UISwitch ToggleAgreed { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (RegisterButton != null) {
				RegisterButton.Dispose ();
				RegisterButton = null;
			}

			if (ToggleAgreed != null) {
				ToggleAgreed.Dispose ();
				ToggleAgreed = null;
			}

			if (LabelStatus != null) {
				LabelStatus.Dispose ();
				LabelStatus = null;
			}
		}
	}
}
