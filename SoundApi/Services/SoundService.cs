using Contract;
using SoundApi.Data;
using SoundApi.Interfaces;
using SoundApi.Models;


namespace SoundApi.Services
{
    public class SoundService : ISoundService
    {
        private readonly AppDbContext _context;

        public SoundService(AppDbContext context)
        {
            _context = context;
        }

        public async Task Create(CreateSound createSound)
        {
            SoundModel newSound = new() 
            {
                SoundName = createSound.Name,
                SoundExtension = createSound.Extension,
                SoundData = new byte[1],
                SoundCreated = DateTime.Now,
            };

            await _context.AddAsync(newSound);
            await _context.SaveChangesAsync();

        }


    }
}
