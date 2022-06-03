using Autofac.Extras.Moq;
using AutoFixture;
using AutoMapper;
using BLL;
using BLL.DTO;
using DAL;
using DAL.Entitys;
using Moq;
using NSubstitute;
using NUnit.Framework;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace NUnitTests
{
    [TestFixture]
    public class Tests
    {

        [Test]
        public void PlaceService_Given_Place_Id_Should_Get_Place_Object()
        {
            // Arrange
            var placeId = 1;
            var expexted = "AAA";
            var place = new Place() { Id = placeId, Name = expexted };

            var placeRepositoryMock = new Mock<IPlaceRepository>();
            placeRepositoryMock.Setup(m => m.Get(placeId)).Returns(place).Verifiable();

            var uow = new Mock<IUnitOfWork>();
            uow.Setup(m => m.Places).Returns(placeRepositoryMock.Object);

            IPlaceService service = new PlaceService(uow.Object); 

            // Act
            var result = service.GetPlace(placeId);

            // Assert
            Assert.AreEqual(expexted, result.Name);
        }

        [Test]
        public void GetPlaces_Should_Return_ListOfPlaces_WithCount_Equals_3()
        {
            //Arrange
            List<Place> places = new List<Place>()
            {
                new Place() { Id = 1, Name = "Test1"},
                new Place() { Id = 2, Name = "Test2"},
                new Place(){ Id = 3, Name = "TEst3"}
            };

            var placeRepositoryMock = new Mock<IPlaceRepository>();
            placeRepositoryMock.Setup(m => m.GetAll()).Returns(places).Verifiable();

            var uow = new Mock<IUnitOfWork>();
            uow.Setup(m => m.Places).Returns(placeRepositoryMock.Object);

            IPlaceService service = new PlaceService(uow.Object);

            // Act
            var result = service.GetPlaces().ToList();
            
            // Assert
            Assert.That(result.Count == 3);
        }

        [Test]
        public void GetQuestions_Should_Return_ListOfQuestions_WithCount_Equals_3()
        {
            //Arrange
            List<Question> questions = new List<Question>()
            {
                new Question() { Id = 1, Description = "Test1"},
                new Question() { Id = 2, Description = "Test2"},
                new Question(){ Id = 3, Description = "Test3"}
            };

            var questionRepositoryMock = new Mock<IQuestionRepository>();
            questionRepositoryMock.Setup(m => m.GetAll()).Returns(questions).Verifiable();

            var uow = new Mock<IUnitOfWork>();
            uow.Setup(m => m.Questions).Returns(questionRepositoryMock.Object);

            IQuestionService service = new QuestionService(uow.Object);

            // Act
            var result = service.GetAll().ToList();

            // Assert
            Assert.That(result.Count == 3);
        }

        [Test]
        public void FileService_Given_File_Id_Should_Get_File_Object()
        {
            // Arrange
            var fileId = 1;
            var expexted = "data/DCIM/Test";
            var file = new File() { Id = fileId, Way = expexted };

            var fileRepositoreMock = new Mock<IFileRepository>();
            fileRepositoreMock.Setup(m => m.Get(fileId)).Returns(file).Verifiable();

            var uow = new Mock<IUnitOfWork>();
            uow.Setup(m => m.Files).Returns(fileRepositoreMock.Object);

            IFileService service = new FileService(uow.Object);

            // Act
            var result = service.GetById(fileId);

            // Assert
            Assert.AreEqual(expexted, result.Way);
        }

        [Test]
        public void GetFiles_Should_Return_ListOfFiles_WithCount_Equals_3()
        {
            //Arrange
            List<File> files = new List<File>()
            {
                new File() { Id = 1, Way = "Test1"},
                new File() { Id = 2, Way = "Test2"},
                new File(){ Id = 3, Way = "Test3"}
            };

            var fileRepositoryMock = new Mock<IFileRepository>();
            fileRepositoryMock.Setup(m => m.GetAll()).Returns(files).Verifiable();

            var uow = new Mock<IUnitOfWork>();
            uow.Setup(m => m.Files).Returns(fileRepositoryMock.Object);

            IFileService service = new FileService(uow.Object);

            // Act
            var result = service.GetAll().ToList();

            // Assert
            Assert.That(result.Count == 3);
        }

    }
}