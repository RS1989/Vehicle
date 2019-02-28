
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
    public class StatusProviderTest
    {
        private Mock<IStatusQueryFactory> _factory;
        private IStatusProvider _provider;

        [SetUp]
        public void Setup()
        {
            _factory = new Mock<IStatusQueryFactory>();
            _provider = new StatusProvider(_factory.Object);
        }

        [Test]
        public void GetAll()
        {
            var moqResults = new List<Models.Status>();
            _factory.Setup(f => f.GetStatuses()).Returns(moqResults.AsQueryable());
            var result = _provider.GetAll();
            
            Assert.IsNotNull(result);
        }

        [Test]
        [TestCase(1)]
        [TestCase(2)]
        public void GetById(Int32 id)
        {
            var moqResult = new Models.Status();
            moqResult.Id = id;
            _factory.Setup(f=> f.GetStatusByID(id)).Returns(moqResult);
            var result = _provider.GetById(id);

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Id == id);
        }

        [Test]
        [TestCase("1")]
        [TestCase("2")]
        public void GetByName(string name)
        {
            var moqResult = new Models.Status();
            moqResult.Name = name;
            _factory.Setup(f => f.GetStatusByName(name)).Returns(moqResult);
            var result = _provider.GetByName(name);

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Name == name);
        }
    }
}
