using System.Web.Mvc;

namespace NamyWork.Web.Controllers
{
    public class UserController : WebController
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }
    }
}