// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace PhoneApp.iOS
{
    [Register ("ViewController")]
    partial class ViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnLlamar { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnTranslate { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField PhoneNumberText { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel txtPhoneNumber { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (btnLlamar != null) {
                btnLlamar.Dispose ();
                btnLlamar = null;
            }

            if (btnTranslate != null) {
                btnTranslate.Dispose ();
                btnTranslate = null;
            }

            if (PhoneNumberText != null) {
                PhoneNumberText.Dispose ();
                PhoneNumberText = null;
            }

            if (txtPhoneNumber != null) {
                txtPhoneNumber.Dispose ();
                txtPhoneNumber = null;
            }
        }
    }
}