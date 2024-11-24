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
    public class AdminController : Controller
    {
        private readonly RecruitmentManagementContext _context;

        public AdminController(RecruitmentManagementContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Statistics()
        {
            // 1. Số lượng công việc theo ngành
            var jobsByProfession = await _context.Jobs
                .Include(j => j.Profession)
                .GroupBy(j => j.Profession.ProfessionName)
                .Select(group => new
                {
                    Profession = group.Key ?? "Không xác định",
                    Count = group.Count()
                }).ToListAsync();

            // 2. Số lượng công việc theo công ty
            var jobsByCompany = await _context.Jobs
                .Include(j => j.Company)
                .GroupBy(j => j.Company.CompanyName)
                .Select(group => new
                {
                    Company = group.Key ?? "Không xác định",
                    Count = group.Count()
                }).ToListAsync();

            // 4. Tổng số tài khoản có vai trò là Applicant
            var totalApplicants = await _context.Users
                .Where(u => u.RoleId == 1) // RoleId = 1 là Applicant
                .CountAsync();

            // 5. Tổng số công ty
            var totalCompanies = await _context.Companies.CountAsync();

            // Truyền dữ liệu qua ViewBag
            ViewBag.JobsByProfession = jobsByProfession;
            ViewBag.JobsByCompany = jobsByCompany;
            ViewBag.TotalApplicants = totalApplicants;
            ViewBag.TotalCompanies = totalCompanies;

            return View();
        }
    }
}
