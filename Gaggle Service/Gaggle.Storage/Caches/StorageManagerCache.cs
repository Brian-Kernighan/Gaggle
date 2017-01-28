using GaggleService.Gaggle.Helpers;
using GaggleService.Gaggle.Storage.Managers;
using System;
using System.Collections.Concurrent;

namespace GaggleService.Storage.Caches
{
    public class StorageManagerCache<T>
    {
        //-----

        private static ConcurrentDictionary<Tuple<string, string, string>, StorageManager<T>> _collectionPool;

        //-----

        public static StorageManagerCache<T> Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new StorageManagerCache<T>();
                }

                if (_collectionPool == null)
                {
                    _collectionPool = new ConcurrentDictionary<Tuple<string, string, string>, StorageManager<T>>();
                }

                return _instance;
            }
        }
        private static StorageManagerCache<T> _instance;

        //-----

        public StorageManager<T> GetCachedStorage(DefaultConnectionSettings connection)
        {
            var key = Tuple.Create(connection.ConnectionString, connection.DatabaseName, connection.CollectionName);

            if (!_collectionPool.TryGetValue(key, out var collection))
            {
                var storageManager = new StorageManager<T>(connection.ConnectionString, connection.DatabaseName, connection.CollectionName);

                _collectionPool.TryAdd(key, storageManager);

                return storageManager;
            }
            else
            {
                return collection;
            }
        }

        //-----
    }
}
