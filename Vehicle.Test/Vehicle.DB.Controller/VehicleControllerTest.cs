using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vehicle.DB.Api.Controllers;
using Vehicle.DB.Api.Provider;

namespace Vehicle.Test.Vehicle.DB.Controller
{
    public class VehicleControllerTest
    {
        private Mock<IVehicleProider> _provider;
        private VehicleDBController _controller;

        [SetUp]
        public void Setyp()
        {
            _provider = new Mock<IVehicleProider>();
            _controller = new VehicleDBController(_provider.Object);
        }

        [Test]
        public void GetAllVehicles()
        {
            var result = _controller.GetAllVehicles();
            Assert.IsNotNull(result);
        }


        [Test]
        [TestCase(1)]
        [TestCase(2)]
        public void GetAllVehiclesByStatusId(Int32 id)
        {
            var mockResut = new List<Models.Vehicle>();
            _provider.Setup(p => p.GetByStatusId(id)).Returns(mockResut);
            var result = _controller.GetAllVehiclesByStatusId(id);
            Assert.IsNotNull(result);        
        }

        [Test]
        [TestCase(1)]
        [TestCase(2)]
        public void GetAllVehiclesByCustomerId(Int64 id)
        {
            var mockResut = new List<Models.Vehicle>();
            _provider.Setup(p => p.GetByCustomerId(id)).Returns(mockResut);
            var result = _controller.GetAllVehiclesByCustomerId(id);
            Assert.IsNotNull(result);
        }

        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public void UpdateVehicleStatus(bool mockResut)
        {
            var mockVehicle = new Models.Vehicle();
            _provider.Setup(p => p.UpdateVehicleStatus(It.IsAny<Models.Vehicle>())).Returns(mockResut);
            var result = _controller.UpdateVehicleStatus(mockVehicle);
            Assert.IsNotNull(result);
        }
    }
}
