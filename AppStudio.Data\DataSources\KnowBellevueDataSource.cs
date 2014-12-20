using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppStudio.Data
{
    public class KnowBellevueDataSource : DataSourceBase<MenuSchema>
    {
        private const string _file = "/Assets/Data/KnowBellevueDataSource.json";

        protected override string CacheKey
        {
            get { return "KnowBellevueDataSource"; }
        }

        public override bool HasStaticData
        {
            get { return true; }
        }

        public async override Task<IEnumerable<MenuSchema>> LoadDataAsync()
        {
            try
            {
                var serviceDataProvider = new StaticDataProvider(_file);
                return await serviceDataProvider.Load<MenuSchema>();
            }
            catch (Exception ex)
            {
                AppLogs.WriteError("KnowBellevueDataSource.LoadData", ex.ToString());
                return new MenuSchema[0];
            }
        }

    }
}
