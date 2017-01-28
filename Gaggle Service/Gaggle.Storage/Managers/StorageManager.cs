using System;
using GaggleService.Gaggle.Helpers;
using GaggleService.Storage.Caches;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver;
using GaggleService.Storage.Objects.Account;

namespace GaggleService.Gaggle.Storage.Managers
{
    public class StorageManager
    {
        public static void RegisterWellKnownTypes()
        {
            BsonSerializer.RegisterSerializer(new ImpliedImplementationInterfaceSerializer<IAccountData, AccountData>(BsonSerializer.LookupSerializer<AccountData>()));
        }
    }

    public class StorageManager<T>
    {
        //-----

        private readonly IMongoCollection<T> _collection;

        //-----

        public StorageManager(string connectionString, string databaseName, string collectionName)
        {
            _collection = GetCollection(connectionString, databaseName, collectionName);
        }

        //-----

        public static StorageManager<T> GetCachedStorageManager(DefaultConnectionSettings connectionSettings)
        {
            var storageManager = StorageManagerCache<T>.Instance.GetCachedStorage(connectionSettings);

            return storageManager;
        }

        internal IMongoCollection<T> GetRepository()
        {
            return _collection;
        }

        //-----

        private static IMongoCollection<T> GetCollection(string connectionString, string databaseName, string collectionName)
        {
            return (new MongoClient(new MongoUrl(connectionString)).GetDatabase(databaseName).GetCollection<T>(collectionName));
        }

        //-----
    }
}
