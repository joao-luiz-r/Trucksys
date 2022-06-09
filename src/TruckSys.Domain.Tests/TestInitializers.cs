using Moq;
using TruckSys.Domain.Interfaces.Repository;
using TruckSys.Domain.Services;
using TruckSys.Entities;


namespace TruckSys.Domain.Tests
{
    public class TestInitializers
    {
        public Mock<ITruckRepository> CreateTruckRepositoryMock(Truck truck = null)
        {
            var mock = new Mock<ITruckRepository>();

            mock.Setup(x => x.Add(truck))
                .Returns(truck);
            mock.Setup(x => x.Update(truck))
                .Returns(truck);

            return mock;
        }

        public TruckService CreateTruckService(ITruckRepository truckRepository = null)
        {
            var result = new TruckService(
                truckRepository ?? CreateTruckRepositoryMock().Object);

            return result;
        }
    }
}
