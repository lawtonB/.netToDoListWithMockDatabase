using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Microsoft.Data.Entity;
using ToDoList.Controllers;
using ToDoList.Models;
using Xunit;
using Moq;

namespace ToDoList.Tests.ControllerTests
{
    public class ItemsControllerTest
    {
        Mock<IItemRepository> mock = new Mock<IItemRepository>();

        private void DbSetup()
        {
            mock.Setup(m => m.Items).Returns(new Item[]
            {
                new Item {ItemId = 1, Description = "Wash the dog" },
                new Item {ItemId = 2, Description = "Do the dishes" },
                new Item {ItemId = 3, Description = "Sweep the floor" }
            }.AsQueryable());
        }

        [Fact]
        public void Mock_Get_View_Result_Index_Test()
        {
            //Arrange 
            DbSetup();
            ItemsController controller = new ItemsController(mock.Object);

            //Act
            var result = controller.Index();

            //Assert
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void Mock_IndexListOfItems_Test()
        {
            //arrange
            DbSetup();
            ViewResult indexView = new ItemsController(mock.Object).Index() as ViewResult;

            //act

            var result = indexView.ViewData.Model;

            //assert
            Assert.IsType<List<Item>>(result);
        }

        [Fact]
        public void Mock_ConfirmEntry_Test()
        {
            DbSetup();
            ItemsController controller = new ItemsController(mock.Object);
            Item testItem = new Item();
            Category testCategory = new Category();
           
            testItem.Description = "wash the dog";
            testItem.CategoryId = 1;
            testItem.ItemId = 1;
           

            ViewResult indexView = controller.Index() as ViewResult;
            var collection = indexView.ViewData.Model as IEnumerable<Item>;

            Assert.Contains<Item>(testItem, collection); 
        }
        //[Fact]
        //public void Post_MethodsAddsItem_Test()
        //{
        //    //arrange
        //    ItemsController controller = new ItemsController();

        //    Category testCategory = new Category();

        //    Item testItem = new Item();

        //    testItem.CategoryId = 1;
        //    testItem.Description = "Test item";

        //    //act
        //    controller.Create(testItem);

        //    ViewResult indexView = new ItemsController().Index() as ViewResult;

        //    var collection = indexView.ViewData.Model as IEnumerable<Item>;

        //    //assert
        //    Assert.Contains<Item>(testItem, collection);
        //}
    }
}
