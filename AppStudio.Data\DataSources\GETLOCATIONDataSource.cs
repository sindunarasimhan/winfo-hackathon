using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppStudio.Data
{
    public class GETLOCATIONDataSource : DataSourceBase<GETLOCATIONSchema>
    {
        private const string _file = "/Assets/Data/GETLOCATIONDataSource.json";

        protected override string CacheKey
        {
            get { return "GETLOCATIONDataSource"; }
        }

        public override bool HasStaticData
        {
            get { return true; }
        }

        public async override Task<IEnumerable<GETLOCATIONSchema>> LoadDataAsync()
        {
            try
            {
                var serviceDataProvider = new StaticDataProvider(_file);
                return await serviceDataProvider.Load<GETLOCATIONSchema>();
            }
            catch (Exception ex)
            {
                AppLogs.WriteError("GETLOCATIONDataSource.LoadData", ex.ToString());
                return new GETLOCATIONSchema[0];
            }
        }
    }
}
