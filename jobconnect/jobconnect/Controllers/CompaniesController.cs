using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using jobconnect.Models;
using Microsoft.AspNetCore.Hosting;

namespace jobconnect.Controllers
{
    public class CompaniesController : Controller
    {
        private readonly RecruitmentManagementContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public CompaniesController(RecruitmentManagementContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: Companies
        public async Task<IActionResult> Index()
        {
            var recruitmentManagementContext = _context.Companies.Include(c => c.Field);
            return View(await recruitmentManagementContext.ToListAsync());
        }

        public async Task<IActionResult> Index1()
        {
            var recruitmentManagementContext = _context.Companies.Include(c => c.Field);
            return View(await recruitmentManagementContext.ToListAsync());
        }

        public async Task<IActionResult> Index2()
        {
            var recruitmentManagementContext = _context.Companies.Include(c => c.Field);
            return View(await recruitmentManagementContext.ToListAsync());
        }
        public async Task<IActionResult> Index3(string searchName, string searchField)
        {
            ViewData["Fields"] = new SelectList(await _context.Fields.ToListAsync(), "FieldName", "FieldName");

            IQueryable<Company> recruitmentManagementContext = _context.Companies
                .Include(c => c.Field);

            if (!string.IsNullOrEmpty(searchName))
            {
                recruitmentManagementContext = recruitmentManagementContext.Where(c => c.CompanyName.Contains(searchName));
            }
            if (!string.IsNullOrEmpty(searchField))
            {
                recruitmentManagementContext = recruitmentManagementContext
                    .Where(c => c.Field.FieldName == searchField);
            }
            return View(await recruitmentManagementContext.ToListAsync());
        }
        // GET: Companies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var company = await _context.Companies
                .Include(c => c.Field)
                .FirstOrDefaultAsync(m => m.CompanyId == id);
            if (company == null)
            {
                return NotFound();
            }

            return View(company);
        }

        // GET: Companies/Create
        public IActionResult Create()
        {
            ViewData["FieldId"] = new SelectList(_context.Fields, "FieldId", "FieldName");
            return View();
        }

        // POST: Companies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CompanyId,CompanyName,Address,Phone,EmailCompanies,Website,ImageFile,FieldId")] Company company)
        {
            if (ModelState.IsValid)
            {
                if (company.ImageFile != null)
                {
                    // Lấy đường dẫn thư mục để lưu hình ảnh
                    string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images");
                    // Tạo tên file duy nhất cho hình ảnh
                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + company.ImageFile.FileName;
                    // Tạo đường dẫn đầy đủ đến file
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    // Lưu file hình ảnh vào thư mục
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await company.ImageFile.CopyToAsync(fileStream);
                    }

                    // Lưu tên file vào thuộc tính ImageNews
                    company.AvartarCompanies = uniqueFileName;
                }
                _context.Add(company);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index3));
            }
            ViewData["FieldId"] = new SelectList(_context.Fields, "FieldId", "FieldName", company.FieldId);
            return View(company);
        }

        // GET: Companies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var company = await _context.Companies.FindAsync(id);
            if (company == null)
            {
                return NotFound();
            }
            ViewData["FieldId"] = new SelectList(_context.Fields, "FieldId", "FieldName", company.FieldId);
            return View(company);
        }

        // POST: Companies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CompanyId,CompanyName,Address,Phone,EmailCompanies,Website,AvartarCompanies,FieldId")] Company company, IFormFile AvatarFile)
        {
            if (id != company.CompanyId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // Kiểm tra xem người dùng có tải lên ảnh mới không
                    if (AvatarFile != null)
                    {
                        // Nếu có ảnh mới, lưu ảnh vào thư mục images
                        string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images");
                        string uniqueFileName = Guid.NewGuid().ToString() + "_" + AvatarFile.FileName;
                        string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                        // Lưu ảnh vào thư mục
                        using (var fileStream = new FileStream(filePath, FileMode.Create))
                        {
                            await AvatarFile.CopyToAsync(fileStream);
                        }

                        // Cập nhật AvatarUrl trong cơ sở dữ liệu với tên file mới
                        company.AvartarCompanies = uniqueFileName;
                    }
                    else
                    {
                        // Nếu không có ảnh mới, giữ nguyên AvatarUrl hiện tại
                        var currentCompany = await _context.Companies.FindAsync(id);
                        company.AvartarCompanies = currentCompany.AvartarCompanies; // Giữ nguyên avatar cũ
                    }

                    _context.Update(company);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CompanyExists(company.CompanyId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index3));
            }
            ViewData["FieldId"] = new SelectList(_context.Fields, "FieldId", "FieldName", company.FieldId);
            return View(company);
        }

        // GET: Companies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var company = await _context.Companies
                .Include(c => c.Field)
                .FirstOrDefaultAsync(m => m.CompanyId == id);
            if (company == null)
            {
                return NotFound();
            }

            return View(company);
        }

        // POST: Companies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var company = await _context.Companies.FindAsync(id);
            if (company != null)
            {
                _context.Companies.Remove(company);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CompanyExists(int id)
        {
            return _context.Companies.Any(e => e.CompanyId == id);
        }
    }
}
