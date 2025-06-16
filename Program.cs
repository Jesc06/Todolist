using Todo_List_App._DbContext;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<TodoTable>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("todo")));
var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();


app.UseRouting();
app.UseAuthorization();


app.MapControllerRoute(
    name:"default",
    pattern: "{controller=Todo}/{action=TodoList}/{id?}"
);


app.Run();
