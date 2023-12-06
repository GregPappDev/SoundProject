using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoundApi.Models
{
    public class SoundModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("sound_id")]
        public int SoundId { get; set; }
        
        [Column("sound_name", TypeName = "varchar(100)")]
        public required string SoundName { get; set; }

        [Column("sound_extension", TypeName = "varchar(5)")]
        public required string SoundExtension { get; set; }

        [Column("sound_data")]
        public required byte[] SoundData { get; set; }

        [Column("sound_created_datetime", TypeName = "timestamp without time zone")]
        public required DateTime SoundCreated { get; set; }

        [Column("sound_updated_datetime", TypeName = "timestamp without time zone")]
        public DateTime? SoundUpdated { get; set; }
    }
}
