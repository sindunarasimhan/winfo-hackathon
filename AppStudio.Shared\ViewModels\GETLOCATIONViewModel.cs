using System;
using System.Windows;
using System.Windows.Input;

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

using AppStudio.Services;
using AppStudio.Data;

namespace AppStudio.ViewModels
{
    public class GETLOCATIONViewModel : ViewModelBase<GETLOCATIONSchema>
    {
        private RelayCommandEx<GETLOCATIONSchema> itemClickCommand;
        public RelayCommandEx<GETLOCATIONSchema> ItemClickCommand
        {
            get
            {
                if (itemClickCommand == null)
                {
                    itemClickCommand = new RelayCommandEx<GETLOCATIONSchema>(
                        (item) =>
                        {
                            NavigationServices.NavigateToPage("GETLOCATIONDetail", item);
                        });
                }

                return itemClickCommand;
            }
        }

        override protected DataSourceBase<GETLOCATIONSchema> CreateDataSource()
        {
            return new GETLOCATIONDataSource(); // CollectionDataSource
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
            NavigationServices.NavigateToPage("GETLOCATIONList");
        }

        override protected void NavigateToSelectedItem()
        {
            NavigationServices.NavigateToPage("GETLOCATIONDetail");
        }
    }
}
