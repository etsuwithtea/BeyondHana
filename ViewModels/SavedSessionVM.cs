using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using System.ComponentModel;
using BeyondHana.Data;
using BeyondHana.Models;


namespace BeyondHana.ViewModels
{
    public  class SavedSessionVM 
    {
        private readonly SaveGameDBHelper _databaseHelper = SaveGameDBHelper.Instance;
        public ObservableCollection<SavedSession> saveGames { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public SavedSessionVM()
        {
            saveGames = new ObservableCollection<SavedSession>();
            LoadSaves();      
        }

        private async void LoadSaves()
        {
            var list = await _databaseHelper.GetNotesAsync();
            saveGames.Clear();
           
            foreach (var item in list)
            {
                saveGames.Add(item);
                //Console.WriteLine($"ID : {item.ID}");
                //Console.WriteLine($"Chapter : {item.Chapter}");
                //Console.WriteLine($"isSave : {item.isSave}");
            }
        }
    }
}
