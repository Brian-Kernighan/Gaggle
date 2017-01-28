using GaggleService.Gaggle.Objects;
using GaggleService.Gaggle.Storage.Managers;
using GaggleService.Storage.Objects.Account;
using GaggleService.Storage.Repositories.Account;
using System;

namespace GaggleService.Gaggle.Managers
{
    public class AccountManager
    {
        private readonly StorageManager<IAccountData> _storageManager;


        public AccountManager(StorageManager<IAccountData> storageManager)
        {
            _storageManager = storageManager;
        }


        internal void Logoff()
        {
            throw new NotImplementedException();
        }

        internal void Register(string email, string password, string name)
        {
            if (string.IsNullOrEmpty(email))
            {
                throw new ArgumentException("parameter is null or valid", "email");
            }

            if (string.IsNullOrEmpty(password))
            {
                throw new ArgumentException("parameter is null or valid", "password");
            }

            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("parameter is null or valid", "name");
            }

            var repository = new AccountRepository(_storageManager.GetRepository());

            repository.Register(email, password, name);
        }

        internal User Authorize(string email, string password)
        {
            var repository = new AccountRepository<IAccountData>(_storageManager.StorageCollection);

            //repository.Login(email, password);

            throw new NotImplementedException();
        }
    }
}
