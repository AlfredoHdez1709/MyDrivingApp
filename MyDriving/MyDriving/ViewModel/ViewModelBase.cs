using MvvmHelpers;
using MyDriving.Utils;
//1 using MyDriving.DataStore.Abstractions;
//2 using MyDriving.AzureClient;

namespace MyDriving.ViewModel
{
    //TODO: Descomentar líneas después del IoTHub y otras interfaces 3

    public class ViewModelBase : BaseViewModel
    {
        public static void Init(bool useMock = false) { }

        /*
        static IStoreManager _storeManager;


        public Settings Settings => Settings.Current;

        public static IStoreManager StoreManager
            => _storeManager ?? (_storeManager = ServiceLocator.Instance.Resolve<IStoreManager>());

        public static void Init(bool useMock = false)
        {
            ServiceLocator.Instance.Add<IAzureClient, AzureClient.AzureClient>();
            if (useMock)
            {
                ServiceLocator.Instance.Add<ITripStore, DataStore.Mock.Stores.TripStore>();
                ServiceLocator.Instance.Add<ITripPointStore, DataStore.Mock.Stores.TripPointStore>();
                ServiceLocator.Instance.Add<IPhotoStore, DataStore.Mock.Stores.PhotoStore>();
                ServiceLocator.Instance.Add<IUserStore, DataStore.Mock.Stores.UserStore>();
                ServiceLocator.Instance.Add<IHubIOTStore, DataStore.Mock.Stores.IOTHubStore>();
                ServiceLocator.Instance.Add<IPOIStore, DataStore.Mock.Stores.POIStore>();
                ServiceLocator.Instance.Add<IStoreManager, DataStore.Mock.StoreManager>();
            }
            else
            {
                ServiceLocator.Instance.Add<ITripStore, DataStore.Azure.Stores.TripStore>();
                ServiceLocator.Instance.Add<ITripPointStore, DataStore.Azure.Stores.TripPointStore>();
                ServiceLocator.Instance.Add<IPhotoStore, DataStore.Azure.Stores.PhotoStore>();
                ServiceLocator.Instance.Add<IUserStore, DataStore.Azure.Stores.UserStore>();
                ServiceLocator.Instance.Add<IHubIOTStore, DataStore.Azure.Stores.IOTHubStore>();
                ServiceLocator.Instance.Add<IPOIStore, DataStore.Azure.Stores.POIStore>();
                ServiceLocator.Instance.Add<IStoreManager, DataStore.Azure.StoreManager>();
            }
        }
        */
    }
}