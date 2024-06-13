using API.IRepositorys;
using API.Repositorys;
using Infrastructure.Models.Data;
using Microsoft.EntityFrameworkCore;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddDbContext<MyDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

        builder.Services.AddControllers();

        builder.Services.AddTransient<IDanhMucSPRepo, DanhMucSPRepo>();
        builder.Services.AddTransient<ISanPhamRepo, SanPhamRepo>();
        builder.Services.AddTransient<IUserRepo, UserRepo>();
        builder.Services.AddTransient<IGioHangRepo, GioHangRepo>();
        builder.Services.AddTransient<IGioHangChiTietRepo, GioHangChiTietRepo>();
        builder.Services.AddTransient<IHoaDonChiTietRepo, HoaDonChiTietRepo>();

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}