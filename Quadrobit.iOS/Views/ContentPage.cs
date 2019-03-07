#region Author

// Author ILYA GOLOVACH (aka IngweLand)
// http://ingweland.com
// ingweland@gmail.com
// Created: 07 03 2019

#endregion

#region

using System;
using System.Threading.Tasks;
using Foundation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Ios.Binding.Views;
using MvvmCross.Platforms.Ios.Views;
using Quadrobit.ViewModels;
using UIKit;

#endregion

namespace Quadrobit.iOS.Views
{
    public partial class ContentPage : MvxViewController<ContentPageViewModel>
    {
        private int _currentView = 0;
        private MvxSimpleTableViewSource _tableSource;

        public ContentPage() : base("ContentPage", null)
        {
        }

        private void changeView()
        {
            switch (_currentView)
            {
                case 1:
                {
                    showDataView();
                    break;
                }

                case 2:
                {
                    showLogoutView();
                    break;
                }

                default:
                {
                    showLoginCredentialsView();
                    break;
                }
            }
        }

        private void showDataView()
        {
            FirstTabContentCntr.Hidden = LogoutBtn.Hidden = true;
            AddEntryBtn.Hidden = RemoveEntryBtn.Hidden = false;
        }

        private void showLoginCredentialsView()
        {
            AddEntryBtn.Hidden = RemoveEntryBtn.Hidden = LogoutBtn.Hidden = true;
            FirstTabContentCntr.Hidden = false;
        }

        private void showLogoutView()
        {
            AddEntryBtn.Hidden = RemoveEntryBtn.Hidden = FirstTabContentCntr.Hidden = true;
            LogoutBtn.Hidden = false;
        }

        #region View lifecycle

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            _tableSource = new MvxSimpleTableViewSource(DataTable, DataEntryCell.Key, DataEntryCell.Key);

            var set = this.CreateBindingSet<ContentPage, ContentPageViewModel>();
            set.Bind(UsernameLbl).To(vm => vm.SignInCredentials.Username);
            set.Bind(PasswordLbl).To(vm => vm.SignInCredentials.Password);
            set.Bind(AddEntryBtn).To(vm => vm.AddEntryCommand);
            set.Bind(RemoveEntryBtn).To(vm => vm.RemoveEntryCommand);
            set.Bind(LogoutBtn).To(vm => vm.LogoutCommand);
            set.Bind(_tableSource).To(vm => vm.DataEntries);
            set.Apply();

            DataTable.RowHeight = 60;
            DataTable.Source = _tableSource;
            DataTable.ReloadData();

            SwitchViewSC.ValueChanged += switchViewScOnValueChanged;

            AddEntryBtn.TouchUpInside += addEntryBtnOnTouchUpInside;
            RemoveEntryBtn.TouchUpInside += removeEntryBtnOnTouchUpInside;
        }

        private async void removeEntryBtnOnTouchUpInside(object sender, EventArgs e)
        {
            await Task.Delay(100);
            var index = NSIndexPath.FromRowSection(0, 0);
            DataTable.ScrollToRow(index, UITableViewScrollPosition.Bottom, true);
        }

        private async void addEntryBtnOnTouchUpInside(object sender, EventArgs e)
        {
            await Task.Delay(100);
            var index = NSIndexPath.FromRowSection(_tableSource.RowsInSection(DataTable, 0) - 1, 0);
            DataTable.ScrollToRow(index, UITableViewScrollPosition.Bottom, true);
        }

        private void switchViewScOnValueChanged(object sender, EventArgs e)
        {
            _currentView = (int) SwitchViewSC.SelectedSegment;
            changeView();
        }

        #endregion
    }
}