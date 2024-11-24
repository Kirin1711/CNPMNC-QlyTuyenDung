using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using jobconnect.Models;
using System.ComponentModel.Design;

namespace jobconnect.Controllers
{
    public class ApplicationsController : Controller
    {
        private readonly RecruitmentManagementContext _context;

        public ApplicationsController(RecruitmentManagementContext context)
        {
            _context = context;
        }

        // GET: Applications
        public async Task<IActionResult> Index()
        {
            var userId = int.Parse(Request.Cookies["UserId"]);
            var recruitmentManagementContext = _context.Applications
                                   .Where(app => app.UserId == userId)
                                   .Include(app => app.Job)
                                   .Include(app => app.Status);
            return View(await recruitmentManagementContext.ToListAsync());
        }
        public async Task<IActionResult> Index1()
        {
            // Lấy UserId của người đăng nhập
            var userId = int.Parse(Request.Cookies["UserId"]);

            // Lấy CompanyId của người dùng đăng nhập (giả sử bạn đã có thông tin này từ User hoặc từ một dịch vụ nào đó)
            var recruiterCompanyId = _context.Users
                                             .Where(u => u.UserId == userId)
                                             .Select(u => u.CompanyId)
                                             .FirstOrDefault();

            // Lọc các application có job thuộc công ty của người đăng nhập
            var applications = await _context.Applications
                                              .Include(a => a.Job)
                                              .ThenInclude(j => j.Company)
                                              .Include(a => a.User)
                                              .Include(a => a.Status)
                                              .Where(a => a.Job.CompanyId == recruiterCompanyId)
                                              .ToListAsync();

            return View(applications);
        }


        // GET: Applications/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var application = await _context.Applications
                .Include(a => a.Job)
                .Include(a => a.Status)
                .Include(a => a.User)
                .FirstOrDefaultAsync(m => m.ApplicationId == id);
            if (application == null)
            {
                return NotFound();
            }

            return View(application);
        }

        // GET: Applications/Create
        public IActionResult Create(int jobId)
        {
            var job = _context.Jobs.FirstOrDefault(j => j.JobId == jobId);
            if (job == null)
            {
                return NotFound();
            }

            ViewBag.JobTitle = job.Title;
            ViewBag.JobId = jobId;
            ViewBag.DefaultStatusId = 6; // Giá trị mặc định cho StatusId (Pending)
            ViewData["StatusId"] = new SelectList(_context.ApplicationStatuses, "StatusId", "StatusName", 6);

            return View();
        }




        // POST: Applications/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ApplicationId,ApplicationDate")] Application application, int jobId, IFormFile Cv, IFormFile CoverLetter)
        {
            var userId = Request.Cookies["UserId"];
            application.ApplicationDate = DateTime.Now;
            application.JobId = jobId; // Gán JobId từ tham số jobId
            application.StatusId = 6; // Gán mặc định StatusId = 6 (Pending)
            application.UserId = int.Parse(userId);

            if (ModelState.IsValid)
            {
                // Tạo thư mục lưu trữ file nếu chưa tồn tại
                var uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads");
                if (!Directory.Exists(uploadPath))
                {
                    Directory.CreateDirectory(uploadPath);
                }

                // Xử lý upload file Cv
                if (Cv != null && Cv.Length > 0)
                {
                    var cvFileName = Guid.NewGuid() + Path.GetExtension(Cv.FileName);
                    var cvPath = Path.Combine(uploadPath, cvFileName);
                    using (var stream = new FileStream(cvPath, FileMode.Create))
                    {
                        await Cv.CopyToAsync(stream);
                    }
                    application.Cv = "/uploads/" + cvFileName; // Lưu đường dẫn vào thuộc tính Cv
                }

                // Xử lý upload file CoverLetter
                if (CoverLetter != null && CoverLetter.Length > 0)
                {
                    var coverLetterFileName = Guid.NewGuid() + Path.GetExtension(CoverLetter.FileName);
                    var coverLetterPath = Path.Combine(uploadPath, coverLetterFileName);
                    using (var stream = new FileStream(coverLetterPath, FileMode.Create))
                    {
                        await CoverLetter.CopyToAsync(stream);
                    }
                    application.CoverLetter = "/uploads/" + coverLetterFileName; // Lưu đường dẫn vào thuộc tính CoverLetter
                }

                application.UserId = int.Parse(userId); // Gán UserId từ cookie
                _context.Add(application);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.JobTitle = _context.Jobs.FirstOrDefault(j => j.JobId == jobId)?.Title;
            ViewData["StatusId"] = new SelectList(_context.ApplicationStatuses, "StatusId", "StatusName", 6);

            return View(application);
        }


        // GET: Applications/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var application = await _context.Applications.FindAsync(id);
            if (application == null)
            {
                return NotFound();
            }
            ViewData["JobId"] = new SelectList(_context.Jobs, "JobId", "Title", application.JobId);
            ViewData["StatusId"] = new SelectList(_context.ApplicationStatuses, "StatusId", "StatusName", application.StatusId);
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "FullName", application.UserId);
            return View(application);
        }

        // POST: Applications/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ApplicationId,Cv,CoverLetter,ApplicationDate,JobId,UserId,StatusId")] Application application)
        {
            if (id != application.ApplicationId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(application);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ApplicationExists(application.ApplicationId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index1));
            }
            ViewData["JobId"] = new SelectList(_context.Jobs, "JobId", "JobId", application.JobId);
            ViewData["StatusId"] = new SelectList(_context.ApplicationStatuses, "StatusId", "StatusId", application.StatusId);
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "UserId", application.UserId);
            return View(application);
        }

        // GET: Applications/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var application = await _context.Applications
                .Include(a => a.Job)
                .Include(a => a.Status)
                .Include(a => a.User)
                .FirstOrDefaultAsync(m => m.ApplicationId == id);
            if (application == null)
            {
                return NotFound();
            }

            return View(application);
        }

        // POST: Applications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var application = await _context.Applications.FindAsync(id);
            if (application != null)
            {
                _context.Applications.Remove(application);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index1));
        }

        private bool ApplicationExists(int id)
        {
            return _context.Applications.Any(e => e.ApplicationId == id);
        }
    }
}
