using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Microsoft.Data.Entity;
using ToDoList.Controllers;
using ToDoList.Models;
using Xunit;

namespace ToDoList.Tests.ControllerTests
{
    public class ItemsControllerTest
    {
        [Fact]
        public void Get_View_Result_Index_Test()
        {
            //Arrange 
            ItemsController controller = new ItemsController();

            //Act
            var result = controller.Index();

            //Assert
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void Get_ModelList_Index_Test()
        {
            //arrange
            ItemsController controller = new ItemsController();
            IActionResult actionResult = controller.Index();
            ViewResult indexView = controller.Index() as ViewResult;

            //act

            var result = indexView.ViewData.Model;

            //assert
            Assert.IsType<List<Item>>(result);
        }

        [Fact]
        public void Post_MethodsAddsItem_Test()
        {
            //arrange
            ItemsController controller = new ItemsController();

            Category testCategory = new Category();

            Item testItem = new Item();

            testItem.CategoryId = 1;
            testItem.Description = "Test item";

            //act
            controller.Create(testItem);

            ViewResult indexView = new ItemsController().Index() as ViewResult;

            var collection = indexView.ViewData.Model as IEnumerable<Item>;

            //assert
            Assert.Contains<Item>(testItem, collection);
        }
    }
}
