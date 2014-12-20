using System;
using System.Windows;
using System.Windows.Input;

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

using AppStudio.Services;
using AppStudio.Data;

namespace AppStudio.ViewModels
{
    public class StatsViewModel : ViewModelBase<StatsSchema>
    {
        private RelayCommandEx<StatsSchema> itemClickCommand;
        public RelayCommandEx<StatsSchema> ItemClickCommand
        {
            get
            {
                if (itemClickCommand == null)
                {
                    itemClickCommand = new RelayCommandEx<StatsSchema>(
                        (item) =>
                        {
                            NavigationServices.NavigateToPage("StatsDetail", item);
                        });
                }

                return itemClickCommand;
            }
        }

        override protected DataSourceBase<StatsSchema> CreateDataSource()
        {
            return new StatsDataSource(); // CollectionDataSource
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
            NavigationServices.NavigateToPage("StatsList");
        }

        override protected void NavigateToSelectedItem()
        {
            NavigationServices.NavigateToPage("StatsDetail");
        }
    }
}
