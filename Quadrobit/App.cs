#region Author

// Author ILYA GOLOVACH (aka IngweLand)
// http://ingweland.com
// ingweland@gmail.com
// Created: 06 03 2019

#endregion

#region

using MvvmCross.IoC;
using MvvmCross.ViewModels;
using Quadrobit.ViewModels;

#endregion

namespace Quadrobit
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();

            CreatableTypes()
                .EndingWith("Repository")
                .AsInterfaces()
                .RegisterAsLazySingleton();

            RegisterAppStart<SignInPageViewModel>();
        }
    }
}