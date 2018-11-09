namespace Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using CS_OOP_Advanced_Exam_Prep_July_2016.Models.Shops;
    using CS_OOP_Advanced_Exam_Prep_July_2016.Providers.Data;
    using CS_OOP_Advanced_Exam_Prep_July_2016.Providers.TypeProvider;

    public static class DatabaseUtils
    {
        public static IDataProvider CreateDataProvider()
        {
            var shops = new Dictionary<string, IShop>();
            var mall = new Mall(null);
            var bazaar = new Bazaar(mall);
            var store = new Store(bazaar);
            shops.Add("Mall", mall);
            shops.Add("Bazaar", bazaar);
            shops.Add("Store", store);
            return new MarketDataProvider(shops, new TypeProvider(typeof(IShop).Assembly));
        }
    }
}