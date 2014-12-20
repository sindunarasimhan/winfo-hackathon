using System;
using System.Windows;
using System.Windows.Input;

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

using AppStudio.Services;
using AppStudio.Data;

namespace AppStudio.ViewModels
{
    public class LetsTalkWaterViewModel : ViewModelBase<LetsTalkWaterSchema>
    {
        private RelayCommandEx<LetsTalkWaterSchema> itemClickCommand;
        public RelayCommandEx<LetsTalkWaterSchema> ItemClickCommand
        {
            get
            {
                if (itemClickCommand == null)
                {
                    itemClickCommand = new RelayCommandEx<LetsTalkWaterSchema>(
                        (item) =>
                        {
                            NavigationServices.NavigateToPage("LetsTalkWaterDetail", item);
                        });
                }

                return itemClickCommand;
            }
        }

        override protected DataSourceBase<LetsTalkWaterSchema> CreateDataSource()
        {
            return new LetsTalkWaterDataSource(); // CollectionDataSource
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
            NavigationServices.NavigateToPage("LetsTalkWaterList");
        }

        override protected void NavigateToSelectedItem()
        {
            NavigationServices.NavigateToPage("LetsTalkWaterDetail");
        }
    }
}
