using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using jobconnect.Models;
using Microsoft.AspNetCore.Hosting;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace jobconnect.Controllers
{
    public class UsersController : Controller
    {
        private readonly RecruitmentManagementContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public UsersController(RecruitmentManagementContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: Users/Login
        public IActionResult Login()
        {
            return View();
        }

        // POST: Users/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(Login model)
        {
            if (ModelState.IsValid)
            {
                var user = await _context.Users
                    .FirstOrDefaultAsync(u => u.Username == model.UserNameOrEmail || u.Email == model.UserNameOrEmail);

                // Kiểm tra xem người dùng có tồn tại hay không
                if (user == null || user.Password != model.Password) // Nếu không tồn tại hoặc mật khẩu không đúng
                {
                    ModelState.AddModelError(string.Empty, "Tài khoản/Email hoặc mật khẩu không đúng.");
                    return View(model);
                }
                // Lưu tên người dùng vào cookie
                CookieOptions option = new CookieOptions
                {
                    Expires = DateTimeOffset.Now.AddMinutes(30),
                    HttpOnly = true,
                    IsEssential = true
                };
                Response.Cookies.Append("Fullname", user.FullName, option); // hoặc user.Username nếu bạn muốn hiển thị tên đăng nhập
                Response.Cookies.Append("UserName", user.Username, option);
                Response.Cookies.Append("CompanyId", user.CompanyId.ToString(), option);
                Response.Cookies.Append("UserId", user.UserId.ToString(), option);
                // Kiểm tra vai trò của người dùng
                if (user.RoleId == 1) // Giả sử RoleId = 1 là Applicant
                {
                    return RedirectToAction("Index1", "Jobs"); // Chuyển hướng đến trang home1
                }
                else if (user.RoleId == 2) // Giả sử RoleId = 2 là Recruiter
                {
                    return RedirectToAction("Index3", "Jobs"); // Chuyển hướng đến trang home2
                }
                else if (user.RoleId == 3) // Giả sử RoleId = 3 là Admin
                {
                    return RedirectToAction("Index4", "Jobs");
                }
            }

            return View(model);
        }
        public IActionResult Logout()
        {
            // Xóa cookie chứa thông tin người dùng
            Response.Cookies.Delete("Fullname");
            Response.Cookies.Delete("CompanyId");
            Response.Cookies.Delete("UserId");
            Response.Cookies.Delete("UserName");

            // Chuyển hướng về trang đăng nhập
            return RedirectToAction("Login", "Users");
        }

        // GET: Users
        public async Task<IActionResult> Index(string searchEmail, string searchPhone, string searchCompany)
        {
            IQueryable<User> recruitmentManagementContext = _context.Users
                .Include(u => u.Company)
                .Include(u => u.Role)
                .Where(u => u.RoleId == 2); // Lọc user có RoleId là 2

            if (!string.IsNullOrEmpty(searchEmail))
            {
                recruitmentManagementContext = recruitmentManagementContext.Where(u => u.Email.Contains(searchEmail));
            }
            if (!string.IsNullOrEmpty(searchPhone))
            {
                recruitmentManagementContext = recruitmentManagementContext.Where(u => u.PhoneNumber.Contains(searchPhone));
            }
            if (!string.IsNullOrEmpty(searchCompany))
            {
                recruitmentManagementContext = recruitmentManagementContext.Where(u => u.Company.CompanyName.Contains(searchCompany));
            }
            return View(await recruitmentManagementContext.ToListAsync());
        }
        public async Task<IActionResult> Index3(string searchEmail, string searchPhone)
        {
            IQueryable<User> recruitmentManagementContext = _context.Users
                .Include(u => u.Company)
                .Include(u => u.Role)
                .Where(u => u.RoleId == 1);
            if (!string.IsNullOrEmpty(searchEmail))
            {
                recruitmentManagementContext = recruitmentManagementContext.Where(u => u.Email.Contains(searchEmail));
            }
            if (!string.IsNullOrEmpty(searchPhone))
            {
                recruitmentManagementContext = recruitmentManagementContext.Where(u => u.PhoneNumber.Contains(searchPhone));
            }
            return View(await recruitmentManagementContext.ToListAsync());
        }
        public async Task<IActionResult> Index1()
        {
            var userId = int.Parse(Request.Cookies["UserId"]);
            var recruitmentManagementContext = _context.Users
                                   .Where(app => app.UserId == userId)
                                   .Include(u => u.Company).Include(u => u.Role);
            return View(await recruitmentManagementContext.ToListAsync());
        }
        public async Task<IActionResult> Index2()
        {
            var userId = int.Parse(Request.Cookies["UserId"]);
            var recruitmentManagementContext = _context.Users
                                   .Where(app => app.UserId == userId)
                                   .Include(u => u.Company).Include(u => u.Role);
            return View(await recruitmentManagementContext.ToListAsync());
        }
        public async Task<IActionResult> Index10()
        {
            var recruitmentManagementContext = _context.Users.Include(u => u.Company).Include(u => u.Role);
            return View(await recruitmentManagementContext.ToListAsync());
        }
        // GET: Users/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users
                .Include(u => u.Company)
                .Include(u => u.Role)
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // GET: Users/Create
        public IActionResult Create()
        {
            ViewData["CompanyId"] = new SelectList(_context.Companies, "CompanyId", "CompanyName");

            // Lấy chỉ vai trò Applicant
            ViewData["RoleId"] = new SelectList(
                _context.Roles.Where(r => r.RoleName == "Applicant"),
                "RoleId",
                "RoleName"
            );

            return View();
        }

        // POST: Users/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserId,Username,Password,FullName,Email,DateOfBirth,PhoneNumber,IsActive,ImageFile,CompanyId")] User user) // Loại bỏ RoleId khỏi [Bind]
        {
            // Kiểm tra email có chứa ký tự @ không
            if (!user.Email.Contains("@"))
            {
                ModelState.AddModelError("Email", "Email đăng ký không hợp lệ");
            }

            if (ModelState.IsValid)
            {
                // Gán RoleId của Applicant trực tiếp
                var applicantRole = await _context.Roles.FirstOrDefaultAsync(r => r.RoleName == "Applicant");
                if (applicantRole != null)
                {
                    user.RoleId = applicantRole.RoleId;
                }

                // Xử lý upload hình ảnh
                if (user.ImageFile != null)
                {
                    string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images");
                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + user.ImageFile.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await user.ImageFile.CopyToAsync(fileStream);
                    }
                    user.AvatarUrl = uniqueFileName;
                }

                _context.Add(user);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Login));
            }

            ViewData["CompanyId"] = new SelectList(_context.Companies, "CompanyId", "CompanyName", user.CompanyId);
            return View(user);
        }



        public IActionResult Create1()
        {
            ViewData["CompanyId"] = new SelectList(_context.Companies, "CompanyId", "CompanyName");
            ViewData["RoleId"] = new SelectList(
                _context.Roles.Where(r => r.RoleName == "Recruiter"),
                "RoleId",
                "RoleName"
            );

            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create1([Bind("UserId,Username,Password,FullName,Email,DateOfBirth,PhoneNumber,IsActive,ImageFile,CompanyId")] User user)
        {
            if (!user.Email.Contains("@"))
            {
                ModelState.AddModelError("Email", "Email đăng ký không hợp lệ");
            }
            if (ModelState.IsValid)
            {
                var applicantRole = await _context.Roles.FirstOrDefaultAsync(r => r.RoleName == "Recruiter");
                if (applicantRole != null)
                {
                    user.RoleId = applicantRole.RoleId;
                }

                if (user.ImageFile != null)
                {
                    // Lấy đường dẫn thư mục để lưu hình ảnh
                    string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images");
                    // Tạo tên file duy nhất cho hình ảnh
                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + user.ImageFile.FileName;
                    // Tạo đường dẫn đầy đủ đến file
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    // Lưu file hình ảnh vào thư mục
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await user.ImageFile.CopyToAsync(fileStream);
                    }

                    // Lưu tên file vào thuộc tính ImageNews
                    user.AvatarUrl = uniqueFileName;
                }
                _context.Add(user);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Login));
            }
            ViewData["CompanyId"] = new SelectList(_context.Companies, "CompanyId", "CompanyId", user.CompanyId);
            ViewData["RoleId"] = new SelectList(_context.Roles, "RoleId", "RoleId", user.RoleId);
            return View(user);
        }
        // GET: Users/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            user.RoleId = 1;
            ViewData["CompanyId"] = new SelectList(_context.Companies, "CompanyId", "CompanyId", user.CompanyId);
            
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserId,Username,Password,FullName,Email,RoleId,DateOfBirth,PhoneNumber,IsActive,AvatarUrl,CompanyId")] User user, IFormFile AvatarFile)
        {
            if (id != user.UserId)
            {
                return NotFound();
            }

            // Đảm bảo RoleId của người dùng sẽ là 1
            user.RoleId = 1;

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
                        user.AvatarUrl = uniqueFileName;
                    }
                    else
                    {
                        // Nếu không có ảnh mới, giữ nguyên AvatarUrl hiện tại
                        var currentUser = await _context.Users.FindAsync(id);
                        user.AvatarUrl = currentUser.AvatarUrl; // Giữ nguyên avatar cũ
                    }

                    // Cập nhật thông tin người dùng
                    _context.Update(user);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(user.UserId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index1)); // Hoặc chuyển hướng đến trang chi tiết người dùng
            }

            // Nếu model không hợp lệ, hiển thị lại form chỉnh sửa
            ViewData["CompanyId"] = new SelectList(_context.Companies, "CompanyId", "CompanyName", user.CompanyId);
            ViewData["RoleId"] = new SelectList(_context.Roles, "RoleId", "RoleName", user.RoleId);
            return View(user);
        }




        // GET: Users/Edit/5
        public async Task<IActionResult> Edit1(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            user.RoleId = 2;
            ViewData["CompanyId"] = new SelectList(_context.Companies, "CompanyId", "CompanyId", user.CompanyId);
            ViewData["RoleId"] = new SelectList(_context.Roles, "RoleId", "RoleId", user.RoleId);
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit1(int id, [Bind("UserId,Username,Password,FullName,Email,RoleId,DateOfBirth,PhoneNumber,IsActive,AvatarUrl,CompanyId")] User user, IFormFile AvatarFile)
        {
            if (id != user.UserId)
            {
                return NotFound();
            }

            // Đảm bảo RoleId của người dùng sẽ là 2
            user.RoleId = 2;

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
                        user.AvatarUrl = uniqueFileName;
                    }
                    else
                    {
                        // Nếu không có ảnh mới, giữ nguyên AvatarUrl hiện tại
                        var currentUser = await _context.Users.FindAsync(id);
                        user.AvatarUrl = currentUser.AvatarUrl; // Giữ nguyên avatar cũ
                    }

                    // Cập nhật thông tin người dùng
                    _context.Update(user);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(user.UserId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index2)); // Hoặc chuyển hướng đến trang chi tiết người dùng
            }

            // Nếu model không hợp lệ, hiển thị lại form chỉnh sửa
            ViewData["CompanyId"] = new SelectList(_context.Companies, "CompanyId", "CompanyName", user.CompanyId);
            ViewData["RoleId"] = new SelectList(_context.Roles, "RoleId", "RoleName", user.RoleId);
            return View(user);
        }

        public async Task<IActionResult> Edit2(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            user.RoleId = 2;
            ViewData["CompanyId"] = new SelectList(_context.Companies, "CompanyId", "CompanyId", user.CompanyId);
            ViewData["RoleId"] = new SelectList(_context.Roles, "RoleId", "RoleId", user.RoleId);
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit2(int id, [Bind("UserId,Username,Password,FullName,Email,RoleId,DateOfBirth,PhoneNumber,IsActive,AvatarUrl,CompanyId")] User user, IFormFile AvatarFile)
        {
            if (id != user.UserId)
            {
                return NotFound();
            }

            // Đảm bảo RoleId của người dùng sẽ là 2
            user.RoleId = 2;

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
                        user.AvatarUrl = uniqueFileName;
                    }
                    else
                    {
                        // Nếu không có ảnh mới, giữ nguyên AvatarUrl hiện tại
                        var currentUser = await _context.Users.FindAsync(id);
                        user.AvatarUrl = currentUser.AvatarUrl; // Giữ nguyên avatar cũ
                    }

                    // Cập nhật thông tin người dùng
                    _context.Update(user);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(user.UserId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index)); // Hoặc chuyển hướng đến trang chi tiết người dùng
            }

            // Nếu model không hợp lệ, hiển thị lại form chỉnh sửa
            ViewData["CompanyId"] = new SelectList(_context.Companies, "CompanyId", "CompanyName", user.CompanyId);
            ViewData["RoleId"] = new SelectList(_context.Roles, "RoleId", "RoleName", user.RoleId);
            return View(user);
        }

        public async Task<IActionResult> Edit3(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            user.RoleId = 1;
            ViewData["CompanyId"] = new SelectList(_context.Companies, "CompanyId", "CompanyId", user.CompanyId);

            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit3(int id, [Bind("UserId,Username,Password,FullName,Email,RoleId,DateOfBirth,PhoneNumber,IsActive,AvatarUrl,CompanyId")] User user, IFormFile AvatarFile)
        {
            if (id != user.UserId)
            {
                return NotFound();
            }

            // Đảm bảo RoleId của người dùng sẽ là 1
            user.RoleId = 1;

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
                        user.AvatarUrl = uniqueFileName;
                    }
                    else
                    {
                        // Nếu không có ảnh mới, giữ nguyên AvatarUrl hiện tại
                        var currentUser = await _context.Users.FindAsync(id);
                        user.AvatarUrl = currentUser.AvatarUrl; // Giữ nguyên avatar cũ
                    }

                    // Cập nhật thông tin người dùng
                    _context.Update(user);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(user.UserId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index3)); // Hoặc chuyển hướng đến trang chi tiết người dùng
            }

            // Nếu model không hợp lệ, hiển thị lại form chỉnh sửa
            ViewData["CompanyId"] = new SelectList(_context.Companies, "CompanyId", "CompanyName", user.CompanyId);
            ViewData["RoleId"] = new SelectList(_context.Roles, "RoleId", "RoleName", user.RoleId);
            return View(user);
        }
        // GET: Users/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users
                .Include(u => u.Company)
                .Include(u => u.Role)
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                _context.Users.Remove(user);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Login));
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.UserId == id);
        }

        public async Task<IActionResult> Delete1(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users
                .Include(u => u.Company)
                .Include(u => u.Role)
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete1")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed1(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                _context.Users.Remove(user);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Login));
        }

        public async Task<IActionResult> Delete2(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users
                .Include(u => u.Company)
                .Include(u => u.Role)
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete2")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed2(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                _context.Users.Remove(user);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete3(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users
                .Include(u => u.Company)
                .Include(u => u.Role)
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete3")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed3(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                _context.Users.Remove(user);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index3));
        }
    }
}
