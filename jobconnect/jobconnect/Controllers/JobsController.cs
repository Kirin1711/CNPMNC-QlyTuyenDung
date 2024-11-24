using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using jobconnect.Models;

namespace jobconnect.Controllers
{
    public class JobsController : Controller
    {
        private readonly RecruitmentManagementContext _context;

        public JobsController(RecruitmentManagementContext context)
        {
            _context = context;
        }

        // GET: Jobs
        public async Task<IActionResult> Index(string keyword, string searchLocation, string searchProfession, string searchCompany)
        {
            // Lấy danh sách Location, Profession và Company để hiển thị trong dropdown
            ViewData["Locations"] = new SelectList(await _context.Locations.ToListAsync(), "LocationName", "LocationName");
            ViewData["Professions"] = new SelectList(await _context.Professions.ToListAsync(), "ProfessionName", "ProfessionName");
            ViewData["Companies"] = new SelectList(await _context.Companies.ToListAsync(), "CompanyName", "CompanyName");

            IQueryable<Job> recruitmentManagementContext = _context.Jobs
                .Include(j => j.Company)
                .Include(j => j.JobType)
                .Include(j => j.Location)
                .Include(j => j.Profession)
                .Where(j => j.Status == "Approved"); // Chỉ lấy công việc đã được duyệt

            // Lọc theo Title
            if (!string.IsNullOrEmpty(keyword))
            {
                recruitmentManagementContext = recruitmentManagementContext.Where(j => j.Title.Contains(keyword) || j.Description.Contains(keyword));
            }

            // Lọc theo Location
            if (!string.IsNullOrEmpty(searchLocation))
            {
                recruitmentManagementContext = recruitmentManagementContext
                    .Where(j => j.Location.LocationName == searchLocation);
            }

            // Lọc theo Profession
            if (!string.IsNullOrEmpty(searchProfession))
            {
                recruitmentManagementContext = recruitmentManagementContext
                    .Where(j => j.Profession.ProfessionName == searchProfession);
            }

            // Lọc theo Company
            if (!string.IsNullOrEmpty(searchCompany))
            {
                recruitmentManagementContext = recruitmentManagementContext
                    .Where(j => j.Company.CompanyName.Contains(searchCompany));
            }

            return View(await recruitmentManagementContext.ToListAsync());
        }


        public async Task<IActionResult> Index1(string keyword, string searchLocation, string searchProfession, string searchCompany)
        {
            // Lấy danh sách Location, Profession và Company để hiển thị trong dropdown
            ViewData["Locations"] = new SelectList(await _context.Locations.ToListAsync(), "LocationName", "LocationName");
            ViewData["Professions"] = new SelectList(await _context.Professions.ToListAsync(), "ProfessionName", "ProfessionName");
            ViewData["Companies"] = new SelectList(await _context.Companies.ToListAsync(), "CompanyName", "CompanyName");

            IQueryable<Job> recruitmentManagementContext = _context.Jobs
                .Include(j => j.Company)
                .Include(j => j.JobType)
                .Include(j => j.Location)
                .Include(j => j.Profession)
                .Where(j => j.Status == "Approved");

            // Lọc theo Title
            if (!string.IsNullOrEmpty(keyword))
            {
                recruitmentManagementContext = recruitmentManagementContext.Where(j => j.Title.Contains(keyword) || j.Description.Contains(keyword));
            }

            // Lọc theo Location
            if (!string.IsNullOrEmpty(searchLocation))
            {
                recruitmentManagementContext = recruitmentManagementContext
                    .Where(j => j.Location.LocationName == searchLocation);
            }

            // Lọc theo Profession
            if (!string.IsNullOrEmpty(searchProfession))
            {
                recruitmentManagementContext = recruitmentManagementContext
                    .Where(j => j.Profession.ProfessionName == searchProfession);
            }

            // Lọc theo Company
            if (!string.IsNullOrEmpty(searchCompany))
            {
                recruitmentManagementContext = recruitmentManagementContext
                    .Where(j => j.Company.CompanyName.Contains(searchCompany));
            }

            return View(await recruitmentManagementContext.ToListAsync());
        }

