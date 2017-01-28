using GaggleService.Gaggle.Network.Managers;
using GaggleService.Gaggle.Storage.Managers;
using System.Threading;

namespace GaggleService.Gaggle
{
    public static class GaggleEngine
    {
        //todo: Rework ZMQ requests
        //todo: Maybe 

        private static GaggleSettings _gaggleSettings;

        public static void Start(GaggleSettings gaggleSettings, CancellationTokenSource cancellationTokenSource)
        {
            _gaggleSettings = gaggleSettings;

            StorageManager.RegisterWellKnownTypes();

            CreateDefaultConfiguration();

            NetworkManager.StartNeuralNetwork(gaggleSettings.ListenEndpoint, cancellationTokenSource);
        }

        private static void CreateDefaultConfiguration()
        {
            //var accountManager = new AccountManager(StorageManager<IAccountData>.GetCachedStorageManager(DefaultConnectionSettings.GetConnectionSettings(DefaultCollectionName.AccountData)));

            //if (!accountManager.TryGetAccountByEmail("victor.chicu@gaggle.com", out var account))
            //{
            //    account = accountManager.CreateAccount("Gaggle", "victor.chicu@gaggle.com", "QAZxcv321", Authority.Administrator);
            //}

            //if (account.Id.Equals(Guid.Empty))
            //{
            //    throw new Exception("Failed to create default \"Administrator\" account");
            //}
        }
    }
}