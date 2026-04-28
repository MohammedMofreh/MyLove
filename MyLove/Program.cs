namespace MyLove
{
     public class Program
     {
          public static void Main(string[] args)
          {
               var builder = WebApplication.CreateBuilder(args);
               var port = Environment.GetEnvironmentVariable("PORT");

               if (!string.IsNullOrWhiteSpace(port))
               {
                    builder.WebHost.UseUrls($"http://0.0.0.0:{port}");
               }

               // Add services to the container.
               builder.Services.AddControllersWithViews();

               var app = builder.Build();

               // Configure the HTTP request pipeline.
               if (!app.Environment.IsDevelopment())
               {
                    app.UseExceptionHandler("/Home/Error");
               }
               app.UseRouting();

               app.UseAuthorization();

               app.MapStaticAssets();
               app.MapControllerRoute(
                   name: "default",
                   pattern: "{controller=Home}/{action=Index}/{id?}")
                   .WithStaticAssets();

               app.Run();
          }
     }
}
