using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppStudio.Data
{
    public class LetsTalkWaterDataSource : DataSourceBase<LetsTalkWaterSchema>
    {
        private const string _file = "/Assets/Data/LetsTalkWaterDataSource.json";

        protected override string CacheKey
        {
            get { return "LetsTalkWaterDataSource"; }
        }

        public override bool HasStaticData
        {
            get { return true; }
        }

        public async override Task<IEnumerable<LetsTalkWaterSchema>> LoadDataAsync()
        {
            try
            {
                var serviceDataProvider = new StaticDataProvider(_file);
                return await serviceDataProvider.Load<LetsTalkWaterSchema>();
            }
            catch (Exception ex)
            {
                AppLogs.WriteError("LetsTalkWaterDataSource.LoadData", ex.ToString());
                return new LetsTalkWaterSchema[0];
            }
        }
    }
}
