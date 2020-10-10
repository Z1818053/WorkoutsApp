using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workouts.Models;

namespace Workouts.Services
{
    public class MockDataStore : IDataStore<workout>
    {
        readonly List<workout> items;

        public MockDataStore()
        {
            items = new List<workout>()
            {
                new workout { Id = Guid.NewGuid().ToString(), name = "Day 1: Mondays", workoutDescription="Chest and Triceps" }
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
