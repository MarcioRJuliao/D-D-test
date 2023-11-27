using dandd.Models;
using dandd.Views;
using dandd.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;

namespace dandd.ViewModels
{
    
            internal partial class RaceViewModel : ObservableObject, IDisposable
            {
                private RaceService _raceService;
                [ObservableProperty]
                public int _index;
                [ObservableProperty]
                public int _nome;
                [ObservableProperty]
                public string _url;
                [ObservableProperty]
                public ObservableCollection<Race> _races;

                public RaceViewModel()
                {

                Races = new ObservableCollection<Race>();
                    _raceService = new RaceService();

                }

                public ICommand GetPostsCommand => new Command(async () => await LoadRacesAsync());

                private async Task LoadRacesAsync()
                {
                    Races = await _raceService.GetRacesAsync();
                }

                public void Dispose()
                {
                    throw new NotImplementedException();
                }
            }

}
