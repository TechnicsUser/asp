using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using WebApplication9;
using WebApplication9.Controllers;




namespace UnitTestProject1.Controller
    {
    [TestClass]
    public class AspNetUsersController
        {
        [TestMethod]
        public ActionResult Index() {
            // Arrange
            AspNetUsersController controller = new AspNetUsersController();

            // Act
           ActionResult result = controller.Index() as ActionResult; //.result ;
            // Assert
            Assert.IsNotNull(result);
            return null;
            }

        [TestMethod]
        public void UserView() {
            // Arrange
            AspNetUsersController controller = new AspNetUsersController();

            // Act
            ViewResult result = controller.UserView() as ViewResult;

            // Assert
            Assert.AreEqual("Your application description page.", result.ViewBag.Message);
            }

      


        }
    }


 
