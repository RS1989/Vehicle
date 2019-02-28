using Gateway.Web.Api.Controllers;
using Gateway.Web.Api.Provider;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vehicle.Test.Vehicle.Gateway.Controller
{
    public class CustomerControllerTest
    {
        private Mock<ICustomerProvider> _provider;
        private CustomerController _controller;

        [SetUp]
        public void Setyp()
        {
            _provider = new Mock<ICustomerProvider>();
            _controller = new CustomerController(_provider.Object);
        }

        [Test]
        public void GetAllCustomer()
        {
            var mockResult = new List<Models.Customer>();
            _provider.Setup(p => p.GetAll()).Returns(mockResult);
            var result = _controller.GetAll();
            Assert.IsNotNull(result);
        }
    }
}
