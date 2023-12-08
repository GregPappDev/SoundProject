using Contract;
using FlatBuffers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SoundApi.Interfaces;
using SoundApi.Services;
using System.IO;
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
        public async Task<IActionResult> CreateNewSound()
        {
            var body = Request.Body;
            if(body == null) { BadRequest("Invalid request body"); }

            MemoryStream memoryStream = new MemoryStream();
            await body.CopyToAsync(memoryStream);

            CreateSound? createSound = _service.ConvertStreamToCreateSoundType(memoryStream);

            if(createSound == null) { BadRequest("Invalid request body"); }

            if(!_service.IsCreateSoundValid((CreateSound)createSound)) { BadRequest("Invalid request body"); }

            await _service.Create((CreateSound)createSound);
                        
            return Ok("Sound sucessfully saved");
                    
        }
    }
}
