using System.Web.Mvc;

namespace NamyWork.Web.Controllers
{
    public class ProfileController : WebController
    {
        // GET: Profile
        public ActionResult Index()
        {
            return View();
        }
    }
}