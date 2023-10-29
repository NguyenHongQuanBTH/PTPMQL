using Microsoft.AspNetCore.Mvc;
namespace DemoMVC.Controllers;


    public class PersonController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        
    [HttpPost]
        
        
    public IActionResult Index(string QName, string PersonID, string Email)
    {
        string str = "Xin chao" + "-" + QName + "-" + PersonID + "-" + Email;
        
        ViewBag.thongBao = str;
        return View();
    }
    }
    //Nguyen Hong Quan - 1921050489