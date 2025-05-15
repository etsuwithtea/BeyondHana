using System.Collections.ObjectModel;
using BeyondHana.Data;
using BeyondHana.Models;
using CommunityToolkit.Mvvm.ComponentModel;

namespace BeyondHana.ViewModels
{
    public partial class StoryVM : ObservableObject
    {
        private readonly DialogueDBHelper _DialogueDBHelper = DialogueDBHelper.Instance;
        public ObservableCollection<Dialogue> dialogues { get; set; }


        private readonly BackgroundDBHelper _BackgroundDBHelper = BackgroundDBHelper.Instance;
        public ObservableCollection<Background> backgrounds { get; set; }


        private readonly BGMDBHelper _BGMDBHelper = BGMDBHelper.Instance;
        public ObservableCollection<BGM> bgms { get; set; }


        private readonly CharacterDBhelper _CharacterDBHelper = CharacterDBhelper.Instance;
        public ObservableCollection<Character> characters { get; set; }


        private readonly ChoiceDBHelper _ChoiceDBHelper = ChoiceDBHelper.Instance;
        public ObservableCollection<Choice> choices { get; set; }


        private readonly EventDBHelper _EventDBHelper = EventDBHelper.Instance;
        public ObservableCollection<Event> events { get; set; }

        public StoryVM()
        {
            dialogues = new ObservableCollection<Dialogue>();
            backgrounds = new ObservableCollection<Background>();
            bgms = new ObservableCollection<BGM>();
            characters = new ObservableCollection<Character>();
            choices = new ObservableCollection<Choice>();
            events = new ObservableCollection<Event>();
            LoadStorys();
        }

        private async void LoadStorys()
        {
            var list1 = await _DialogueDBHelper.GetDatasAsync();
            dialogues.Clear();

            foreach (var item in list1)
            {
                dialogues.Add(item);
            }


            var list2 = await _BackgroundDBHelper.GetDatasAsync();
            backgrounds.Clear();

            foreach (var item in list2)
            {
                backgrounds.Add(item);
            }


            var list3 = await _BGMDBHelper.GetDatasAsync();
            bgms.Clear();

            foreach (var item in list3)
            {
                bgms.Add(item);
            }


            var list4 = await _CharacterDBHelper.GetDatasAsync();
            characters.Clear();

            foreach (var item in list4)
            {
                characters.Add(item);
            }


            var list5 = await _ChoiceDBHelper.GetDatasAsync();
            choices.Clear();

            foreach (var item in list5)
            {
                choices.Add(item);
            }


            var list6 = await _EventDBHelper.GetDatasAsync();
            events.Clear();

            foreach (var item in list6)
            {
                events.Add(item);
            }
        }
    }
}
