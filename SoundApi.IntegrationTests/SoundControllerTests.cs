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
using System.Net;


namespace SoundApi.IntegrationTests
{
    public class SoundControllerTests : IntegrationTest
    {
        [Fact]
        public async Task CreateNewSound_CreatesSound_WithValidDataAsync()
        {
            // Arrange
            byte[] byteArray = CreateByteArrayFromCreateSoundType("Enter Sandman", "mp3");
            ByteArrayContent content = new ByteArrayContent(byteArray);
            content.Headers.Remove("Content-Type");
            content.Headers.Add("Content-Type", "application/json");

            // Act
            var response = await TestClient.PostAsync(new Uri("/api/Sound/CreateNewSound", UriKind.Relative), content);
            //var r = response.Result;

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);

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

            byte[] byteArray = builder.SizedByteArray();
            
            return byteArray;
        }

        #endregion
    }
}
