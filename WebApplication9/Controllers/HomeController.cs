using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication9.Filters;
using WebApplication9.Models;

namespace WebApplication9.Controllers
{
    //[RequireHttps]

    public class HomeController : Controller
    {

         

        public ActionResult Index()
        {

            return View();
        }


        public FileContentResult UserPhotos()
        {
         
                if (User.Identity.IsAuthenticated)
                {


                    String userId = User.Identity.GetUserId();

                    var bdUsers = HttpContext.GetOwinContext().Get<ApplicationDbContext>();
                    var userImage = bdUsers.Users.Where(x => x.Id == userId).FirstOrDefault();

                    return new FileContentResult(userImage.UserPhoto, "image/jpeg");
                }
                else
                {
                    string fileName = HttpContext.Server.MapPath(@"~/Images/noImg.png");

                    byte[] imageData = null;
                    FileInfo fileInfo = new FileInfo(fileName);
                    long imageFileLength = fileInfo.Length;
                    FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                    BinaryReader br = new BinaryReader(fs);
                    imageData = br.ReadBytes((int)imageFileLength);
                    return File(imageData, "image/png");

                }
           

        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";


            return View();
        }
        //[Authorize]

        public ActionResult Contact()
        {

            return View();
        }



    }
}
