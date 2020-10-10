using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Workouts.Services
{
    public interface IDataStore<T>
    {
        Task<bool> AddItemAsync(T Item);
        Task<bool> UpdateItemAsync(T Item);
        Task<bool> DeleteItemAsync(string id);
        Task<T> GetItemAsync(string id);
        Task<IEnumerable<T>> GetItemsAsync(bool forceRefresh = false);
    }
}
