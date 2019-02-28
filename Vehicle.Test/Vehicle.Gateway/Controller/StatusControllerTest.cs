using Gateway.Web.Api.Controllers;
using Gateway.Web.Api.Provider;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicle.Test.Vehicle.Gateway.Controller
{
    public class StatusControllerTest
    {
        private Mock<IStatusProvider> _provider;
        private StatusController _controller;

        [SetUp]
        public void Setyp()
        {
            _provider = new Mock<IStatusProvider>();
            _controller = new StatusController(_provider.Object);
        }

        [Test]
        public void GetAllCustomer()
        {
            var mockResult = new List<Models.Status>();
            _provider.Setup(p => p.GetAll()).Returns(mockResult);
            var result = _controller.GetAll();
            Assert.IsNotNull(result);
        }
    }
}
