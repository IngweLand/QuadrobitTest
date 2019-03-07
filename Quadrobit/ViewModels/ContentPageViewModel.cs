#region Author

// Author ILYA GOLOVACH (aka IngweLand)
// http://ingweland.com
// ingweland@gmail.com
// Created: 06 03 2019

#endregion

#region

using System;
using System.Threading.Tasks;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using Quadrobit.Abstractions;
using Quadrobit.Models;

#endregion

namespace Quadrobit.ViewModels
{
    public class ContentPageViewModel : MvxViewModel<SignInCredentials>
    {
        private readonly IApiService _apiService;
        private readonly IDataRepository _dataRepository;
        private readonly IMvxNavigationService _navigationService;
        private MvxObservableCollection<DataEntry> _dataEntries;

        public ContentPageViewModel(IApiService apiService, IMvxNavigationService navigationService,
            IDataRepository dataRepository)
        {
            _apiService = apiService;
            _navigationService = navigationService;
            _dataRepository = dataRepository;
        }

        public IMvxCommand AddEntryCommand => new MvxCommand(async () => await addEntry());
        public IMvxCommand LogoutCommand => new MvxCommand(async () => await logout());

        private async Task logout()
        {
            await _apiService.Logout();
            await _navigationService.Close(this);
        }

        public MvxObservableCollection<DataEntry> DataEntries
        {
            get => _dataEntries;
            set => SetProperty(ref _dataEntries, value);
        }

        public IMvxCommand RemoveEntryCommand => new MvxCommand(async () => await removeEntry());
        public SignInCredentials SignInCredentials { get; private set; }

        public override async Task Initialize()
        {
            DataEntries = new MvxObservableCollection<DataEntry>(await _dataRepository.GetAllEntries());
        }

        public override void Prepare(SignInCredentials parameter)
        {
            SignInCredentials = parameter;
        }

        private async Task addEntry()
        {
            var entry = new DataEntry
            {
                Title = Guid.NewGuid().ToString().Substring(0, 20),
                Subtitle = Guid.NewGuid().ToString("N").Substring(0, 12),
                Date = DateTime.Now.ToLongTimeString()
            };

            await _dataRepository.AddEntry(entry);

            DataEntries.Add(entry);
        }

        private async Task removeEntry()
        {
            if (DataEntries.Count == 0)
            {
                return;
            }

            var key = DataEntries[0].Id;
            await _dataRepository.RemoveEntry(key);
            DataEntries.RemoveAt(0);
        }
    }
}