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
            byte[] arr = new byte[1];
            arr[0] = 0;

            SoundModel newSound = new() 
            
            {
                SoundName = createSound.Name,
                SoundExtension = createSound.Extension,
                SoundData = arr,
                SoundCreated = DateTime.Now,
            };

            await _context.AddAsync(newSound);
            await _context.SaveChangesAsync();

        }


    }
}
