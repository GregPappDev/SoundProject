using SoundApi.Models.DTOs;

namespace SoundApi.Interfaces
{
    public interface ISound
    {
        void CreateSound(CreateSoundDto createSoundDto);
    }
}
