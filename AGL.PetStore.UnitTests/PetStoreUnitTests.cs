using AGL.PetStore.Controllers;
using AGL.PetStore.Models;
using AGL.PetStore.Services;
using AGL.PetStore.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace AGL.PetStore.UnitTests
{
    public class PetStoreTests
    {
        [Fact]
        public async Task Test_PetStore_Index_Returns_ValidSortedListOfCats()
        {
            // Arrange
            var mockService = new Mock<IPetStoreService>();
            mockService.Setup(s => s.GetPetOwners())
                .ReturnsAsync(GetTestPetOwners());

            var controller = new HomeController(mockService.Object);

            //Act
            var result = await controller.Index();

            //Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<PetsViewModel>>(
                viewResult.ViewData.Model);

            //count
            Assert.Equal(2, model.Count());

            //order
            Assert.Equal("Cat1", model.First().Name);
            
        }

        [Fact]
        public async Task Test_PetStore_Returns_Server_Error()
        {
            // Arrange
            var mockService = new Mock<IPetStoreService>();
            mockService.Setup(s => s.GetPetOwners())
                .Throws(new Exception("Something went wrong"));

            var controller = new HomeController(mockService.Object);
            
            //Act
            var result = await controller.Index();
            
            //Assert
            var viewResult = Assert.IsType<ViewResult>(result);         

            //count
            Assert.Equal("Something went wrong", viewResult.ViewData["Error"]);                     

        }

        private List<PetOwnersModel> GetTestPetOwners()
        {
            return new List<PetOwnersModel>()
            { new PetOwnersModel { Name= "Owner1",Age=32,Gender=GenderEnum.Male,Pets = new List<PetsModel>{new PetsModel{ Name="Cat2", Type="CAT"} } },
            { new PetOwnersModel { Name= "Owner2",Age=32,Gender=GenderEnum.Male,Pets = new List<PetsModel>{new PetsModel{ Name="Cat1", Type="Cat"}, new PetsModel{Name="Dog1",Type="Dog" } } } },
            { new PetOwnersModel { Name= "Owner3",Age=32,Gender=GenderEnum.Female,Pets = new List<PetsModel>{new PetsModel{ Name="Dog2", Type="Dog"}, new PetsModel{Name="Monkey1",Type="Monkey" } } } }
            };
        }
    }
}
