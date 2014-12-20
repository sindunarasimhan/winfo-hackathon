using System;
using System.Windows;
using System.Windows.Input;

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

using AppStudio.Services;
using AppStudio.Data;

namespace AppStudio.ViewModels
{
    public class RecyclingSourcesViewModel : ViewModelBase<RecyclingSourcesSchema>
    {
        private RelayCommandEx<RecyclingSourcesSchema> itemClickCommand;
        public RelayCommandEx<RecyclingSourcesSchema> ItemClickCommand
        {
            get
            {
                if (itemClickCommand == null)
                {
                    itemClickCommand = new RelayCommandEx<RecyclingSourcesSchema>(
                        (item) =>
                        {
                            NavigationServices.NavigateToPage("RecyclingSourcesDetail", item);
                        });
                }

                return itemClickCommand;
            }
        }

        override protected DataSourceBase<RecyclingSourcesSchema> CreateDataSource()
        {
            return new RecyclingSourcesDataSource(); // CollectionDataSource
        }


        public RelayCommandEx<Slider> IncreaseSlider
        {
            get
            {
                return new RelayCommandEx<Slider>(s => s.Value++);
            }
        }

        public RelayCommandEx<Slider> DecreaseSlider
        {
            get
            {
                return new RelayCommandEx<Slider>(s => s.Value--);
            }
        }

        override public void NavigateToSectionList()
        {
            NavigationServices.NavigateToPage("RecyclingSourcesList");
        }

        override protected void NavigateToSelectedItem()
        {
            NavigationServices.NavigateToPage("RecyclingSourcesDetail");
        }
    }
}
