using System;
using System.Net.NetworkInformation;

using AppStudio.Services;
using AppStudio.ViewModels;

using Windows.ApplicationModel.DataTransfer;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace AppStudio.Views
{
    public sealed partial class RecyclingSourcesDetail : Page
    {
        private NavigationHelper _navigationHelper;

        private DataTransferManager _dataTransferManager;

        public RecyclingSourcesDetail()
        {
            this.InitializeComponent();
            _navigationHelper = new NavigationHelper(this);

            RecyclingSourcesModel = new RecyclingSourcesViewModel();

            ApplicationView.GetForCurrentView().
                SetDesiredBoundsMode(ApplicationViewBoundsMode.UseVisible);
        }

        public RecyclingSourcesViewModel RecyclingSourcesModel { get; private set; }

        public NavigationHelper NavigationHelper
        {
            get { return _navigationHelper; }
        }

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            _dataTransferManager = DataTransferManager.GetForCurrentView();
            _dataTransferManager.DataRequested += OnDataRequested;

            _navigationHelper.OnNavigatedTo(e);

            if (RecyclingSourcesModel != null)
            {
                await RecyclingSourcesModel.LoadItemsAsync();
                if (e.NavigationMode != NavigationMode.Back)
                {
                    RecyclingSourcesModel.SelectItem(e.Parameter);
                }

                RecyclingSourcesModel.ViewType = ViewTypes.Detail;
            }
            DataContext = this;
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            _navigationHelper.OnNavigatedFrom(e);
            _dataTransferManager.DataRequested -= OnDataRequested;
        }

        private void OnDataRequested(DataTransferManager sender, DataRequestedEventArgs args)
        {
            if (RecyclingSourcesModel != null)
            {
                RecyclingSourcesModel.GetShareContent(args.Request);
            }
        }
    }
}
