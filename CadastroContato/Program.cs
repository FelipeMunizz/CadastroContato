using CadastroContato.Data;
using CadastroContato.Helper;
using CadastroContato.Repositorios;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//builder.Services.AddDbContext<ContatoContext>
//  (options => options.UsePostGreSQL
//("Data Source=tcp:cadastrocontatodbserver.database.windows.net,1433;Initial Catalog=CadastroContato_db;User Id=femuniz;Password=5Alc1cha@"));

builder.Services.AddEntityFrameworkNpgsql()
    .AddDbContext<ContatoContext>(options => 
    options.UseNpgsql("Host=ec2-3-222-74-92.compute-1.amazonaws.com;Pooling=true;Database=d1vjginj78nsuf;User Id=smvrclydjybdal;Password=74cd97d437609ac4e86fd383c5ce271ee34cf8b27f5252d67c3a85687b7bae71;"));

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

builder.Services.AddScoped<IContatoRepositorio, ContatoRepositorio>();
builder.Services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
builder.Services.AddScoped<ISessao, Sessao>();
builder.Services.AddScoped<IEmail, Email>();
builder.Services.AddSession(o =>
{
    o.Cookie.HttpOnly = true;
    o.Cookie.IsEssential = true;
});
var app = builder.Build();

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

app.UseAuthorization();

app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Index}/{id?}");

app.Run();
