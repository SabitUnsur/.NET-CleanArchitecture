using CleanArchitecture.Application.Features.CarFeatures.Commands.CreateCar;
using CleanArchitecture.Domain.Dtos;
using CleanArchitecture.Presentation.Controllers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace CleanArchitecture.UnitTest
{
    public class CarsControllerUnitTest
    {
        [Fact]
        public async void Create_ReturnsOkResult_WhenRequestIsValid()
        {
            //Arrange : Tan�mlamalar yap�l�r.
            var mediatorMock = new Mock<IMediator>();
            CreateCarCommand createCarCommand = new("Toyota","Auris",1300);
            MessageResponse response = new("Car Created Successfully!");
            CancellationToken cancellationToken = new();

            mediatorMock.Setup(m=>m.Send(createCarCommand,cancellationToken)).ReturnsAsync(response);

            CarsController  carsController = new(mediatorMock.Object);

            //Act : Metot �a�r�l�r.
            var result = await carsController.Create(createCarCommand,cancellationToken);

            //Assert : Sonu� de�erleri kontrol edilir.
               
            var OkResult = Assert.IsType<OkObjectResult>(result);

            var returnValue = Assert.IsType<MessageResponse>(OkResult.Value);

            Assert.Equal(response,returnValue);
            mediatorMock.Verify(m=>m.Send(createCarCommand,cancellationToken),Times.Once);
        }
    }
}