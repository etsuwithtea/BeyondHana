using SQLite;

namespace BeyondHana.Models
{
    [Table("Event")]
    public class Event
    {
        [PrimaryKey, AutoIncrement]
        public int event_id { get; set; }
        public int background_id { get; set; }
        public string? content { get; set; }
        public int bgm_id { get; set; }
    }
}
