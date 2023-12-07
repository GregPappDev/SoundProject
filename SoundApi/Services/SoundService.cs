using Contract;
using FlatBuffers;
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

        #region Helper functions

        public CreateSound? ConvertStreamToCreateSoundType(Stream stream)
        {
            MemoryStream memoryStream = new MemoryStream();
            stream.CopyTo(memoryStream);
            byte[] data = memoryStream.ToArray();

            ByteBuffer byteBuffer = new ByteBuffer(data);

            CreateSound createSoundRoot;
            try
            {
                createSoundRoot = CreateSound.GetRootAsCreateSound(byteBuffer);
                if (createSoundRoot.GetType() == typeof(CreateSound)) { return createSoundRoot; }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return null;
        }

        public bool IsCreateSoundValid(CreateSound createSound)
        {
            if (string.IsNullOrEmpty(createSound.Name)) return false;
            if (string.IsNullOrEmpty(createSound.Extension)) return false;

            return true;
        }

        #endregion
    }

}
