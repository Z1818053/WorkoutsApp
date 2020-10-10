using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

using Xamarin.Forms;

using Workouts.Models;
using Workouts.Services;

namespace Workouts.ViewModels
{
    public class BaseViewModel : ObservableObject
    {
        public IDataStore<workout> DataStore => DependencyService.Get<IDataStore<workout>>();
        public IDataStore<exercises> exerciseStore => DependencyService.Get<IDataStore<exercises>>();
        bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set { SetProperty(ref isBusy, value); }
        }

        string title = string.Empty;
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }
    }
}
