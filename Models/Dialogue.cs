using SQLite;

namespace BeyondHana.Models
{
    [Table("Dialogues")]
    public class Dialogue
    {
        [PrimaryKey, AutoIncrement]
        public int dialogue_id { get; set; }
        public int event_id { get; set; }
        public int character_id { get; set; }
        public string? text { get; set; }
        public int is_narration { get; set; }
        public int is_choice { get; set; }
        public int is_black_screen { get; set; }
        public int dialogue_to { get; set; }
    }
}
