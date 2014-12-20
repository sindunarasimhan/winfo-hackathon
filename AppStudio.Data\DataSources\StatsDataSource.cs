using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppStudio.Data
{
    public class StatsDataSource : DataSourceBase<StatsSchema>
    {
        private const string _file = "/Assets/Data/StatsDataSource.json";

        protected override string CacheKey
        {
            get { return "StatsDataSource"; }
        }

        public override bool HasStaticData
        {
            get { return true; }
        }

        public async override Task<IEnumerable<StatsSchema>> LoadDataAsync()
        {
            try
            {
                var serviceDataProvider = new StaticDataProvider(_file);
                return await serviceDataProvider.Load<StatsSchema>();
            }
            catch (Exception ex)
            {
                AppLogs.WriteError("StatsDataSource.LoadData", ex.ToString());
                return new StatsSchema[0];
            }
        }
    }
}
