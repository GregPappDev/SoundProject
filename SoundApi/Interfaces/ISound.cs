using Contract;

namespace SoundApi.Interfaces
{
    public interface ISound
    {
        Task CreateSound(CreateSound createSound);
    }
}
