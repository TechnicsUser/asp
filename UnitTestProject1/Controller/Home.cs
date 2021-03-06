﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using WebApplication9;
using WebApplication9.Controllers;




namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Index() {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert              return View(coralViewModel);

            Assert.IsNotNull(result);
            }

        [TestMethod]
        public void combineCoral() {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert    coral.PhotoList = CoralPhotoList;    return coral;
            Assert.IsNotNull(result);
            }

        [TestMethod]
        public void UserPhotos()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            FileContentResult result = controller.UserPhotos() as FileContentResult;
            string textContents = new UTF8Encoding().GetString(result.FileContents);

            // Assert   return new FileContentResult(userImage.UserPhoto, "image/jpeg"); || return File(imageData, "image/png");
            Assert.IsNotNull(textContents);
        }






        [TestMethod]
        public void About()   // working
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.About() as ViewResult;

            // Assert
            Assert.AreEqual("Your application description page.", result.ViewBag.Message);
        }

        [TestMethod]
        public void Contact()  // working
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Contact() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        

    }
}
