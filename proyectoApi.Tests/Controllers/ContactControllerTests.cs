using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using proyectoApi.Controllers;
using proyectoApi.Data;
using proyectoApi.Interfaces;
using proyectoApi.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Results;

namespace proyectoApi.Tests.Controllers
{
    [TestClass]
    public class ContactControllerTests
    {

        [TestMethod]
        public void GetById_ReturnsContact_WhenValidIdProvided()
        {
            // Arrange
            var mockRepository = new Mock<IRepository<Contact>>();
            var controller = new ContactController(mockRepository.Object);
            int validId = 1;

            // Mock Repository Behavior
            var expectedContact = new Contact { Id = validId }; // Crear un contacto esperado
            mockRepository.Setup(repo => repo.GetById(validId)).Returns(expectedContact);

            // Act
            var result = controller.GetById(validId);

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkNegotiatedContentResult<Contact>));
            var contentResult = (OkNegotiatedContentResult<Contact>)result;
            Assert.AreEqual(validId, contentResult.Content.Id);
            Assert.AreEqual(expectedContact, contentResult.Content); // Asegurarse de que el contenido es el esperado
        }

        [TestMethod]
        public void GetById_ReturnsNotFound_WhenInvalidIdProvided()
        {
            // Arrange
            var mockRepository = new Mock<IRepository<Contact>>();
            var controller = new ContactController(mockRepository.Object);
            int invalidId = 999;

            // Mock Repository Behavior
            mockRepository.Setup(repo => repo.GetById(invalidId))
                .Returns((Contact)null);

            // Act
            var result = controller.GetById(invalidId);

            // Assert
            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }

        
    }
}
