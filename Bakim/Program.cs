using Autofac.Extensions.DependencyInjection;
using Autofac;
using Bakim.Business.DependencyResolvers.Autofac;
using Bakim.Core.DependencyResolvers;
using Bakim.Core.Extensions.ServiceCollectionExtensions;
using Bakim.Core.Utilities.IoC;
using Bakim.Dataaccess.Concrete.Contexts;
using Bakim.Entity;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddMvc().AddNewtonsoftJson(options =>
    options.SerializerSettings.ContractResolver = new DefaultContractResolver()
);

builder.Services.AddRazorPages();
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory()).ConfigureContainer<ContainerBuilder>(builder =>
{
    builder.RegisterModule(new AutofacBusinessModule());
});

builder.Services.AddDependencyResolvers(new ICoreModule[]
{
    new CoreModule()
});
//builder.Services.AddSingleton<DatabaseSubscription<Call>>();
builder.Services.AddSignalR();
builder.Services.AddCors();
builder.Services.AddDbContext<ApplicationDbContext>();
builder.Services.AddIdentity<ApplicationUser, IdentityRole>(x =>
{
    x.Password.RequireNonAlphanumeric = false;
    x.Password.RequiredLength = 5;
    x.Password.RequireLowercase = false;
    x.Password.RequireDigit = false;
    x.Password.RequireUppercase = false;
    x.User.RequireUniqueEmail = true;

}).AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/giris-yap";
    options.AccessDeniedPath = "/erisim-reddedildi";
    options.LogoutPath = "/cikis-yap";
    options.Cookie.Name = "auth_cookie";
    options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
    options.ReturnUrlParameter = CookieAuthenticationDefaults.ReturnUrlParameter;
    options.Cookie.HttpOnly = true;

});
builder.Services.AddControllersWithViews();
builder.Services.AddMvc().AddNewtonsoftJson(options =>
    options.SerializerSettings.ContractResolver = new DefaultContractResolver()
);


var app = builder.Build();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
     endpoints.MapControllerRoute( 
        name: "SatinAlimTalepleri",
        pattern: "SatinAlimTalepleri",
        defaults: new { controller = "Talep", action = "SatinAlimTalepleri" }
        );
     endpoints.MapControllerRoute( 
        name: "TalepOlustur",
        pattern: "TalepOlustur",
        defaults: new { controller = "Talep", action = "TalepOlustur" }
        );
     endpoints.MapControllerRoute( 
        name: "VarlikTanimlama",
        pattern: "VarlikTanimlama",
        defaults: new { controller = "Describing", action = "Varlik" }
        );
    endpoints.MapControllerRoute( 
        name: "MakineDetay",
        pattern: "MakineDetay",
        defaults: new { controller = "Varlik", action = "MakineDetay" }
        );
    endpoints.MapControllerRoute( 
        name: "VarlikDuzenle",
        pattern: "VarlikDuzenle",
        defaults: new { controller = "Varlik", action = "EditVarlik" }
        );
    endpoints.MapControllerRoute( 
        name: "StokTanimlama",
        pattern: "StokTanimlama",
        defaults: new { controller = "Describing", action = "Stock" }
        );
     endpoints.MapControllerRoute( 
        name: "StokKategori",
        pattern: "StokKategori",
        defaults: new { controller = "Describing", action = "StokKategori" }
        );
    endpoints.MapControllerRoute( 
        name: "MakineListe",
        pattern: "MakineListe",
        defaults: new { controller = "Varlik", action = "MakineListe" }
        );
    endpoints.MapControllerRoute( 
        name: "DetayGrup",
        pattern: "DetayGrup",
        defaults: new { controller = "Describing", action = "DetayGroup" }
        );
     endpoints.MapControllerRoute(
        name: "rutinbakim/genelbakimplanla",
        pattern: "rutinbakim/genelbakimplanla",
        defaults: new { controller = "RoutineBakim", action = "GenelBakimP" }
     );
     endpoints.MapControllerRoute(
        name: "rutinbakim/makinebakimplanla",
        pattern: "rutinbakim/makinebakimplanla",
        defaults: new { controller = "RoutineBakim", action = "MakineBakimP" }
     );
     endpoints.MapControllerRoute(
        name: "anasayfa",
        pattern: "anasayfa",
        defaults: new { controller = "Home", action = "Index" }
     );
    endpoints.MapControllerRoute(
        name: "rutinbakim/bakimplanla",
        pattern: "rutinbakim/bakimplanla",
        defaults: new { controller = "RoutineBakim", action = "BakimPlanla" }
     );
    endpoints.MapControllerRoute(
       name: "rutinbakim/Bakimlistele",
       pattern: "rutinbakim/Bakimlistele",
       defaults: new { controller = "RoutineBakim", action = "BakimListele" }
    );
    endpoints.MapControllerRoute(
        name: "raporla",
        pattern: "raporla",
        defaults: new { controller = "RoutineBakim", action = "MachineDetay" }
     );
    endpoints.MapControllerRoute(
       name: "bakim",
       pattern: "bakim",
       defaults: new { controller = "bakim", action = "Index" }
    );
    endpoints.MapControllerRoute(
        name: "kullan�c�lar",
        pattern: "kullan�c�lar",
        defaults: new { controller = "Users", action = "Index" }
    );
    endpoints.MapControllerRoute(
        name: "birimler",
        pattern: "birimler",
        defaults: new { controller = "Sections", action = "Index" }
    );
    endpoints.MapControllerRoute(
        name: "resimguncelle",
        pattern: "resimguncelle",
        defaults: new { controller = "Account", action = "UploadImage" }
    );
    endpoints.MapControllerRoute(
        name: "hesap",
        pattern: "hesap",
        defaults: new { controller = "Account", action = "Index" }
    );
    endpoints.MapControllerRoute(
        name: "sifredegistir",
        pattern: "hesap/sifredegistir",
        defaults: new { controller = "Account", action = "SifreDegistir" }
    );
    endpoints.MapControllerRoute(
        name: "isemirleri",
        pattern: "worktasks/is-emirleri",
        defaults: new { controller = "Worktasks", action = "IsEmirleri" }
    );
    endpoints.MapControllerRoute(
        name: "makine",
        pattern: "bakim/makine-cagrilari",
        defaults: new { controller = "bakim", action = "MachineTickets" }
    );
    endpoints.MapControllerRoute(
       name: "duyurular",
       pattern: "duyurular",
       defaults: new { controller = "UserAnnouncements", action = "Index" }
       );
    endpoints.MapControllerRoute(
       name: "erisim-reddedildi",
       pattern: "erisim-reddedildi",
       defaults: new { controller = "auth", action = "AccessDenied" }
       );
    endpoints.MapControllerRoute(
       name: "giris-yap",
       pattern: "giris-yap",
       defaults: new { controller = "auth", action = "login" }
       );
    endpoints.MapControllerRoute(
       name: "yeni-kullanici-kayit",
       pattern: "yeni-kullanici-kayit",
       defaults: new { controller = "auth", action = "register" }
       );
    endpoints.MapControllerRoute(
       name: "cikis-yap",
       pattern: "cikis-yap",
       defaults: new { controller = "auth", action = "logout" }
       );
    endpoints.MapControllerRoute(
        name: "anasayfa",
        pattern: "anasayfa",
        defaults: new { controller = "Home", action = "Index" }
        );
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}"
        );

});




app.Run();
