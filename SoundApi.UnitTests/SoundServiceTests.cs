using Contract;
using FlatBuffers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using NSubstitute;
using SoundApi.Controllers;
using SoundApi.Data;
using SoundApi.Interfaces;
using SoundApi.Services;

namespace SoundApi.UnitTests
{
    public class SoundServiceTests
    {
        private readonly SoundService _sut;
        private readonly AppDbContext _context = Substitute.For<AppDbContext>();

        public SoundServiceTests()
        {
            _sut = new SoundService(_context);
        }

        [Fact]
        public void IsCreateSoundValid_ReturnsTrue_IfInputTypeIsValid()
        {
            // Arrange
            var validCreateSound = CreateSoundType("Enter Sandman", "mp3");

            // Act
            bool result = _sut.IsCreateSoundValid(validCreateSound);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void IsCreateSoundValid_ReturnsFalse_IfInputTypeIsInvalid()
        {
            // Arrange
            var validCreateSound = CreateSoundType("", "");

            // Act
            bool result = _sut.IsCreateSoundValid(validCreateSound);

            // Assert
            Assert.False(result);
        }


        #region Helper functions

        private CreateSound CreateSoundType(string soundName, string soundExtention) 
        {
            var builder = new FlatBufferBuilder(1);
            var name = builder.CreateString(soundName);
            var extension = builder.CreateString(soundExtention);
            var sound = CreateSound.CreateCreateSound(builder, name, extension);
            CreateSound.StartCreateSound(builder);
            CreateSound.AddName(builder, name);
            CreateSound.AddExtension(builder, extension);
            var builtSound = CreateSound.EndCreateSound(builder);
            builder.Finish(builtSound.Value);
            var buf = builder.DataBuffer;
            var soundRoot = CreateSound.GetRootAsCreateSound(buf);
            return soundRoot;
        }

        #endregion
    }
}
