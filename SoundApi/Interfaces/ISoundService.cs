using Contract;

namespace SoundApi.Interfaces
{
    public interface ISoundService
    {
        Task Create(CreateSound createSound);
    }
}
