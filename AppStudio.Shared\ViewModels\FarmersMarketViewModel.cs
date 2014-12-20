using System;
using System.Windows;
using System.Windows.Input;

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

using AppStudio.Services;
using AppStudio.Data;

namespace AppStudio.ViewModels
{
    public class FarmersMarketViewModel : ViewModelBase<FarmersMarketSchema>
    {
        private RelayCommandEx<FarmersMarketSchema> itemClickCommand;
        public RelayCommandEx<FarmersMarketSchema> ItemClickCommand
        {
            get
            {
                if (itemClickCommand == null)
                {
                    itemClickCommand = new RelayCommandEx<FarmersMarketSchema>(
                        (item) =>
                        {
                            NavigationServices.NavigateToPage("FarmersMarketDetail", item);
                        });
                }

                return itemClickCommand;
            }
        }

        override protected DataSourceBase<FarmersMarketSchema> CreateDataSource()
        {
            return new FarmersMarketDataSource(); // CollectionDataSource
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
            NavigationServices.NavigateToPage("FarmersMarketList");
        }

        override protected void NavigateToSelectedItem()
        {
            NavigationServices.NavigateToPage("FarmersMarketDetail");
        }
    }
}
