using System.Collections.ObjectModel;
using BeyondHana.Data;
using BeyondHana.Models;
using CommunityToolkit.Mvvm.ComponentModel;

namespace BeyondHana.ViewModels
{
    public  partial class SaveGameVM : ObservableObject
    {
        private readonly SaveGameDBHelper _databaseHelper = SaveGameDBHelper.Instance;
        public ObservableCollection<SaveGame> saveGames { get; set; }

        public SaveGameVM()
        {
            saveGames = new ObservableCollection<SaveGame>();
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