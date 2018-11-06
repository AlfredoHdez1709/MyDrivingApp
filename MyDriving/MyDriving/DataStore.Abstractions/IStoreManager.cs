using System.Threading.Tasks;

namespace MyDriving.DataStore.Abstractions
{
    //TODO: Agregar interfaces
    public interface IStoreManager
    {
        bool IsInitialized { get; }
        ITripStore TripStore { get; }
        IPhotoStore PhotoStore { get; }
        //1 IUserStore UserStore { get; }
        IHubIOTStore IOTHubStore { get; }
        //2 IPOIStore POIStore { get; }
        ITripPointStore TripPointStore { get; }
        Task<bool> SyncAllAsync(bool syncUserSpecific);
        Task DropEverythingAsync();
        Task InitializeAsync();
    }
}