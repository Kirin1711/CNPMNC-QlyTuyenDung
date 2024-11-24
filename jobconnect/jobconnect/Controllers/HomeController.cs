using jobconnect.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace jobconnect.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly RecruitmentManagementContext _context; // Giả sử bạn có DbContext là JobContext

        public HomeController(ILogger<HomeController> logger, RecruitmentManagementContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Home(string keyword, string searchLocation, string searchProfession, string searchCompany)
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
        public async Task<IActionResult> Home1(string keyword, string searchLocation, string searchProfession, string searchCompany)
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
        public async Task<IActionResult> Home2(string keyword, string searchLocation, string searchProfession, string searchCompany)
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

        public async Task<IActionResult> Home3(string keyword, string searchLocation, string searchProfession, string searchCompany)
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

        public async Task<IActionResult> JobDetails(int? id)
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

		public async Task<IActionResult> JobDetails1(int? id)
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

        public async Task<IActionResult> JobDetails2(int? id)
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
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
