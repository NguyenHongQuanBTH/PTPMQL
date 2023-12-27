using DemoMVC.Data;
using DemoMVC.Models;
using DemoMVC.Models.Process;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using X.PagedList;

namespace DemoMVC.Controllers {
    public class DaiLyController : Controller
    {
        private readonly ApplicationDbcontext _context;
        public DaiLyController(ApplicationDbcontext context){
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
        public async Task<IActionResult> Create ([Bind("MaDaiLy, TenDaiLy, DiaChi, NguoiDaiDien, DienThoai, MaHTPP")] DaiLy daiLy){
            if(ModelState.IsValid){
                _context.Add(daiLy);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(daiLy);
        }
        public async Task<IActionResult> Edit(String id)
        {
            if (id == null || _context.DaiLy == null)
            {
                return NotFound();
            }
            var daily = await _context.DaiLy.FindAsync(id);
            if (daily == null)
            {
                return NotFound();
            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(String id, [Bind("MaDaiLy, TenDaiLy, DiaChi, NguoiDaiDien, DienThoai, MaHTPP")] DaiLy daiLy){
            if (id !=daiLy.MaDaiLy){
                return NotFound();
            }
            if (ModelState.IsValid){
                try{
                    _context.Update(daiLy);
                    await _context.SaveChangesAsync();
                }catch(DbUpdateConcurrencyException){
                    if (!PersonExists(daiLy.MaDaiLy)){
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
            return (_context.DaiLy?.Any(e=>e.MaDaiLy==id)).GetValueOrDefault();
        }
        public async Task<IActionResult> Delete(String id)
        {
            if(id==null || _context.DaiLy == null){
                return NotFound();
            }
            var daily = await _context.DaiLy.FirstOrDefaultAsync(m => m.MaDaiLy == id);
            if (daily ==  null){
                return NotFound();
            }
            return View();
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConFirmed(String id){
            if(_context.DaiLy==null){
                return Problem ("Entity set 'ApplicationDbcontext.DaiLy' is null." );
            }
            var daily = await _context.DaiLy.FindAsync(id);
            if (daily !=null)
            {
                _context.DaiLy.Remove(daily);
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
                                    var dl = new DaiLy();
                                    dl.MaDaiLy = dt.Rows[i][0].ToString();
                                    dl.TenDaiLy = dt.Rows[i][1].ToString();
                                    dl.DiaChi = dt.Rows[i][2].ToString();
                                    dl.NguoiDaiDien = dt.Rows[i][3].ToString();
                                    dl.DienThoai = dt.Rows[i][4].ToString();
                                     dl.MaHTPP = dt.Rows[i][5].ToString();
                                    _context.Add(dl);
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