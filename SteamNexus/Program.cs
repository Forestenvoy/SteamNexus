using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using SteamNexus;
using SteamNexus.Data;
using SteamNexus.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

//Add Identity
builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();

// DataBase Connection String
var SteamNexusConnectionString = builder.Configuration.GetConnectionString("SteamNexus");
// Add SteamNexusDbContext
builder.Services.AddDbContext<SteamNexusDbContext>(options => options.UseSqlServer(SteamNexusConnectionString));

// Add CoolPCWebScrabing Service
builder.Services.AddTransient<CoolPCWebScraping>();

builder.Services.AddControllersWithViews();

//���U���ҡB�K�X�W�h��T
builder.Services.Configure<IdentityOptions>(options => { //�o�Ө禡�]�w�F�����ѧO�ﶵ�C
    options.Password.RequireDigit = true; //�K�X�O�_�ݭn�]�t�Ʀr�C
    options.Password.RequireLowercase = true; //�K�X�O�_�ݭn�]�t�p�g�r���C
    options.Password.RequireNonAlphanumeric = true; //�K�X�O�_�ݭn�]�t�D�r���μƦr���S��r���C
    options.Password.RequireUppercase = true; //�K�X�O�_�ݭn�]�t�j�g�r���C
    options.Password.RequiredLength = 8; //�̤֪��K�X���סC
    options.Password.RequiredUniqueChars = 1; //�K�X�������ƪ��Ʀr�C

    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5); //��w�Τ᪺�w�]�ɶ��C
    options.Lockout.MaxFailedAccessAttempts = 3; //�Τ᤹�\���̤j�n�J���Ѧ��ơC
    options.Lockout.AllowedForNewUsers = true; //�O�_���\�s�Τ�Q��w�C

    options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+"; //�K�X�]�w�r��
    options.User.RequireUniqueEmail = true; //Email���ҡA�ߤ@��(���i����)


    options.SignIn.RequireConfirmedEmail = true; //�ϥΪ̬O�_�ݭn�T�{�q�l�l��a�}��~��n�J�A�ݭn���ҹq�l�l��q�L��~����ϥΡC
});

builder.Services.ConfigureApplicationCookie(options => { //�o�Ө禡�]�w�F���ε{�� Cookie �������ﶵ�C
    options.Cookie.HttpOnly = true; //Cookie �O�_�Ȩ� HTTP �s���C
    options.Cookie.SecurePolicy = CookieSecurePolicy.Always; //Cookie �O�_�n�D�l�׳z�L�w���s�u (HTTPS) �ǿ�C
    options.ExpireTimeSpan = TimeSpan.FromMinutes(5); //Cookie ���w�ɮɶ��C
    options.LoginPath = "/Identity/Account/Login"; //�n�J���������|�C
    options.AccessDeniedPath = "/Identity/Account/AccessDenied"; //�s���Q�ڵ��ɾɦV���������|�C
    options.SlidingExpiration = true; //�O�_�ҥηưʹL���ɶ��C
});

//Email 
builder.Services.AddTransient<IEmailSender, EmailSendercs>();
builder.Services.AddControllersWithViews();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Administrator Route Setting
app.MapControllerRoute(
    name: "Area",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

// default Route Setting
app.MapControllerRoute(
    name: "Default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();
