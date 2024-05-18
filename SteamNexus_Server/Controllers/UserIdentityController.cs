﻿using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SteamNexus_Server.Data;
using SteamNexus_Server.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Cors;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace SteamNexus_Server.Controllers;

//[Authorize //權限標籤
//[AllowAnonymous] //允許匿名登入

// 套用 CORS 策略
[EnableCors("AllowAny")]
[Route("api/[controller]")]
[ApiController]
public class UserIdentityController : ControllerBase
{
    private SteamNexusDbContext _application;

    //JWT引用
    public IConfiguration _configuration;

    public UserIdentityController(SteamNexusDbContext application,IConfiguration configuration)
    {
        _application = application;
        _configuration = configuration;
    }



    #region LonginViewModel
    public class LoginPost()
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
    #endregion


    #region LoninCookie
    [HttpPost("LoginCookie")]
    public async Task<IActionResult> Login([FromBody] LoginPost data)
    {
        var user = _application.Users.SingleOrDefault(a => a.Email == data.Email && a.Password == data.Password);

        if (user == null)
        {
            return Ok("帳號或密碼錯誤");
        }
        else
        {
            // 驗證成功
            var claims = new List<Claim>

        {   //取得資料
            new Claim(ClaimTypes.Name, user.Name),
            new Claim("FullName", user.Name),
            new Claim("UserId",user.UserId.ToString()),
            // new Claim(ClaimTypes.Role, "Admin")
        };

            //多個權限設定 for 新增使用者
            //var role = from r in _application.Roles where r.RoleId == user.UserId select r;

            //foreach (var temp in role)
            //{
            //    claims.Add(new Claim(ClaimTypes.Role, temp.RoleName));
            //}


            //var authProperties = new AuthenticationProperties
            //{
            //AllowRefresh = true, // 允許刷新身份驗證會話
            // Refreshing the authentication session should be allowed.

            //ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(10),   // 設置過期時間為 10 分鐘後
            // The time at which the authentication ticket expires. A 
            // value set here overrides the ExpireTimeSpan option of 
            // CookieAuthenticationOptions set with AddCookie.

            //IsPersistent = true,  //會話在多次請求中保持持久
            // Whether the authentication session is persisted across 
            // multiple requests. When used with cookies, controls
            // whether the cookie's lifetime is absolute (matching the
            // lifetime of the authentication ticket) or session-based.

            //IssuedUtc = DateTimeOffset.UtcNow,  //設置登入的時間
            // The time at which the authentication ticket was issued.

            //RedirectUri = "/Home/Index" //設置時間過期後重新導向 URI
            // The full path or absolute URI to be used as an http 
            // redirect response value.
            //};

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

            return Ok($"{user.Name}登入成功");
        }
    }
    #endregion


    #region Logout(cookie) for UserId
    //[HttpDelete("Logout")]
    //public async Task<IActionResult> Logout()
    //{
    //    // 取得目前已驗證的使用者
    //    var user = HttpContext.User;

    //    // 從身份驗證票證中取得使用者 ID，假設使用者 ID 存在於 "UserId" Claim 中
    //    var userIdClaim = user.Claims.FirstOrDefault(c => c.Type == "UserId");
    //    var userId = userIdClaim?.Value;

    //    await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

    //    // 回傳使用者 ID 已登出的訊息
    //    return Ok($"{userId}已登出");
    //}

    //[HttpGet("NoLogin")]
    //public IActionResult NoLogin()
    //{
    //    return Ok("未登入");
    //}
    #endregion


    #region(cookie) Logout for Name
    [HttpDelete("Logout")]
    public async Task<IActionResult> Logout()
    {
        // 取得目前已驗證的使用者
        var user = HttpContext.User;

        // 從身份驗證票證中取得 FullName，假設 FullName 存在於 "FullName" Claim 中
        var fullNameClaim = user.Claims.FirstOrDefault(c => c.Type == "FullName");
        var fullName = fullNameClaim?.Value;

        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

        // 回傳 FullName 已登出的訊息
        return Ok($"{fullName}已登出");
    }

    [HttpGet("NoLogin")]
    public IActionResult NoLogin()
    {
        return Ok("未登入");
    }
    #endregion


    #region noAccess
    [HttpGet("noAccess")]
    public IActionResult noAccess()
    {
        return Ok("沒有權限");
    }
    #endregion


    #region LoginJWT
    [HttpPost("JwtLogin")]
    public async Task<IActionResult> JwtLogin([FromBody] LoginPost data)
    {
        var user = _application.Users
                              .Include(u => u.Role) // 確保 Role 被包含在查詢結果中
                              .SingleOrDefault(a => a.Email == data.Email && a.Password == data.Password);

        if (user == null)
        {
            return BadRequest("帳號或密碼錯誤");
        }
        else
        {
            // 驗證成功
            var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
            //new Claim(JwtRegisteredClaimNames.Email, user.Email),
            new Claim(ClaimTypes.Name, user.Name),
            new Claim("FullName", user.Name),
            new Claim("UserId", user.UserId.ToString()),
            //new Claim("Roles", user.Role.RoleName),
            new Claim(ClaimTypes.Role, user.Role.RoleName)
        };

            // 如果使用者有多個角色，可以在這裡添加多個角色權限
            //var roles = from r in _application.UserRoles
            //            where r.UserId == user.UserId
            //            select r.Role.RoleName;

            //foreach (var roleName in roles)
            //{
            //    claims.Add(new Claim(ClaimTypes.Role, roleName));
            //}

            // Jwt 金鑰資訊
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                        issuer: _configuration["Jwt:Issuer"],
                        audience: _configuration["Jwt:Audience"],
                        claims: claims,
                        expires: DateTime.UtcNow.AddMinutes(10), // 登入過期時間
                        signingCredentials: signIn);

            //直接回傳結果
            //return Ok(new JwtSecurityTokenHandler().WriteToken(token));

            //先宣告再回傳結果
            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);
            return Ok(new { Token = tokenString });
        }
    }
    #endregion


    #region CheckUserRoles
    [HttpGet("CheckUserRoles")]
    public IActionResult CheckUserRoles()
    {
        var user = HttpContext.User;
        var roles = user.Claims.Where(c => c.Type == ClaimTypes.Role).Select(c => c.Value).ToList();
        var claims = user.Claims.Select(c => new { c.Type, c.Value }).ToList();
        return Ok(new { UserName = user.Identity.Name, Roles = roles, Claims = claims });
    }
    #endregion

}

