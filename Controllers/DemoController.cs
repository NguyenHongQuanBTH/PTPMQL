using Microsoft.AspNetCore.Mvc;
namespace DemoMVC.Controllers
{

        public class DemoController : Controller
        {
            public IActionResult Index()
            {
                return View();
            }
        [HttpPost]
        public IActionResult Index(string QName, string Email)
        {
            string strResult = "Hello" + QName + Email;
            ViewBag.thongBao = strResult;
            return View();
        }
        }
        
    


}