        public async Task<IActionResult> Index2(string keyword, string searchLocation, string searchProfession, string searchCompany)
        {
            // Lấy danh sách Location, Profession và Company để hiển thị trong dropdown
            ViewData["Locations"] = new SelectList(await _context.Locations.ToListAsync(), "LocationName", "LocationName");
            ViewData["Professions"] = new SelectList(await _context.Professions.ToListAsync(), "ProfessionName", "ProfessionName");
            ViewData["Companies"] = new SelectList(await _context.Companies.ToListAsync(), "CompanyName", "CompanyName");

            // Lấy CompanyId của người dùng hiện tại (giả sử có trong cookie)
            var currentUserCompanyId = int.Parse(Request.Cookies["CompanyId"]);

            IQueryable<Job> recruitmentManagementContext = _context.Jobs
                .Include(j => j.Company)
                .Include(j => j.JobType)
                .Include(j => j.Location)
                .Include(j => j.Profession)
                .Where(j => j.CompanyId == currentUserCompanyId); // Lọc theo CompanyId của người dùng hiện tại

            // Lọc theo Title
            if (!string.IsNullOrEmpty(keyword))
            {
                recruitmentManagementContext = recruitmentManagementContext.Where(j => j.Title.Contains(keyword) || j.Description.Contains(keyword));
            }

            // Lọc theo Location
            if (!string.IsNullOrEmpty(searchLocation))
            {
                recruitmentManagementContext = recruitmentManagementContext
                    .Where(j => j.Location.LocationName == searchLocation);
            }

            // Lọc theo Profession
            if (!string.IsNullOrEmpty(searchProfession))
            {
                recruitmentManagementContext = recruitmentManagementContext
                    .Where(j => j.Profession.ProfessionName == searchProfession);
            }

            // Lọc theo Company (nếu có)
            if (!string.IsNullOrEmpty(searchCompany))
            {
                recruitmentManagementContext = recruitmentManagementContext
                    .Where(j => j.Company.CompanyName.Contains(searchCompany));
            }

            return View(await recruitmentManagementContext.ToListAsync());
        }

        public async Task<IActionResult> Index3(string keyword, string searchLocation, string searchProfession, string searchCompany)
        {
            // Lấy danh sách Location, Profession và Company để hiển thị trong dropdown
            ViewData["Locations"] = new SelectList(await _context.Locations.ToListAsync(), "LocationName", "LocationName");
            ViewData["Professions"] = new SelectList(await _context.Professions.ToListAsync(), "ProfessionName", "ProfessionName");
            ViewData["Companies"] = new SelectList(await _context.Companies.ToListAsync(), "CompanyName", "CompanyName");

            IQueryable<Job> recruitmentManagementContext = _context.Jobs
                .Include(j => j.Company)
                .Include(j => j.JobType)
                .Include(j => j.Location)
                .Include(j => j.Profession)
                .Where(j => j.Status == "Approved");

            // Lọc theo Title
            if (!string.IsNullOrEmpty(keyword))
            {
                recruitmentManagementContext = recruitmentManagementContext.Where(j => j.Title.Contains(keyword) || j.Description.Contains(keyword));
            }

            // Lọc theo Location
            if (!string.IsNullOrEmpty(searchLocation))
            {
                recruitmentManagementContext = recruitmentManagementContext
                    .Where(j => j.Location.LocationName == searchLocation);
            }

            // Lọc theo Profession
            if (!string.IsNullOrEmpty(searchProfession))
            {
                recruitmentManagementContext = recruitmentManagementContext
                    .Where(j => j.Profession.ProfessionName == searchProfession);
            }

            // Lọc theo Company
            if (!string.IsNullOrEmpty(searchCompany))
            {
                recruitmentManagementContext = recruitmentManagementContext
                    .Where(j => j.Company.CompanyName.Contains(searchCompany));
            }

            return View(await recruitmentManagementContext.ToListAsync());
        }

