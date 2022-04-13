using Moq;
using Recruitment.API.Controllers;
using System;
using Xunit;

namespace Recruitment.Tests
{
    public class CommandQueryControllerTest
        /*: IClassFixture<WebApplicationFactory<Startup>>*/
    {
        [Fact]
        public async void Should_Get_Non_Null_Value()
        {
            CommandQueryController controller = new CommandQueryController();
            Recruitment.Contracts.HashedResult result = await controller.HandleAsync(new Contracts.Commands.CalculateHashCommand() { Login = "necati", Password = "123" });
            Assert.NotNull(result);
        }

        [Fact]
        public async void Should_Get_An_Exception_When_Request_Is_Null()
        {
            CommandQueryController controller = new CommandQueryController();
            await Assert.ThrowsAsync<ArgumentNullException>(async () => await controller.HandleAsync(null));
        }

        [Fact]
        public async void Should_Get_Expected_Result()
        {
            CommandQueryController controller = new CommandQueryController();
            Recruitment.Contracts.HashedResult resultFromController = await controller.HandleAsync(new Contracts.Commands.CalculateHashCommand() { Login = "necati", Password = "123456" });
            string expectedResult = "471290de116bc57b338e40db856ad2b4551d1bc0d15b261f811674cdad00e691";
            Assert.Equal(resultFromController.Result, expectedResult);
        }
    }
}
