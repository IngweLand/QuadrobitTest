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
    [Register ("ContentPage")]
    partial class ContentPage
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton AddEntryBtn { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITableView DataTable { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIStackView FirstTabContentCntr { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton LogoutBtn { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel PasswordLbl { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton RemoveEntryBtn { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UISegmentedControl SwitchViewSC { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel UsernameLbl { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (AddEntryBtn != null) {
                AddEntryBtn.Dispose ();
                AddEntryBtn = null;
            }

            if (DataTable != null) {
                DataTable.Dispose ();
                DataTable = null;
            }

            if (FirstTabContentCntr != null) {
                FirstTabContentCntr.Dispose ();
                FirstTabContentCntr = null;
            }

            if (LogoutBtn != null) {
                LogoutBtn.Dispose ();
                LogoutBtn = null;
            }

            if (PasswordLbl != null) {
                PasswordLbl.Dispose ();
                PasswordLbl = null;
            }

            if (RemoveEntryBtn != null) {
                RemoveEntryBtn.Dispose ();
                RemoveEntryBtn = null;
            }

            if (SwitchViewSC != null) {
                SwitchViewSC.Dispose ();
                SwitchViewSC = null;
            }

            if (UsernameLbl != null) {
                UsernameLbl.Dispose ();
                UsernameLbl = null;
            }
        }
    }
}