using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppStudio.Data
{
    public class RecyclingSourcesDataSource : DataSourceBase<RecyclingSourcesSchema>
    {
        private const string _file = "/Assets/Data/RecyclingSourcesDataSource.json";

        protected override string CacheKey
        {
            get { return "RecyclingSourcesDataSource"; }
        }

        public override bool HasStaticData
        {
            get { return true; }
        }

        public async override Task<IEnumerable<RecyclingSourcesSchema>> LoadDataAsync()
        {
            try
            {
                var serviceDataProvider = new StaticDataProvider(_file);
                return await serviceDataProvider.Load<RecyclingSourcesSchema>();
            }
            catch (Exception ex)
            {
                AppLogs.WriteError("RecyclingSourcesDataSource.LoadData", ex.ToString());
                return new RecyclingSourcesSchema[0];
            }
        }
    }
}
