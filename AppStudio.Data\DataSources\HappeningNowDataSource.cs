using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppStudio.Data
{
    public class HappeningNowDataSource : DataSourceBase<HappeningNowSchema>
    {
        private const string _file = "/Assets/Data/HappeningNowDataSource.json";

        protected override string CacheKey
        {
            get { return "HappeningNowDataSource"; }
        }

        public override bool HasStaticData
        {
            get { return true; }
        }

        public async override Task<IEnumerable<HappeningNowSchema>> LoadDataAsync()
        {
            try
            {
                var serviceDataProvider = new StaticDataProvider(_file);
                return await serviceDataProvider.Load<HappeningNowSchema>();
            }
            catch (Exception ex)
            {
                AppLogs.WriteError("HappeningNowDataSource.LoadData", ex.ToString());
                return new HappeningNowSchema[0];
            }
        }
    }
}
