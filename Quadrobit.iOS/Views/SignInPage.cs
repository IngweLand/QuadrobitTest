#region Author

// Author ILYA GOLOVACH (aka IngweLand)
// http://ingweland.com
// ingweland@gmail.com
// Created: 06 03 2019

#endregion

#region

using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Ios.Presenters.Attributes;
using MvvmCross.Platforms.Ios.Views;
using Quadrobit.ViewModels;
using UIKit;

#endregion

namespace Quadrobit.iOS.Views
{
    [MvxRootPresentation(WrapInNavigationController = true)]
    public partial class SignInPage : MvxViewController<SignInPageViewModel>
    {
        public SignInPage() : base("SignInPage", null)
        {
        }

        #region View lifecycle

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);

            NavigationController.NavigationBarHidden = true;
        }

        public override void ViewWillDisappear(bool animated)
        {
            base.ViewWillDisappear(animated);

            View.EndEditing(true);
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var set = this.CreateBindingSet<SignInPage, SignInPageViewModel>();
            set.Bind(UsernameTF).To(vm => vm.Username);
            set.Bind(PasswordTF).To(vm => vm.Password);
            set.Bind(SignInBtn).To(vm => vm.SignInCommand);
            set.Apply();
        }

        #endregion
    }
}