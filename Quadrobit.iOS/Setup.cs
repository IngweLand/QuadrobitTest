#region Author

// Author ILYA GOLOVACH (aka IngweLand)
// http://ingweland.com
// ingweland@gmail.com
// Created: 07 03 2019

#endregion

#region

using MvvmCross;
using MvvmCross.IoC;
using MvvmCross.Platforms.Ios.Core;
using Quadrobit.Abstractions;
using Quadrobit.iOS.Services;

#endregion

namespace Quadrobit.iOS
{
    public class Setup : MvxIosSetup<App>
    {
        protected override void InitializeFirstChance()
        {
            base.InitializeFirstChance();

           Mvx.IoCProvider.LazyConstructAndRegisterSingleton<ISqliteConnectionService, IosSqliteConnectionService>();
        }
    }
}