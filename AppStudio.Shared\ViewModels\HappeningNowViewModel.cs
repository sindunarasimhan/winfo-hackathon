using System;
using System.Windows;
using System.Windows.Input;

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

using AppStudio.Services;
using AppStudio.Data;

namespace AppStudio.ViewModels
{
    public class HappeningNowViewModel : ViewModelBase<HappeningNowSchema>
    {
        private RelayCommandEx<HappeningNowSchema> itemClickCommand;
        public RelayCommandEx<HappeningNowSchema> ItemClickCommand
        {
            get
            {
                if (itemClickCommand == null)
                {
                    itemClickCommand = new RelayCommandEx<HappeningNowSchema>(
                        (item) =>
                        {
                            NavigationServices.NavigateToPage("HappeningNowDetail", item);
                        });
                }

                return itemClickCommand;
            }
        }

        override protected DataSourceBase<HappeningNowSchema> CreateDataSource()
        {
            return new HappeningNowDataSource(); // CollectionDataSource
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
            NavigationServices.NavigateToPage("HappeningNowList");
        }

        override protected void NavigateToSelectedItem()
        {
            NavigationServices.NavigateToPage("HappeningNowDetail");
        }
    }
}
