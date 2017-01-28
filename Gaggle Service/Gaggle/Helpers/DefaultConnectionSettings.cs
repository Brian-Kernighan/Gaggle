using System;

namespace GaggleService.Gaggle.Helpers
{
    public class DefaultConnectionSettings
    {

        public DefaultConnectionSettings(string connectionString, string databseName, string collectionName)
        {
            ConnectionString = connectionString;
            DatabaseName = databseName;
            CollectionName = collectionName;
        }


        public string DatabaseName { get; private set; }

        public string CollectionName { get; private set; }

        public string ConnectionString { get; private set; }


        public static DefaultConnectionSettings GetConnectionSettings(string collectionName)
        {
            return new DefaultConnectionSettings("mongodb://127.0.0.1:27017", "Gaggle", collectionName);
        }

        internal static object GetConnectionSettings(object collectionNames)
        {
            throw new NotImplementedException();
        }
    }
}
