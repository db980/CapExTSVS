
using LinqToDB;
using Microsoft.EntityFrameworkCore;








var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
//builder.Services.AddRazorPages();
builder.Services.AddHttpContextAccessor();
// Add distributed memory cache for session
builder.Services.AddDistributedMemoryCache();

// Configure session options
builder.Services.AddSession(options =>
{
	options.IdleTimeout = TimeSpan.FromMinutes(1); // Set session timeout
});



var app = builder.Build();




//builder.Services.addl
//IConfiguration configuration = new ConfigurationBuilder()
//		.SetBasePath(Directory.GetCurrentDirectory())
//		.AddJsonFile("appsettings.json")
//		.Build();

//IServiceCollection serviceCollection = builder.Services.AddDbContext<CapExTSDB>(options =>
//	options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")))


//object value = builder.Services.AddLinqToDbContext<AppDataConnection>(options =>
// {
//     options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
//     // Additional options like mappings, interceptors, etc.
// });



// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseSession();
app.UseAuthorization();

//app.MapRazorPages();
//app.MapRazorPages();



app.MapControllerRoute( //MapControllerRoute
    name: "default",
   pattern: "{controller=Login}/{action=index}/{id?}");
//pattern: "{controller=Administrator}/{action=UserRights}/{id?}");
app.Run();
// pattern: "{controller=Login}/{action=index}/{id?}"); ///{id?}