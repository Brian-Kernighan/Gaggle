using GaggleService.Gaggle.Common;
using GaggleService.Gaggle.Helpers;
using GaggleService.Gaggle.Managers;
using GaggleService.Gaggle.Network.Assemblers;
using GaggleService.Gaggle.Network.Factories;
using GaggleService.Storage.Caches;
using GaggleService.Storage.Objects.Account;

namespace GaggleService.Network
{
    public class ServiceMethods : IServiceMethods
    {     
        public void Logoff()
        {
            OperationContext.Execute(() =>
            {
                ManagerFactory<AccountManager>.CreateManager().Logoff();
            }, "Logoff");
        }

        public void Register(string email, string password, string name)
        {
            OperationContext.Execute(() =>
            {
                //todo: I don't like the DefaultConnectionSettings.. Fucking shit!          
                var cachedStorage = StorageManagerCache<IAccountData>.Instance.GetCachedStorage(DefaultConnectionSettings.GetConnectionSettings(DefaultCollectionName.AccountData));
                ManagerFactory.Create(cachedStorage).Register(email, password, name);
            }, "Register", email, password, name);
        }

        public byte[] Authorize(string email, string password)
        {
            return OperationContext<byte[]>.Execute(() =>
            {
                return Assembler.Assembly(ManagerFactory<AccountManager>.CreateManager().Authorize(email, password));
            }, "Authorize", email, password);
        }
    }
}
