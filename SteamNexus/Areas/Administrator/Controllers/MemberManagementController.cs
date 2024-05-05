﻿using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SteamNexus.Data;
using SteamNexus.Models;
using SteamNexus.ViewModels.Game;
using System.ComponentModel.DataAnnotations;
using static SteamNexus.Areas.Administrator.Controllers.MemberManagementController;
using static System.Net.Mime.MediaTypeNames;

namespace SteamNexus.Areas.Administrator.Controllers
{
    [Area("Administrator")]

    public class MemberManagementController : Controller
    {
        private SteamNexusDbContext _application;
        private readonly IWebHostEnvironment _webHost;  //上傳圖片使用

        public MemberManagementController(SteamNexusDbContext application, IWebHostEnvironment webHostEnvironment)
        {
            _application = application;
            _webHost = webHostEnvironment;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult MemberManagement()
        {
            return PartialView("_MemberManagementPartial");
        }

        #region JsonUser資料
        public IActionResult MemberData()
        {
            var result = _application.Users.Select(result => new
            {
                result.Name,
                result.Email,
                Gender = result.Gender ? "男" : "女",
                birthday = result.Birthday.ToString(),
                result.Phone,
                result.Photo,

            });
            return Json(result);
        }
        #endregion


        #region JsonRolesName
        public JsonResult RolesData()
        {
            var result = _application.Roles.Select(result => new
            {
                result.RoleId,
                result.RoleName,
            });
            return Json(result);

        }
        #endregion


        #region Json結合User and Roles
        public IActionResult GetUsersWithRoles()
        {
            var result = _application.Users
                .Join(_application.Roles, u => u.RoleId, r => r.RoleId,
                (u, r) => new
                {
                    UserId = u.UserId,
                    Name = u.Name,
                    Email = u.Email,
                    Gender = u.Gender ? "男" : "女",
                    Birthday = u.Birthday.ToString(),
                    Phone = u.Phone,
                    Photo = u.Photo,
                    RoleName = r.RoleName,
                });

            return Json(result);
        }
        #endregion


        #region 會員資料刪除
        [HttpPost]
        public async Task<IActionResult> DeleteUser(int id)
        {
            try
            {
                var user = await _application.Users.FindAsync(id);
                if (user == null)
                {
                    // 加入調試信息，確認ID值和數據庫內是否匹配
                    return Json(new { success = false, message = "用戶未找到，ID: " + id });
                }

                _application.Users.Remove(user);
                await _application.SaveChangesAsync();
                return Json(new { success = true, message = "用戶已刪除" });
            }
            catch (Exception ex)
            {
                //記錄錯誤
                return Json(new { success = false, message = ex.Message });
            }
        }
        #endregion

        #region EditViewModel
        public partial class EditUserViewModel
        {
            [Key]
            [Required]
            public int UserId { get; set; }

            [Required]
            public int RoleId { get; set; }

            [Required]
            public string RoleName { get; set; }

            public virtual Role Role { get; set; }

            [Required]
            [MaxLength(100)]
            [EmailAddress]
            public string Email { get; set; }

            [Required]
            [MaxLength(20)]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }

            [Required]
            [MaxLength(50)]
            public string Name { get; set; }

            public bool Gender { get; set; } = true;

            #nullable enable
            [MaxLength(10)]
            [RegularExpression(@"^09\d{8}$", ErrorMessage = "手機號碼輸入錯誤。請依照範例輸入09xxxxxxxx")]
            [Required(ErrorMessage = "請輸入手機號碼")]
            public string? Phone { get; set; }

            [Display(Name = "生日")]
            [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)] // 指定日期的顯示格式
            public DateTime? Birthday { get; set; }

            [MaxLength(200)]
            public IFormFile? Photo { get; set; }

        }

        #endregion

        //[HttpPost]
        //public async Task<ActionResult> EditUser([FromForm] EditUserViewModel data)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        // 使用 Join 查找特定用戶並更新其角色
        //        var user = (from u in _application.Users
        //                    join r in _application.Roles on u.RoleId equals r.RoleId
        //                    where u.UserId == data.UserId
        //                    select new { User = u, Role = r }).FirstOrDefault();

        //        if (user != null)
        //        {
        //            user.User.Name = data.Name;
        //            user.User.Email = data.Email;
        //            user.User.Phone = data.Phone;
        //            user.User.Gender = data.Gender;
        //            user.User.Birthday = data.Birthday;

