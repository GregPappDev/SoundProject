using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contract;
using FlatBuffers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using SoundApi.Controllers;
using FluentAssertions;
using Microsoft.AspNetCore.Http.Headers;
using System.Net.Http.Headers;
using System.Net.Http;
using static System.Net.Mime.MediaTypeNames;
using System.IO;
using System.Net.Sockets;
using Microsoft.AspNetCore.Http;


namespace SoundApi.IntegrationTests
{
    public class SoundControllerTests : IntegrationTest
    {
        [Fact]
        public void CreateNewSound_CreatesSound_WithValidData()
        {
            // Arrange
            byte[] byteArray = CreateByteArrayFromCreateSoundType("Enter Sandman", "mp3");
            ByteArrayContent content = new ByteArrayContent(byteArray);
            content.Headers.Remove("Content-Type");
            content.Headers.Add("Content-Type", "application/json");

            // Act
            var response = TestClient.PostAsync(new Uri("/api/Sound/Create", UriKind.Relative), content).Result;

            // Assert
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);

        }

        #region Helper functions

        private byte[] CreateByteArrayFromCreateSoundType(string soundName, string soundExtention)
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

            byte[] byteArray = builder.SizedByteArray();
            
            return byteArray;
        }

        #endregion
    }
}
