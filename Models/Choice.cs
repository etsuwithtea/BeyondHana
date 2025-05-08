using SQLite;

namespace BeyondHana.Models
{
    [Table("Choice")]
    public class Choice
    {
        [PrimaryKey, AutoIncrement]
        public int choice_id { get; set; }
        public int event_id { get; set; }
        public string? choice_text{ get; set; }
        public int next_dialogue_id { get; set; }
        public int dialogue_id { get; set; }
    }
}
