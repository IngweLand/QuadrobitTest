// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace Quadrobit.iOS.Views
{
    [Register ("SignInPage")]
    partial class SignInPage
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField PasswordTF { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton SignInBtn { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField UsernameTF { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (PasswordTF != null) {
                PasswordTF.Dispose ();
                PasswordTF = null;
            }

            if (SignInBtn != null) {
                SignInBtn.Dispose ();
                SignInBtn = null;
            }

            if (UsernameTF != null) {
                UsernameTF.Dispose ();
                UsernameTF = null;
            }
        }
    }
}