using System;

using Windows.ApplicationModel;

namespace AppStudio.ViewModels
{
    public class AboutThisAppViewModel
    {
        public string Publisher
        {
            get
            {
                return "AppStudio";
            }
        }

        public string AppVersion
        {
            get
            {
                return string.Format("{0}.{1}.{2}.{3}", Package.Current.Id.Version.Major, Package.Current.Id.Version.Minor, Package.Current.Id.Version.Build, Package.Current.Id.Version.Revision);
            }
        }

        public string AboutText
        {
            get
            {
                return "Do you live in an awesome city? Is there a city you’ve fallen in love with but ha" +
    "ven’t yet visited? A full tutorial to build this app exists in the videos found " +
    "at http://aka.ms/appstudioeducation.";
            }
        }
    }
}

