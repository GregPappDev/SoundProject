using Contract;
using FlatBuffers;
using Microsoft.AspNetCore.Authorization;
using NSubstitute;
using SoundApi.Controllers;
using SoundApi.Data;
using SoundApi.Interfaces;

namespace SoundApi.UnitTests
{
    public class SoundControllerTests
    {
        private readonly SoundController _sut;
        //private readonly AppDbContext _context = Substitute.For<AppDbContext>();
        private readonly ISoundService _service = Substitute.For<ISoundService>();

        public SoundControllerTests()
        {

            _sut = new SoundController(_service);
        }

        [Fact]
        public void IsCreateSoundValid_ReturnsTrue_IfInputTypeIsValid()
        {
            // Arrange
            var builder = new FlatBufferBuilder(1);
            var name = builder.CreateString("TestSoundName");
            var extension = builder.CreateString("mp3");
            var sound = CreateSound.CreateCreateSound(builder, name, extension);
            CreateSound.StartCreateSound(builder);
            CreateSound.AddName(builder, name);
            CreateSound.AddExtension(builder, extension);
            var builtSound = CreateSound.EndCreateSound(builder);
            builder.Finish(builtSound.Value);
            var buf = builder.DataBuffer;
            var soundRoot = CreateSound.GetRootAsCreateSound(buf);

            // Act

            bool result = _sut.isCreateSoundValid(soundRoot);

            // Assert

            Assert.True(result);

        }

        [Fact]
        public void IsCreateSoundValid_ReturnsFalse_IfInputTypeIsInvalid()
        {
            // Arrange
            var builder = new FlatBufferBuilder(1);
            var name = builder.CreateString("");
            var extension = builder.CreateString("");
            var sound = CreateSound.CreateCreateSound(builder, name, extension);
            CreateSound.StartCreateSound(builder);
            CreateSound.AddName(builder, name);
            CreateSound.AddExtension(builder, extension);
            var builtSound = CreateSound.EndCreateSound(builder);
            builder.Finish(builtSound.Value);
            var buf = builder.DataBuffer;
            var soundRoot = CreateSound.GetRootAsCreateSound(buf);

            // Act

            bool result = _sut.isCreateSoundValid(soundRoot);

            // Assert

            Assert.False(result);

        }
    }
}