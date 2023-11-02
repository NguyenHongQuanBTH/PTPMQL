using DemoMVC.Models;
using Microsoft.AspNetCore.Mvc;
namespace DemoMVC.Controllers
{

        public class PersonController : Controller
        {
            public IActionResult Index()
            {
                return View();
            }
         
             [HttpPost]
        
        
        public IActionResult Index(Person ps)
        {
            string strOutput = "Xin chao" + "-" + ps.PersonID + "-" + ps.FullName  + "-" + ps.Address;
        
            ViewBag.thongBao = strOutput;
            return View();
        }
    
        }

    
        
   
       //  Nguyen Hong Quan - 1921050489
}