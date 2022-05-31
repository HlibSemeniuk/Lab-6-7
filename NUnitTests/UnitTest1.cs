using BLL;
using DAL;
using NUnit.Framework;
using NSubstitute;
using AutoFixture;
using Moq;
using System.Collections.Generic;
using PL.Models;
using BLL.DTO;

namespace NUnitTests
{
    public class Tests
    {
        private readonly IFixture _fixture = new Fixture();
        private PlaceService _service;
        private IPlaceRepository _placeRepository;
        private IUnitOfWork _unitOfWork;

        [SetUp]
        protected void Setup()
        {
            _placeRepository = Substitute.For<IPlaceRepository>();
            _fixture.Inject(_placeRepository);

            _unitOfWork = Substitute.For<IUnitOfWork>();
            _fixture.Inject(_unitOfWork);

        }

        [Test]
        public void AddPlace()
        {
            PlaceDTO place = new PlaceDTO() { Name = "Test"};

            var UoW = new Mock<UnitOfWork>();

            var PlaceService = new PlaceService(UoW.Object);

            PlaceService.AddPlace(place);

            Assert.That(_service.GetPlace(3).Name.Equals("Test"));


        }
    }
}