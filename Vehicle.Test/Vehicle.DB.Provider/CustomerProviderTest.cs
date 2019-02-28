using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vehicle.DB.Api.Provider;
using Vehicle.DB.repository;

namespace Vehicle.Test.Vehicle.DB.Provider
{
    public class CustomerProviderTest
    {
        private Mock<ICustomerQueryFactory> _factory;
        private ICustomerProvider _provider;
        [SetUp]
        public void Setup()
        {
            _factory = new Mock<ICustomerQueryFactory>();
            _provider = new CustomerProvider(_factory.Object);
        }

        [Test]
        public void GetAll()
        {
            var moqCustomers = new List<Models.Customer>();
            _factory.Setup(f => f.GetCustomers()).Returns(moqCustomers.AsQueryable());
            var result = _provider.GetAll();

            Assert.IsNotNull(result);
        }

        [Test]
        [TestCase(1)]
        [TestCase(2)]
        public void GetByID(Int64 id)
        {
            var moqCustomer = new Models.Customer();
            moqCustomer.Id = id;
            moqCustomer.Address = "test";
            moqCustomer.FirstName = "test";
            _factory.Setup(f => f.GetCustomersById(id)).Returns(moqCustomer);
            var result = _provider.GetByID(id);

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Id == id);
        }
    }
}
