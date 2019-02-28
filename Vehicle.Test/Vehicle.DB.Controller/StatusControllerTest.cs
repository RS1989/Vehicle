using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Vehicle.DB.Api.Controllers;
using Vehicle.DB.Api.Provider;

namespace Vehicle.Test.Vehicle.DB.Controller
{
    public class StatusControllerTest
    {
        private Mock<IStatusProvider> _provider;
        private StatusDbController _controller;

        [SetUp]
        public void Setyp()
        {            
            _provider = new Mock<IStatusProvider>();
            _controller = new StatusDbController(_provider.Object);
        }

        [Test]
        public void GetAllCustomer()
        {
            var mockResult = new List<Models.Status>();
            _provider.Setup(p => p.GetAll()).Returns(mockResult);
            var result = _controller.GetAllStatuses();
            Assert.IsNotNull(result);
        }
    }
}