        public async Task<IActionResult> Index4(string keyword, string searchLocation, string searchProfession, string searchCompany)
        {
            // Lấy danh sách Location, Profession và Company để hiển thị trong dropdown
            ViewData["Locations"] = new SelectList(await _context.Locations.ToListAsync(), "LocationName", "LocationName");
            ViewData["Professions"] = new SelectList(await _context.Professions.ToListAsync(), "ProfessionName", "ProfessionName");
            ViewData["Companies"] = new SelectList(await _context.Companies.ToListAsync(), "CompanyName", "CompanyName");

            IQueryable<Job> recruitmentManagementContext = _context.Jobs
                .Include(j => j.Company)
                .Include(j => j.JobType)
                .Include(j => j.Location)
                .Include(j => j.Profession);

            // Lọc theo Title
            if (!string.IsNullOrEmpty(keyword))
            {
                recruitmentManagementContext = recruitmentManagementContext.Where(j => j.Title.Contains(keyword) || j.Description.Contains(keyword));
            }

            // Lọc theo Location
            if (!string.IsNullOrEmpty(searchLocation))
            {
                recruitmentManagementContext = recruitmentManagementContext
                    .Where(j => j.Location.LocationName == searchLocation);
            }

            // Lọc theo Profession
            if (!string.IsNullOrEmpty(searchProfession))
            {
                recruitmentManagementContext = recruitmentManagementContext
                    .Where(j => j.Profession.ProfessionName == searchProfession);
            }

            // Lọc theo Company
            if (!string.IsNullOrEmpty(searchCompany))
            {
                recruitmentManagementContext = recruitmentManagementContext
                    .Where(j => j.Company.CompanyName.Contains(searchCompany));
            }

            return View(await recruitmentManagementContext.ToListAsync());
        }

        [HttpPost]
        public IActionResult ApproveJob(int jobId)
        {
            var job = _context.Jobs.FirstOrDefault(j => j.JobId == jobId);
            if (job != null)
            {
                job.Status = "Approved"; // Đổi trạng thái thành 'Đã duyệt'
                _context.SaveChanges();
            }
            return RedirectToAction("Index4"); // Quay lại danh sách công việc
        }

        [HttpPost]
        public IActionResult RejectJob(int jobId)
        {
            var job = _context.Jobs.FirstOrDefault(j => j.JobId == jobId);
            if (job != null)
            {
                job.Status = "Rejected"; // Đổi trạng thái thành 'Bị từ chối'
                _context.SaveChanges();
            }
            return RedirectToAction("Index4"); // Quay lại danh sách công việc
        }


        // GET: Jobs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var job = await _context.Jobs
                .Include(j => j.Company)
                .Include(j => j.JobType)
                .Include(j => j.Location)
                .Include(j => j.Profession)
                .FirstOrDefaultAsync(m => m.JobId == id);
            if (job == null)
            {
                return NotFound();
            }

            return View(job);
        }

        public async Task<IActionResult> Details1(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var job = await _context.Jobs
                .Include(j => j.Company)
                .Include(j => j.JobType)
                .Include(j => j.Location)
                .Include(j => j.Profession)
                .FirstOrDefaultAsync(m => m.JobId == id);
            if (job == null)
            {
                return NotFound();
            }

            return View(job);
        }

        public async Task<IActionResult> Details2(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var job = await _context.Jobs
                .Include(j => j.Company)
                .Include(j => j.JobType)
                .Include(j => j.Location)
                .Include(j => j.Profession)
                .FirstOrDefaultAsync(m => m.JobId == id);
            if (job == null)
            {
                return NotFound();
            }

            return View(job);
        }
        public async Task<IActionResult> Details3(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var job = await _context.Jobs
                .Include(j => j.Company)
                .Include(j => j.JobType)
                .Include(j => j.Location)
                .Include(j => j.Profession)
                .FirstOrDefaultAsync(m => m.JobId == id);
            if (job == null)
            {
                return NotFound();
            }

            return View(job);
        }

