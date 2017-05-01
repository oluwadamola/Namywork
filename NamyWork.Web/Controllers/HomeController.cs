using NamyWork.Core.Manager;
using System;
using System.IO;
using System.Web;
using System.Web.Mvc;

namespace NamyWork.Web.Controllers
{
    public class HomeController : WebController
    {
        private readonly IServiceManager _serviceManager;
        public HomeController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }
        // GET: Home
        public ActionResult Index()
        {

            return View();
        }

        public ActionResult UdatePixs()
        {
            var tempPix = new[] {
               new {Id = 1, PicsName = "/Content/images/1.jpg" },
               new {Id = 2, PicsName = "/Content/images/2.jpg" },
               new {Id = 3, PicsName = "/Content/images/3.jpg" },
               new {Id = 4, PicsName = "/Content/images/4.jpg" },
               new {Id = 5, PicsName = "/Content/images/5.jpg" },
               new {Id = 6, PicsName = "/Content/images/6.jpg" },
               new {Id = 7, PicsName = "/Content/images/7.jpg" },
               new {Id = 8, PicsName = "/Content/images/8.jpg" },
               new {Id = 9, PicsName = "/Content/images/9.jpg" },
               new {Id = 10, PicsName = "/Content/images/10.jpg" },
               new {Id = 11, PicsName = "/Content/images/11.jpg" },
               new {Id = 12, PicsName = "/Content/images/12.jpg" },
               new {Id = 13, PicsName = "/Content/images/13.jpg" },
               new {Id = 14, PicsName = "/Content/images/14.jpg" },
               new {Id = 15, PicsName = "/Content/images/15.jpg" },
               new {Id = 16, PicsName = "/Content/images/16.jpg" },
               new {Id = 17, PicsName = "/Content/images/17.jpg" },
               new {Id = 18, PicsName = "/Content/images/18.jpg" },
               new {Id = 19, PicsName = "/Content/images/19.jpg" }
            };
            foreach (var pix in tempPix)
            {
                var service = _serviceManager.GetService(pix.Id).Unwrap();
                service.ImageUrl = GetPics(pix.PicsName);
                _serviceManager.UpdateService(service);
            }
            return null;
        }

        public byte[] GetPics(string path)
        {
            byte[] filebyte;
            FileStream file = new FileStream(HttpRuntime.AppDomainAppPath + path, FileMode.Open);
            using (var br = new BinaryReader(file))
            {
                filebyte = br.ReadBytes((int)file.Length);
            }
            return filebyte;
        }

    }
}