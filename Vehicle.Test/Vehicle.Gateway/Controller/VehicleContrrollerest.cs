using Gateway.Web.Api.Controllers;
using Gateway.Web.Api.Provider;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicle.Test.Vehicle.Gateway.Controller
{
    public class VehicleContrrollerTest
    {
        private Mock<IVehicleProvider> _provider;
        private VehicleController _controller;

        [SetUp]
        public void Setyp()
        {
            _provider = new Mock<IVehicleProvider>();
            _controller = new VehicleController(_provider.Object);
        }

        [Test]
        public void GetAllVehicles()
        {
            var mockResult = new List<Models.Vehicle>();
            _provider.Setup(p => p.GetAll()).Returns(mockResult);
            var result = _controller.GetAllVehicles();
            Assert.IsNotNull(result);
        }

        [Test]
        [TestCase(1)]
        [TestCase(2)]
        public void GetByStatusId(Int32 id)
        {
            var mockResult = new List<Models.Vehicle>();
            _provider.Setup(p => p.GetByStatusId(id)).Returns(mockResult);
            var result = _controller.GetByStatusId(id);
            Assert.IsNotNull(result);
        }


        [Test]
        [TestCase(1)]
        [TestCase(2)]
        public void GetByCustomerId(Int64 id)
        {
            var mockResult = new List<Models.Vehicle>();
            _provider.Setup(p => p.GetByCustomerId(id)).Returns(mockResult);
            var result = _controller.GetByCustomerId(id);
            Assert.IsNotNull(result);
        }
    }
}
