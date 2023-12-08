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
        public async Task<IActionResult> CreateNewSound([FromBody] Stream stream )
        {
            var body = Request.Body;

            CreateSound? createSound = _service.ConvertStreamToCreateSoundType(stream);

            if (createSound == null ) { return BadRequest(); }

            if (!_service.IsCreateSoundValid((CreateSound)createSound)) { return BadRequest(); }

            await _service.Create((CreateSound)createSound);
            return Ok("Sound created");
                    
        }
    }
}
