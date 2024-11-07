using Asp.Net_MvcWeb_Pj3.Aptech.Models; // Replace 'YourNamespace' with the actual namespace where DataContext is defined
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Cho phép cập nhật lại trang web nếu tệp *.cshtml bị sửa nội dung
builder.Services.AddRazorPages().AddRazorRuntimeCompilation();

// Cấu hình kết nối SQL Azure
builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Thêm dịch vụ phiên
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.UseSession(); // Sử dụng middleware phiên

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=AdminPatient}/{action=Index}/{id?}");

app.Run();