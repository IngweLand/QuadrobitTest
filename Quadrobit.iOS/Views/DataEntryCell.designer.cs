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
    [Register ("DataEntryCell")]
    partial class DataEntryCell
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel DateLbl { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel SubtitleLbl { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel TitleLbl { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (DateLbl != null) {
                DateLbl.Dispose ();
                DateLbl = null;
            }

            if (SubtitleLbl != null) {
                SubtitleLbl.Dispose ();
                SubtitleLbl = null;
            }

            if (TitleLbl != null) {
                TitleLbl.Dispose ();
                TitleLbl = null;
            }
        }
    }
}