        // GET: Jobs/Create
        public IActionResult Create()
        {
            ViewData["JobTypeId"] = new SelectList(_context.JobTypes, "JobTypeId", "JobTypeName");
            ViewData["ProfessionId"] = new SelectList(_context.Professions, "ProfessionId", "ProfessionName");
            ViewData["LocationId"] = new SelectList(_context.Locations, "LocationId", "LocationName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("JobId,Title,Description,Location,SalaryRange,PostedDate,ExperienceLevel,JobTypeId,ProfessionId,LocationId")] Job job)
        {
            // Lấy CompanyId từ cookie
            var companyId = Request.Cookies["CompanyId"];
            job.PostedDate = DateTime.Now;
            if (ModelState.IsValid)
            {
                // Gán CompanyId từ cookie vào job
                job.CompanyId = int.Parse(companyId); // Chuyển đổi từ string sang int nếu cần

                _context.Add(job);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index2));
            }

            ViewData["CompanyId"] = new SelectList(_context.Companies, "CompanyId", "CompanyName", job.CompanyId);
            ViewData["JobTypeId"] = new SelectList(_context.JobTypes, "JobTypeId", "JobTypeName", job.JobTypeId);
            ViewData["ProfessionId"] = new SelectList(_context.Professions, "ProfessionId", "ProfessionName", job.ProfessionId);
            ViewData["LocationId"] = new SelectList(_context.Locations, "LocationId", "LocationName", job.LocationId);
            return View(job);
        }


        // GET: Jobs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var job = await _context.Jobs.FindAsync(id);
            if (job == null)
            {
                return NotFound();
            }
            ViewData["CompanyId"] = new SelectList(_context.Companies, "CompanyId", "CompanyName", job.CompanyId);
            ViewData["JobTypeId"] = new SelectList(_context.JobTypes, "JobTypeId", "JobTypeName", job.JobTypeId);
            ViewData["LocationId"] = new SelectList(_context.Locations, "LocationId", "LocationName", job.LocationId);
            ViewData["ProfessionId"] = new SelectList(_context.Professions, "ProfessionId", "ProfessionName", job.ProfessionId);
            return View(job);
        }

        // POST: Jobs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("JobId,Title,Description,SalaryRange,PostedDate,ExperienceLevel,JobTypeId,CompanyId,ProfessionId,LocationId")] Job job)
        {
            if (id != job.JobId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(job);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JobExists(job.JobId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index2));
            }
            ViewData["CompanyId"] = new SelectList(_context.Companies, "CompanyId", "CompanyName", job.CompanyId);
            ViewData["JobTypeId"] = new SelectList(_context.JobTypes, "JobTypeId", "JobTypeName", job.JobTypeId);
            ViewData["LocationId"] = new SelectList(_context.Locations, "LocationId", "LocationName", job.LocationId);
            ViewData["ProfessionId"] = new SelectList(_context.Professions, "ProfessionId", "ProfessionName", job.ProfessionId);
            return View(job);
        }

        // GET: Jobs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var job = await _context.Jobs
                .Include(j => j.Company)
                .Include(j => j.JobType)
                .Include(j => j.Location)
                .Include(j => j.Profession)
                .FirstOrDefaultAsync(m => m.JobId == id);
            if (job == null)
            {
                return NotFound();
            }

            return View(job);
        }

        // POST: Jobs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var job = await _context.Jobs.FindAsync(id);
            if (job != null)
            {
                _context.Jobs.Remove(job);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index2));
        }

        public async Task<IActionResult> Delete1(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var job = await _context.Jobs
                .Include(j => j.Company)
                .Include(j => j.JobType)
                .Include(j => j.Location)
                .Include(j => j.Profession)
                .FirstOrDefaultAsync(m => m.JobId == id);
            if (job == null)
            {
                return NotFound();
            }

            return View(job);
        }

        // POST: Jobs/Delete/5
        [HttpPost, ActionName("Delete1")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed1(int id)
        {
            var job = await _context.Jobs.FindAsync(id);
            if (job != null)
            {
                _context.Jobs.Remove(job);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index4));
        }
        public async Task<IActionResult> joblist()
        {
            var jobs = await _context.Jobs.ToListAsync();
            return View(jobs);  // Trả về view với danh sách công việc
        }
        private bool JobExists(int id)
        {
            return _context.Jobs.Any(e => e.JobId == id);
        }
    }
}
