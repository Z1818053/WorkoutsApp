using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workouts.Models;

namespace Workouts.Services
{
    public class ExerciseStore : IDataStore<exercises>
    {
        readonly List<exercises> items;

        public ExerciseStore()
        {
            items = new List<exercises>()
            {
               // new exercises { Id = Guid.NewGuid().ToString(), name = "Day 1: Mondays", description="Chest and Triceps" },
            };
        }

        public async Task<bool> AddItemAsync(exercises item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(exercises item)
        {
            var oldItem = items.Where((exercises arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = items.Where((exercises arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<exercises> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<exercises>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}