        //            // 查找新的角色ID
        //            var newRole = _application.Roles.FirstOrDefault(r => r.RoleName == data.RoleName);
        //            if (newRole != null)
        //            {
        //                user.User.RoleId = newRole.RoleId;  // 更新角色ID
        //            }

        //            // 處理檔案上傳
        //            if (data.Photo != null && data.Photo.Length > 0)
        //            {
        //                string filename = Guid.NewGuid().ToString() + Path.GetExtension(data.Photo.FileName);
        //                string uploadfolder = Path.Combine(_webHost.WebRootPath, "images/headshots");
        //                string filepath = Path.Combine(uploadfolder, filename);

        //                using (var fileStream = new FileStream(filepath, FileMode.Create))
        //                {
        //                    await data.Photo.CopyToAsync(fileStream);
        //                }

        //                user.User.Photo = filename;
        //            }

        //            await _application.SaveChangesAsync();
        //            return RedirectToAction("SuccessPage");
        //        }
        //    }
        //    return View(data);
        //}

        [HttpPost]
        public async Task<ActionResult> EditUser([FromForm] EditUserViewModel data)
        {
            if (ModelState.IsValid)
            {
                var user = await _application.Users
                            .Include(u => u.Role)  // 使用 Include 載入相關的角色資料
                            .FirstOrDefaultAsync(u => u.UserId == data.UserId);

                if (user == null)
                {
                    return NotFound($"無法找到ID為 {data.UserId} 的用戶。");
                }

                user.Name = data.Name;
                user.Email = data.Email;
                user.Phone = data.Phone;
                user.Gender = data.Gender;
                user.Birthday = data.Birthday;

                // 查找新的角色ID
                var newRole = await _application.Roles.FirstOrDefaultAsync(r => r.RoleName == data.RoleName);
                if (newRole != null && newRole.RoleId != user.RoleId)
                {
                    user.RoleId = newRole.RoleId;  // 只在角色有變化時更新角色ID
                }

                // 處理檔案上傳
                if (data.Photo != null && data.Photo.Length > 0)
                {
                    // 刪除舊的圖片
                    if (!string.IsNullOrEmpty(user.Photo))
                    {
                        var oldFilePath = Path.Combine(_webHost.WebRootPath, "images/headshots", user.Photo);
                        if (System.IO.File.Exists(oldFilePath))
                        {
                            System.IO.File.Delete(oldFilePath);
                        }
                    }

                    // 儲存新的圖片
                    string filename = Guid.NewGuid().ToString() + Path.GetExtension(data.Photo.FileName);
                    string uploadfolder = Path.Combine(_webHost.WebRootPath, "images/headshots");
                    string filepath = Path.Combine(uploadfolder, filename);

                    using (var fileStream = new FileStream(filepath, FileMode.Create))
                    {
                        await data.Photo.CopyToAsync(fileStream);
                    }

                    user.Photo = filename;
                }

                await _application.SaveChangesAsync();
                return RedirectToAction("SuccessPage");  // 或其他適當的成功頁面
            }
            return View(data);  // 返回表單與驗證錯誤
        }



        //權限
        public IActionResult GetRoles()
        {
            return PartialView("_createRolePartial");
        }


        #region 權限ViewModels
        public class createRoleViewModels
        {
            [Required]
            [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "只能夠輸入英文")]
            public string RoleName { get; set; }
        }
        #endregion


        #region 新增權限
        [HttpPost]
        public async Task<ActionResult> CreateRole([FromForm] createRoleViewModels data)
        {
            if (!ModelState.IsValid)
            {
                return PartialView("_CreateRolePartial", data);
            }

            var newRole = new Role { RoleName = data.RoleName };
            _application.Roles.Add(newRole);
            await _application.SaveChangesAsync();

            return Json(new { success = true, message = "角色新增成功" });
        }
        #endregion


        [HttpPost]
        public async Task<IActionResult> DeleteRole(int id)
        {
            try
            {
                var role = await _application.Roles.FindAsync(id);
                if (role == null)
                {
                    // 加入調試信息，確認ID值和數據庫內是否匹配
                    return Json(new { success = false, message = "角色未找到，ID: " + id });
                }

                _application.Roles.Remove(role);
                await _application.SaveChangesAsync();
                return Json(new { success = true, message = "角色已刪除" });
            }
            catch (Exception ex)
            {
                //記錄錯誤
                return Json(new { success = false, message = ex.Message });
            }
        }

    }
}
