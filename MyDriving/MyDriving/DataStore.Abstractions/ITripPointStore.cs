using System.Collections.Generic;
using System.Threading.Tasks;
using MyDriving.DataObjects;

namespace MyDriving.DataStore.Abstractions
{
    public interface ITripPointStore : IBaseStore<TripPoint>
    {
        Task<IEnumerable<TripPoint>> GetPointsForTripAsync(string id);
    }
}