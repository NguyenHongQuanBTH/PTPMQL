using Microsoft.AspNetCore.Mvc;
namespace DemoMVC.Controllers;


    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Number()
        {
            return View();
        }
        public IActionResult Email()
        {
            return View();
        }
    [HttpPost]
    public IActionResult Index(string QName, string Email, string eplID)
    {
        string strResult = "Xin chao" + "-" + QName + "-" + eplID + "-" + Email;
        
        ViewBag.thongBao = strResult;
        return View();
    }
    }
    //Nguyen Hong Quan - 1921050489