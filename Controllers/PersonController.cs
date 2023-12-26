// using Microsoft.EntityFrameworkCore;
// using DemoMVC.Data;
// using DemoMVC.Models;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.AspNetCore.Mvc.ModelBinding;
// using DemoMVC.Models.Process;

// namespace DemoMVC.Controllers
// {
//     public class PersonController : Controller
//     {
//         private readonly ApplicationDbcontext _context;
//         private ExcelProcess _excelProcess = new ExcelProcess();
//         public PersonController(ApplicationDbcontext context)
//         {
//             _context = context;
//         }
//         public async Task<IActionResult> Index()
//         {
//             var Models = await _context.Person.ToListAsync();
//             return View(Models);
//         }
//         public IActionResult Create()
//         {
//             return View();
//         }
//         [HttpPost]
//         [ValidateAntiForgeryToken]
//         public async Task<IActionResult> Create([Bind("PersonId, FullName, Address, Gennder")] Person person)
//         {
//            if(ModelState.IsValid)
//            {
//             _context.Add(person);
//             await _context.SaveChangesAsync();
//             return RedirectToAction(nameof(Index));
//            }
//            return View(person);
//         }
//         public async Task<IActionResult> Edit(string id)
//         {
//             if(id == null || _context.Person == null)
//             {
//                 return NotFound();
//             }
//             var person = await _context.Person.FindAsync(id);
//             if (person == null)
//             {
//                 return NotFound();
//             }
//             return View (person);
//         }
//         [HttpPost]
//         [ValidateAntiForgeryToken]
//         public async Task<IActionResult> Edit(string id, [Bind("PersonId, FullName, Address, Gender")] Person person)
//         {
//             if(id != person.PersonId)
//             {
//                 return NotFound();
//             }
//             if(ModelState.IsValid)
//             {
//                 try{
//                     _context.Update(person);
//                     await _context.SaveChangesAsync();
//                 }
//                 catch (DbUpdateConcurrencyException)
//                 {
//                     if(!PersonExists(person.PersonId))
//                     {
//                         return NotFound();
//                     }
//                     else
//                     {
//                         throw;
//                     }
//                 }
//                 return RedirectToAction(nameof(Index));
//             }
//             return View(person);
//         }
//         public async Task<IActionResult> Delete(string id)
//         {
//             if (id == null || _context.Person == null)
//             {
//                 return NotFound();
//             }
//             var person = await _context.Person
//             .FirstOrDefaultAsync(m => m.PersonId == id);
//             if(person == null)
//             {
//                 return NotFound();
//             }
//             return View(person);
//         }
//         [HttpPost, ActionName("Delete")]
//         [ValidateAntiForgeryToken]
//         public async Task<IActionResult> DeleteConfirmed(string id)
//         {
//             if(_context.Person == null)
//             {
//                 return Problem("Entity set 'ApplicationDbContext.Person' is null.");
//             }
//             var person = await _context.Person.FindAsync(id);
//             if(person != null)
//             {
//                 _context.Person.Remove(person);
//             }
//             await _context.SaveChangesAsync();
//             return RedirectToAction(nameof(Index));
//         }
//         public IActionResult Upload()
//         {
//             return View();
//         }
//         [HttpPost]
//         [ValidateAntiForgeryToken]
        
//         private bool PersonExists(string id)
//         {
//             return (_context.Person?.Any(e => e.PersonId == id)).GetValueOrDefault();
//         }
//     }
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
    public class PersonController : Controller
    {
        private readonly ApplicationDbcontext _context;
        public PersonController(ApplicationDbcontext context){
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
            var model = _context.Person.ToList().ToPagedList(page ?? 1, pagesize);
            return View(model);
        }
        public IActionResult Create(){
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create ([Bind("PersonId,FullName,Address")] Person person){
            if(ModelState.IsValid){
                _context.Add(person);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(person);
        }
        public async Task<IActionResult> Edit(String id)
        {
            if (id == null || _context.Person == null)
            {
                return NotFound();
            }
            var person = await _context.Person.FindAsync(id);
            if (person == null)
            {
                return NotFound();
            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(String id, [Bind("PersonId,FullName,Address")] Person person){
            if (id !=person.PersonId){
                return NotFound();
            }
            if (ModelState.IsValid){
                try{
                    _context.Update(person);
                    await _context.SaveChangesAsync();
                }catch(DbUpdateConcurrencyException){
                    if (!PersonExists(person.PersonId)){
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
            return (_context.Person?.Any(e=>e.PersonId==id)).GetValueOrDefault();
        }
        public async Task<IActionResult> Delete(String id)
        {
            if(id==null || _context.Person == null){
                return NotFound();
            }
            var person = await _context.Person.FirstOrDefaultAsync(m => m.PersonId == id);
            if (person ==  null){
                return NotFound();
            }
            return View();
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConFirmed(String id){
            if(_context.Person==null){
                return Problem ("Entity set 'ApplicationDbcontext.Person' is null." );
            }
            var person= await _context.Person.FindAsync(id);
            if (person !=null)
            {
                _context.Person.Remove(person);
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
                                    var ps = new Person();
                                    ps.PersonId =dt.Rows[i][0].ToString();
                                    ps.FullName = dt.Rows[i][1].ToString();
                                    ps.Address = dt.Rows[i][2].ToString();

                                    _context.Add(ps);
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
// NguyenHongQuan-1921050489