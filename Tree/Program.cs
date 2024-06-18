using Microsoft.EntityFrameworkCore;
using Tree.Context;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<TreeContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddAutoMapper(typeof(Tree.Models.Attribute));
var app = builder.Build();

//builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
