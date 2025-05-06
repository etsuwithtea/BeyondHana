using SQLite;

namespace BeyondHana.Models
{
    [Table("SaveGame")]
    public class SaveGame
    {
        [PrimaryKey, AutoIncrement]
        public int save_id { get; set; }
        public int current_event_id { get; set; }
        public DateTime? created_at { get; set; }
        public DateTime? updated_at { get; set; }
    }
}
