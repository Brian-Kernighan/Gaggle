using GaggleService.Storage.Objects.Account;
using MongoDB.Driver;
using System;

namespace GaggleService.Storage.Repositories.Account
{
    public class AccountRepository : IAccountRepository
    {
        private IMongoCollection<IAccountData> _storageCollection;

        public AccountRepository()
        {

        }

        public AccountRepository(IMongoCollection<IAccountData> storageCollection)
        {
            _storageCollection = storageCollection;
        }

        internal void Register(string email, string password, string name)
        {
            throw new NotImplementedException();

            //_storageCollection.InsertOne(entity);

            //return entity;
        }
















        //public T CreateAccount(T entity)
        //{
        //    _storageCollection.InsertOne(entity);

        //    return entity;
        //}

        //public bool TryGetAccountById(Guid id, out IAccountData entity)
        //{
        //    entity = null;

        //    var result = _storageCollection.Find(x => x.Id.Equals(id));

        //    if (!result.Any())
        //    {
        //        return false;
        //    }
     
        //    entity = result.First();

        //    return true;
        //}

        //public bool TryGetAccountByEmail(string email, out IAccountData entity)
        //{
        //    entity = null;

        //    var result = _storageCollection.Find(x => x.Name.Equals(email));

        //    if (!result.Any())
        //    {
        //        return false;
        //    }

        //    entity = result.First();

        //    return true;
        //}

        //public IAccountData GetAccountById(Guid id)
        //{
        //    var result = _storageCollection.Find(x => x.Id.Equals(id));

        //    if (!result.Any())
        //    {
        //        throw new Exception(string.Format("Account with ID \"{0}\" was not found", id));
        //    }

        //    return result.First();
        //}

        //public IAccountData GetAccountByEmail(string email)
        //{
        //    var result = _storageCollection.Find(x => x.Name.Equals(email));

        //    if (!result.Any())
        //    {
        //        throw new Exception(string.Format("Account with name \"{0}\" was not found", email));
        //    }

        //    return result.First();
        //}

        //public async Task<T> CreateAccountAsync(T entity, CancellationToken token = default(CancellationToken))
        //{
        //    await _storageCollection.InsertOneAsync(entity, null, token);

        //    return entity;
        //}

        //public async Task<IAccountData> GetAccountByIdAsync(Guid id, CancellationToken token = default(CancellationToken))
        //{
        //    var result = await _storageCollection.FindAsync(x => x.Id.Equals(id));

        //    if (!result.Any())
        //    {
        //        throw new Exception(string.Format("Account with ID \"{0}\" was not found", id));
        //    }

        //    return result.First();
        //}

        //public async Task<IAccountData> GetAccountByNameAsync(string name, CancellationToken token = default(CancellationToken))
        //{
        //    var result = await _storageCollection.FindAsync(x => x.Name.Equals(name));

        //    if (!result.Any())
        //    {
        //        throw new Exception(string.Format("Account with name \"{0}\" was not found", name));
        //    }

        //    return result.First();
        //}
    }
}