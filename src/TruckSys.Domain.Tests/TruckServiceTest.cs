using Moq;
using TruckSys.Entities;

namespace TruckSys.Domain.Tests
{
    [TestClass]

    public class TruckServiceTest
    {

        TestInitializers testInitializers = new TestInitializers();
        int thisYear = DateTime.Today.Year;
        int lastYear = DateTime.Today.Year - 1;
        string validModel = "FM";
        string invalidModel = "XX";

        [TestMethod]
        [TestCategory("Modelo Validation")]
        public void Should_Not_Add_Truck_With_Invalid_Modelo()
        {
            //Arrange
            var truck = new Truck(1, invalidModel, thisYear, thisYear);
            var truckRepositoryMock = testInitializers.CreateTruckRepositoryMock(truck);
            var truckservice = testInitializers.CreateTruckService(truckRepositoryMock.Object);

            //Act
            truck = truckservice.Add(truck);

            //Assert
            Assert.IsTrue(truck.errormessages.Any());
            Assert.AreEqual(truck.errormessages.FirstOrDefault(), "Modelo precisa ser FH ou FM!");
            truckRepositoryMock.Verify(x => x.Add(truck), Times.Never);
        }

        [TestMethod]
        [TestCategory("Modelo Validation")]
        public void Should_Add_Truck_With_Valid_Modelo()
        {
            //Arrange
            var truck = new Truck(1, validModel, thisYear, thisYear);
            var truckRepositoryMock = testInitializers.CreateTruckRepositoryMock(truck);
            var truckservice = testInitializers.CreateTruckService(truckRepositoryMock.Object);

            //Act
            truck = truckservice.Add(truck);

            //Assert
            Assert.IsFalse(truck.errormessages.Any());
            truckRepositoryMock.Verify(x => x.Add(truck), Times.Once);
        }
        [TestMethod]
        [TestCategory("Modelo Validation")]
        public void Should_Not_Update_Truck_With_Invalid_Modelo()
        {
            //Arrange
            var truck = new Truck(1, invalidModel, thisYear, thisYear);
            var truckRepositoryMock = testInitializers.CreateTruckRepositoryMock(truck);
            var truckservice = testInitializers.CreateTruckService(truckRepositoryMock.Object);

            //Act
            truck = truckservice.Update(truck);

            //Assert
            Assert.IsTrue(truck.errormessages.Any());
            Assert.AreEqual(truck.errormessages.FirstOrDefault(), "Modelo precisa ser FH ou FM!");
            truckRepositoryMock.Verify(x => x.Update(truck), Times.Never);
        }

        [TestMethod]
        [TestCategory("Modelo Validation")]
        public void Should_Update_Truck_With_Valid_Modelo()
        {
            //Arrange
            var truck = new Truck(1, validModel, thisYear, thisYear);
            var truckRepositoryMock = testInitializers.CreateTruckRepositoryMock(truck);
            var truckservice = testInitializers.CreateTruckService(truckRepositoryMock.Object);

            //Act
            truck = truckservice.Update(truck);

            //Assert
            Assert.IsFalse(truck.errormessages.Any());
            truckRepositoryMock.Verify(x => x.Update(truck), Times.Once);
        }

        [TestMethod]
        [TestCategory("AnoFabricacao Validation")]
        public void Should_Not_Add_Truck_With_Invalid_AnoFabricacao()
        {
            //Arrange
            var truck = new Truck(1, validModel, lastYear, thisYear);
            var truckRepositoryMock = testInitializers.CreateTruckRepositoryMock(truck);
            var truckservice = testInitializers.CreateTruckService(truckRepositoryMock.Object);

            //Act
            truck = truckservice.Add(truck);

            //Assert
            Assert.IsTrue(truck.errormessages.Any());
            Assert.AreEqual(truck.errormessages.FirstOrDefault(), $"Ano de Fabricação precisa ser {thisYear}!");
            truckRepositoryMock.Verify(x => x.Add(truck), Times.Never);
        }

