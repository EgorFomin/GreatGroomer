using Great_Groomer.Database;
using System.Web.Mvc;

namespace Great_Groomer.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return Redirect("/GroomBookings/Index");
        }
    }
}