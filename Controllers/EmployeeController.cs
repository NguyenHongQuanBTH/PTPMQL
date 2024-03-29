// using Microsoft.AspNetCore.Mvc;
// namespace DemoMVC.Controllers
// {

//         public class EmployeeController : Controller
//         {
//             public IActionResult Index()
//             {
//                 return View();
//             }
//             public IActionResult Number()
//             {
//                 return View();
//             }
//             public IActionResult Email()
//             {
//                 return View();
//             }
//         [HttpPost]
//         public IActionResult Index(string QName, string eplID, string Email)
//         {
//             string strResult = "Xin chao" + "-" + QName + "-" + eplID + "-" + Email;
        
//             ViewBag.thongBao = strResult;
//             return View();
//         }
//         }

//         //Nguyen Hong Quan - 1921050489
// }
using DemoMVC.Data;
using DemoMVC.Models;
using DemoMVC.Models.Process;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using X.PagedList;

namespace DemoMVC.Controllers{
    public class EmployeeController : Controller
    {
        private readonly ApplicationDbcontext _context;
        public EmployeeController(ApplicationDbcontext context){
            _context=context;
        }
         private ExcelProcess _excelPro = new ExcelProcess();
        public async Task<IActionResult> Index(int? page, int? PageSize )
        {
            ViewBag.PageSize = new List<SelectListItem>()
            {
                new SelectListItem() { Value="3",Text= "3"},
                new SelectListItem() { Value="5",Text= "5"},
                new SelectListItem() { Value="10",Text= "10"},
                new SelectListItem() { Value="15",Text= "15"},
                new SelectListItem() { Value="25",Text= "25"},
                new SelectListItem() { Value="50",Text= "50"},
                
        
            };
            int pagesize = (PageSize ?? 3);
            ViewBag.psize = pagesize;
            var model = _context.Employee.ToList().ToPagedList(page ?? 1, pagesize);
            return View(model);
        }
        public IActionResult Create(){
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create ([Bind("EmployeeID,FullName,Address, Gender, Age")] Employee employee){
            if(ModelState.IsValid){
                _context.Add(employee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }
        public async Task<IActionResult> Edit(String id)
        {
            if (id == null || _context.Employee == null)
            {
                return NotFound();
            }
            var employee = await _context.Employee.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(String id, [Bind("EmployeeID, FullName, Address, Gender, Age")] Employee employee){
            if (id !=employee.EmployeeID){
                return NotFound();
            }
            if (ModelState.IsValid){
                try{
                    _context.Update(employee);
                    await _context.SaveChangesAsync();
                }catch(DbUpdateConcurrencyException){
                    if (!PersonExists(employee.EmployeeID)){
                        return NotFound();
                    }else{
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        private bool PersonExists(string id)
        {
            return (_context.Employee?.Any(e=>e.EmployeeID==id)).GetValueOrDefault();
        }
        public async Task<IActionResult> Delete(String id)
        {
            if(id==null || _context.Employee == null){
                return NotFound();
            }
            var employee = await _context.Employee.FirstOrDefaultAsync(m => m.EmployeeID == id);
            if (employee ==  null){
                return NotFound();
            }
            return View();
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConFirmed(String id){
            if(_context.Employee==null){
                return Problem ("Entity set 'ApplicationDbcontext.Employee' is null." );
            }
            var employee = await _context.Employee.FindAsync(id);
            if (employee !=null)
            {
                _context.Employee.Remove(employee);
            }
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            if (file!=null)
                {
                    string fileExtension = Path.GetExtension(file.FileName);
                    if (fileExtension != ".xls" && fileExtension != ".xlsx")
                    {
                        ModelState.AddModelError("", "Please choose excel file to upload!");
                    }
                    else
                    {
                        //rename file when upload to server
                        var filePath = Path.Combine(Directory.GetCurrentDirectory() + "/Uploads/Excels", "File" + DateTime.Now.Day + DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Millisecond + fileExtension);
                        var fileLocation = new FileInfo(filePath).ToString();
                        if (file.Length > 0)
                        {
                            using (var stream = new FileStream(filePath, FileMode.Create))
                            {
                                //save file to server
                                await file.CopyToAsync(stream);
                                //read data from file and write to database
                                var dt = _excelPro.ExcelToDataTable(fileLocation);
                                for(int i = 0; i < dt.Rows.Count; i++)
                                {
                                    var epl = new Employee();
                                    epl.EmployeeID = dt.Rows[i][0].ToString();
                                    epl.FullName = dt.Rows[i][1].ToString();
                                    epl.Address = dt.Rows[i][2].ToString();
                                    epl.Gender = dt.Rows[i][3].ToString();
                                    
                                    _context.Add(epl);
                                }
                                await _context.SaveChangesAsync();
                                return RedirectToAction(nameof(Index));
                            }
                        }
                    }
                }
            
            return View();
        }  
         public IActionResult Download()
        {
            var fileName = "PersonList.xlsx";
            using(ExcelPackage excelPackage = new ExcelPackage())
            {
                ExcelWorksheet excelWorksheet = excelPackage.Workbook.Worksheets.Add("Sheet 1");
                excelWorksheet.Cells["A1"].Value = "PersonId";
                excelWorksheet.Cells["B1"].Value = "FullName";
                excelWorksheet.Cells["C1"].Value = "Address";
                var psList = _context.Person.ToList();
                excelWorksheet.Cells["A2"].LoadFromCollection(psList);
                var stream = new MemoryStream(excelPackage.GetAsByteArray());
                return File(stream,"application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",fileName);
            }
        }  
    }

}