using Contract;

namespace SoundApi.Interfaces
{
    public interface ISoundService
    {
        Task Create(CreateSound createSound);
        public CreateSound? ConvertStreamToCreateSoundType(MemoryStream stream);
        public bool IsCreateSoundValid(CreateSound createSound);

    }
}
