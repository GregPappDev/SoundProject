using Contract;
using FlatBuffers;
using Microsoft.AspNetCore.Authorization;
using SoundApi.Controllers;
using SoundApi.Interfaces;

namespace SoundApi.UnitTests
{
    public class SoundControllerTests
    {
        SoundController _controller;

        public SoundControllerTests(SoundController controller)
        {
            _controller = controller;
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

            bool result = _controller.isCreateSoundValid(soundRoot);

            // Assert

            Assert.True(result);

        }
    }
}