        [TestMethod]
        [TestCategory("AnoFabricacao Validation")]
        public void Should_Add_Truck_With_Valid_AnoFabricacao()
        {
            //Arrange
            var truck = new Truck(1, validModel, thisYear, thisYear);
            var truckRepositoryMock = testInitializers.CreateTruckRepositoryMock(truck);
            var truckservice = testInitializers.CreateTruckService(truckRepositoryMock.Object);

            //Act
            truck = truckservice.Add(truck);

            //Assert
            Assert.IsFalse(truck.errormessages.Any());
            truckRepositoryMock.Verify(x => x.Add(truck), Times.Once);
        }
        [TestMethod]
        [TestCategory("AnoFabricacao Validation")]
        public void Should_Not_Update_Truck_With_Invalid_AnoFabricacao()
        {
            //Arrange
            var truck = new Truck(1, validModel, lastYear, thisYear);
            var truckRepositoryMock = testInitializers.CreateTruckRepositoryMock(truck);
            var truckservice = testInitializers.CreateTruckService(truckRepositoryMock.Object);

            //Act
            truck = truckservice.Update(truck);

            //Assert
            Assert.IsTrue(truck.errormessages.Any());
            Assert.AreEqual(truck.errormessages.FirstOrDefault(), $"Ano de Fabricação precisa ser {thisYear}!");
            truckRepositoryMock.Verify(x => x.Update(truck), Times.Never);
        }

        [TestMethod]
        [TestCategory("AnoFabricacao Validation")]
        public void Should_Update_Truck_With_Valid_AnoFabricacao()
        {
            //Arrange
            var truck = new Truck(1, validModel, thisYear, thisYear);
            var truckRepositoryMock = testInitializers.CreateTruckRepositoryMock(truck);
            var truckservice = testInitializers.CreateTruckService(truckRepositoryMock.Object);

            //Act
            truck = truckservice.Update(truck);

            //Assert
            Assert.IsFalse(truck.errormessages.Any());
            truckRepositoryMock.Verify(x => x.Update(truck), Times.Once);
        }
        [TestMethod]
        [TestCategory("AnoModelo Validation")]
        public void Should_Not_Add_Truck_With_Invalid_AnoModelo()
        {
            //Arrange
            var truck = new Truck(1, validModel, thisYear, lastYear);
            var truckRepositoryMock = testInitializers.CreateTruckRepositoryMock(truck);
            var truckservice = testInitializers.CreateTruckService(truckRepositoryMock.Object);

            //Act
            truck = truckservice.Add(truck);

            //Assert
            Assert.IsTrue(truck.errormessages.Any());
            Assert.AreEqual(truck.errormessages.FirstOrDefault(), $"Ano do Modelo precisa ser maior ou igual a {thisYear}!");
            truckRepositoryMock.Verify(x => x.Add(truck), Times.Never);
        }

        [TestMethod]
        [TestCategory("AnoModelo Validation")]
        public void Should_Add_Truck_With_Valid_AnoModelo()
        {
            //Arrange
            var truck = new Truck(1, validModel, thisYear, thisYear);
            var truckRepositoryMock = testInitializers.CreateTruckRepositoryMock(truck);
            var truckservice = testInitializers.CreateTruckService(truckRepositoryMock.Object);

            //Act
            truck = truckservice.Add(truck);

            //Assert
            Assert.IsFalse(truck.errormessages.Any());
            truckRepositoryMock.Verify(x => x.Add(truck), Times.Once);
        }
        [TestMethod]
        [TestCategory("AnoModelo Validation")]
        public void Should_Not_Update_Truck_With_Invalid_AnoModelo()
        {
            //Arrange
            var truck = new Truck(1, validModel, thisYear, lastYear);
            var truckRepositoryMock = testInitializers.CreateTruckRepositoryMock(truck);
            var truckservice = testInitializers.CreateTruckService(truckRepositoryMock.Object);

            //Act
            truck = truckservice.Update(truck);

            //Assert
            Assert.IsTrue(truck.errormessages.Any());
            Assert.AreEqual(truck.errormessages.FirstOrDefault(), $"Ano do Modelo precisa ser maior ou igual a {thisYear}!");
            truckRepositoryMock.Verify(x => x.Update(truck), Times.Never);
        }

        [TestMethod]
        [TestCategory("AnoModelo Validation")]
        public void Should_Update_Truck_With_Valid_AnoModelo()
        {
            //Arrange
            var truck = new Truck(1, validModel, thisYear, thisYear);
            var truckRepositoryMock = testInitializers.CreateTruckRepositoryMock(truck);
            var truckservice = testInitializers.CreateTruckService(truckRepositoryMock.Object);

            //Act
            truck = truckservice.Update(truck);

            //Assert
            Assert.IsFalse(truck.errormessages.Any());
            truckRepositoryMock.Verify(x => x.Update(truck), Times.Once);
        }

    }
}