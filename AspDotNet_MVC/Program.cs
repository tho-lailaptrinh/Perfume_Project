using AspDotNet_MVC.IService;
using AspDotNet_MVC.Service;
using Infrastructure.IRepositorys;
using Infrastructure.Repositorys;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
//builder.Services.AddDbContext<MyDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddTransient<IDanhMucSPService, DanhMucSPService>();

builder.Services.AddTransient<ISanPhamRepo, SanPhamRepo>();
builder.Services.AddTransient<IUserRepo, UserRepo>();
builder.Services.AddTransient<IGioHangRepo, GioHangRepo>();
builder.Services.AddTransient<IGioHangChiTietRepo, GioHangChiTietRepo>();
builder.Services.AddTransient<IDanhMucSPRepo, DanhMucSPRepo>();
builder.Services.AddTransient<IHoaDonChiTietRepo, HoaDonChiTietRepo>();

//builder.Services.AddScoped<ISanPhamRepo, SanPhamRepo>();
builder.Services.AddSession();

//builder.Services.AddAutoMapper(x => x.AddProfile(new MappingConfigProfile()));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseSession();

app.UseStaticFiles();
app.UseRouting();

app.UseAuthorization();

//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=User}/{action=Login}");
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "home",
        pattern: "home",
        defaults: new { controller = "User", action = "Welcome" });

    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=User}/{action=Login}");
});
app.Run();
