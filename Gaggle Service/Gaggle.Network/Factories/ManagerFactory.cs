using GaggleService.Gaggle.Managers;
using GaggleService.Gaggle.Storage.Managers;
using GaggleService.Storage.Objects.Account;

namespace GaggleService.Gaggle.Network.Factories
{
    public class ManagerFactory
    {
        public static AccountManager Create(StorageManager<IAccountData> storageManager)
        {
            return new AccountManager(storageManager);
        }
    }
}
