using Moq;
using System;
using System.Collections.Generic;
using System.Web.Http.Results;
using Testing_Assignment_1.Controllers;
using Testing_Assignment_1.Repository;
using Xunit;


namespace Passenger.Test
{
    public class PassengerControllerTest
    {
        private readonly Mock<IDataRepository> mockDtaRepository = new Mock<IDataRepository>();
        private readonly PassengerController _passengerController;

        public PassengerControllerTest()
        {
            _passengerController = new PassengerController(mockDtaRepository.Object);
        }

        [Fact]
        public void Test_GetUser()
        {
            // Arrange
            var resultObj = mockDtaRepository.Setup(x => x.getPassengersList()).Returns(GetUser());

            // Act
            var response = _passengerController.Get();

            // Asert
            Assert.Equal(3, response.Count);

        }

        [Fact]
        public void Test_DeleteUser()
        {
            var passenger = new Testing_Assignment_1.Models.Passenger();
            passenger.Id = Guid.NewGuid(); 

            // Arrange
            var resultObj = mockDtaRepository.Setup(x => x.Delete(passenger.Id)).Returns(true);

            // Act
            var response = _passengerController.Delete(passenger.Id);

            // Assert
            Assert.True(response);

        }

        [Fact]
        public void Test_GetUserById()
        {
            // Arrange
            var newPassenger = new Testing_Assignment_1.Models.Passenger();
            newPassenger.Id = Guid.NewGuid();
            newPassenger.FirstName = "Parth";
            newPassenger.LastName = "Nonghanvadra";
            newPassenger.PhoneNumber = "78894561230";

            // Act
            var responseObj = mockDtaRepository.Setup(x => x.GetById(newPassenger.Id)).Returns(newPassenger);
            var result = _passengerController.Get(newPassenger.Id);
            var isNull = Assert.IsType<OkNegotiatedContentResult<Testing_Assignment_1.Models.Passenger>>(result);

            // Assert
            Assert.NotNull(isNull);
        }

        [Fact]
        public void Test_AddUser()
        {
            // Arrange
            var newPassenger = new Testing_Assignment_1.Models.Passenger();
            newPassenger.Id = Guid.NewGuid();
            newPassenger.FirstName = "Parth";
            newPassenger.LastName = "Nonghanvadra";
            newPassenger.PhoneNumber = "78894561230";
            
            // Act
            var response = mockDtaRepository.Setup(x => x.AddUser(newPassenger)).Returns(AddUser());
            var result = _passengerController.Post(newPassenger);

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void Test_UpdateUser()
        {
            // Arrange
            var model = new Testing_Assignment_1.Models.Passenger { Id = new Guid(), FirstName = "Parth", LastName = "Nonghanvadra", PhoneNumber = "9874563210"};

            // Act
            var resultObj = mockDtaRepository.Setup(x => x.Update(model)).Returns(model);
            var response = _passengerController.Put(model);

            // Assert
            Assert.Equal(model, response);
        }


        private static IList<Testing_Assignment_1.Models.Passenger> GetUser()
        {
            IList< Testing_Assignment_1.Models.Passenger> users = new List<Testing_Assignment_1.Models.Passenger>()
            {
                new Testing_Assignment_1.Models.Passenger() {Id=Guid.NewGuid(),FirstName="Mukesh",LastName="Patel", PhoneNumber = "4567891230"},
                new Testing_Assignment_1.Models.Passenger() {Id=Guid.NewGuid(),FirstName="Parth",LastName="Patel", PhoneNumber = "7418529630"},
                new Testing_Assignment_1.Models.Passenger() {Id=Guid.NewGuid(),FirstName="Abhishek",LastName="Bakhai", PhoneNumber = "8520147963"},

            };
            return users;
        }

        private static Testing_Assignment_1.Models.Passenger AddUser()
        {
            var newPassenger = new Testing_Assignment_1.Models.Passenger();
            newPassenger.Id = Guid.NewGuid();
            newPassenger.FirstName = "Parth";
            newPassenger.LastName = "Nonghanvadra";
            newPassenger.PhoneNumber = "78894561230";
            return newPassenger;
        }

    }
}
