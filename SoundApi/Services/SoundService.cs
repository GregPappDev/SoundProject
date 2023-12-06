using SoundApi.Data;
using SoundApi.Interfaces;
using SoundApi.Models;
using SoundApi.Models.DTOs;

namespace SoundApi.Services
{
    public class SoundService : ISound
    {
        private readonly AppDbContext _context;

        public SoundService(AppDbContext context)
        {
            _context = context;
        }

        public void CreateSound(CreateSoundDto createSoundDto)
        {
                      
            Sound newSound = new()
            {
                SoundName = createSoundDto.SoundName,
                SoundExtension = createSoundDto.SoundExtension,
                SoundData = createSoundDto.SoundData,
                SoundCreated = DateTime.Now,
            };
        }
    }
}
