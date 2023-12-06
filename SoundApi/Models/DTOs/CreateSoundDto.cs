using System.ComponentModel.DataAnnotations.Schema;

namespace SoundApi.Models.DTOs
{
    public class CreateSoundDto
    {
        
        public required string SoundName { get; set; }

        
        public required string SoundExtension { get; set; }

        
        public required byte[] SoundData { get; set; }

    }
}
