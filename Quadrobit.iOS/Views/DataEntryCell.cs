using System;

using Foundation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Ios.Binding.Views;
using Quadrobit.Models;
using UIKit;

namespace Quadrobit.iOS.Views
{
    public partial class DataEntryCell : MvxTableViewCell
    {
        public static readonly NSString Key = new NSString("DataEntryCell");
        public static readonly UINib Nib;

        static DataEntryCell()
        {
            Nib = UINib.FromName("DataEntryCell", NSBundle.MainBundle);
        }

        protected DataEntryCell(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.

            this.DelayBind(() =>
            {
                var set = this.CreateBindingSet<DataEntryCell, DataEntry>();
                set.Bind(TitleLbl).To(m => m.Title);
                set.Bind(SubtitleLbl).To(m => m.Subtitle);
                set.Bind(DateLbl).To(m => m.Date);
                set.Apply();
            });
        }
    }
}
