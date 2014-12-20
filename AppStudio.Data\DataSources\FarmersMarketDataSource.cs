using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppStudio.Data
{
    public class FarmersMarketDataSource : DataSourceBase<FarmersMarketSchema>
    {
        private const string _file = "/Assets/Data/FarmersMarketDataSource.json";

        protected override string CacheKey
        {
            get { return "FarmersMarketDataSource"; }
        }

        public override bool HasStaticData
        {
            get { return true; }
        }

        public async override Task<IEnumerable<FarmersMarketSchema>> LoadDataAsync()
        {
            try
            {
                var serviceDataProvider = new StaticDataProvider(_file);
                return await serviceDataProvider.Load<FarmersMarketSchema>();
            }
            catch (Exception ex)
            {
                AppLogs.WriteError("FarmersMarketDataSource.LoadData", ex.ToString());
                return new FarmersMarketSchema[0];
            }
        }
    }
}
