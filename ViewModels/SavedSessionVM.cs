using System.Collections.ObjectModel;
using BeyondHana.Data;
using BeyondHana.Models;
using CommunityToolkit.Mvvm.ComponentModel;

namespace BeyondHana.ViewModels
{
    public  partial class SavedSessionVM : ObservableObject
    {
        private readonly SavedSessionDBHelper _databaseHelper = SavedSessionDBHelper.Instance;
        public ObservableCollection<SavedSession> saveGames { get; set; }

        public SavedSessionVM()
        {
            saveGames = new ObservableCollection<SavedSession>();
            LoadSaves();      
        }

        private async void LoadSaves()
        {
            var list = await _databaseHelper.GetDatasAsync();
            saveGames.Clear();
           
            foreach (var item in list)
            {
                saveGames.Add(item);
            }
        }
    }
}