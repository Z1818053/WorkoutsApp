using System;
using System.Collections.Generic;
using System.Text;
using Workouts.Models;
using System.Threading.Tasks;
using System.Linq;

namespace Workouts.Services
{
    public class WorkoutStore : IDataStore<workout>
    {
        readonly List<workout> items;

        public WorkoutStore() {
            items = new List<workout>()
            {
                new workout { Id = Guid.NewGuid().ToString(), name = "First item", description="This is an item description." },
                new workout { Id = Guid.NewGuid().ToString(), name = "Second item", description="This is an item description." },
                new workout { Id = Guid.NewGuid().ToString(), name = "Third item", description="This is an item description." },
                new workout { Id = Guid.NewGuid().ToString(), name = "Fourth item", description="This is an item description." },
                new workout { Id = Guid.NewGuid().ToString(), name = "Fifth item", description="This is an item description." },
                new workout { Id = Guid.NewGuid().ToString(), name = "Sixth item", description="This is an item description." }
            };

        }
        public async Task<bool> AddItemAsync(workout item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(workout item)
        {
            var oldItem = items.Where((workout arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = items.Where((workout arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<workout> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<workout>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}
