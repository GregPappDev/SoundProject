using Contract;
using FlatBuffers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SoundApi.Interfaces;
using SoundApi.Services;
using System.Threading;

namespace SoundApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SoundController : ControllerBase
    {
        private readonly ISoundService _service;

        public SoundController(ISoundService service)
        {
            _service = service;
        }

        [HttpPost("[action]")]
        public async Task<ActionResult> CreateNewSound([FromBody] Stream stream )
        {            
            CreateSound? createSound = convertStreamToCreateSoundType(stream);

            if (createSound == null && !isCreateSoundValid((CreateSound)createSound)) { return BadRequest(); }
                        
            await _service.Create((CreateSound)createSound);
            return Ok("Sound created");
                    
        }

        private CreateSound? convertStreamToCreateSoundType(Stream stream)
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

        public bool isCreateSoundValid(CreateSound createSound)
        {
            if (string.IsNullOrEmpty(createSound.Name)) return false;
            if (string.IsNullOrEmpty(createSound.Extension)) return false;
           
            return true;
        }
    }
}
