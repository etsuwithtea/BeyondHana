using SQLite;

namespace BeyondHana.Models
{
    [Table("BGM")]
    public class BGM
    {
        [PrimaryKey, AutoIncrement]
        public int bgm_id { get; set; }
        public string? file_path { get; set; }
        public string? description { get; set; }
    }
}
