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
    public class CustomerControllerTest
    {
        private Mock<ICustomerProvider> _provider;
        private CustomerDbController _controller;

        [SetUp]
        public void Setyp()
        {
            _provider = new Mock<ICustomerProvider>();
            _controller = new CustomerDbController(_provider.Object);
        }

        [Test]
        public void GetAllCustomer()
        {
            var mockResult = new List<Models.Customer>();
            _provider.Setup(p => p.GetAll()).Returns(mockResult.AsQueryable());
            var result = _controller.GetAllCustomer();
            Assert.IsNotNull(result);          
        }
    }
}
