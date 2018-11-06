using MyDriving.DataStore.Abstractions;
using MyDriving.Utils;
using System.Threading.Tasks;

namespace MyDriving.DataStore.Mock
{
    //TODO: Agregar store de user y photo
    public class StoreManager : IStoreManager
    {
        #region IStoreManager implementation

        public async Task InitializeAsync()
        {
            await TripStore.InitializeStoreAsync();
        }

        public Task<bool> SyncAllAsync(bool syncUserSpecific)
        {
            return Task.FromResult(true);
        }

        public Task DropEverythingAsync()
        {
            return Task.FromResult(true);
        }

        public bool IsInitialized => true;

        ITripStore tripStore;
        public ITripStore TripStore => tripStore ?? (tripStore = ServiceLocator.Instance.Resolve<ITripStore>());

        IPhotoStore photoStore;
        public IPhotoStore PhotoStore => photoStore ?? (photoStore = ServiceLocator.Instance.Resolve<IPhotoStore>());

        /*1 IUserStore userStore;
        public IUserStore UserStore => userStore ?? (userStore = ServiceLocator.Instance.Resolve<IUserStore>());
        */
        ITripPointStore tripPointStore;
        public ITripPointStore TripPointStore => tripPointStore ?? (tripPointStore = ServiceLocator.Instance.Resolve<ITripPointStore>());

        IHubIOTStore iotHubStore;

        public IHubIOTStore IOTHubStore
            => iotHubStore ?? (iotHubStore = ServiceLocator.Instance.Resolve<IHubIOTStore>());

        /*2
        IPOIStore poiStore;
        public IPOIStore POIStore => poiStore ?? (poiStore = ServiceLocator.Instance.Resolve<IPOIStore>());
        */
        #endregion
    }
}