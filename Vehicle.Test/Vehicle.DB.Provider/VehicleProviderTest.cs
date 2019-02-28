using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Vehicle.DB.Api.Provider;
using Vehicle.DB.repository;
using System.Linq;

namespace Vehicle.Test.Vehicle.DB.Provider
{
    public class VehicleProviderTest
    {
        private Mock<IVehicleQueryFactory> _factory;
        private Mock<IStatusQueryFactory> _statusFactory;
        private Mock<ICustomerQueryFactory> _cutomerFactory;
        private IVehicleProider _provider;

        [SetUp]
        public void Setup()
        {
            _factory = new Mock<IVehicleQueryFactory>();
            _statusFactory = new Mock<IStatusQueryFactory>();
            _cutomerFactory = new Mock<ICustomerQueryFactory>();
            _provider = new VehicleProider(_factory.Object, _statusFactory.Object, _cutomerFactory.Object);
        }

        [Test]
        public void GetAll()
        {
            var moqResult = new List<Models.Vehicle>();
            _factory.Setup(f => f.GetAllVehicls()).Returns(moqResult.AsQueryable());

            var result = _provider.GetAll();
            Assert.IsNotNull(result);
        }

        [Test]
        [TestCase(1)]
        [TestCase(2)]
        public void GetByStatusId(Int32 id)
        {
            var moqResult = new List<Models.Vehicle>();
            _factory.Setup(f => f.GetVehicleByStatusId(id)).Returns(moqResult.AsQueryable());
            var result = _provider.GetByStatusId(id);

            Assert.IsNotNull(result);         
        }

        [Test]
        [TestCase(1)]
        [TestCase(2)]
        public void GetByCustomerId(Int64 id)
        {
            var moqResult = new List<Models.Vehicle>();
            _factory.Setup(f => f.GetVehicleByCustomerId(id)).Returns(moqResult.AsQueryable());
            var result = _provider.GetByCustomerId(id);

            Assert.IsNotNull(result);           
        }

        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public void UpdateVehicleStatus(bool moqResult)
        {            
            var vehicle = new Models.Vehicle();
            _factory.Setup(f => f.UpdateVehicleStatus(It.IsAny<Models.Vehicle>())).Returns(moqResult);
            var result = _provider.UpdateVehicleStatus(vehicle);

            Assert.IsTrue(result == moqResult);
        }

    }
}
