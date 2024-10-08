namespace katchrApp
{
  public class Program
  {
    public static void Main(string[] args)
    {
      var builder = WebApplication.CreateBuilder(args);

      // Add services to the container.
      builder.Services.AddRazorPages();

      var app = builder.Build();

      // Configure the HTTP request pipeline.
      if (!app.Environment.IsDevelopment())
      {
        app.UseExceptionHandler("/Error");
      }

      app.UseStaticFiles();

      app.UseRouting();

      app.UseAuthorization();

      app.MapControllerRoute
        (
          name: "default",
          pattern: "{controller=Index}/{action=Index}/{id?}"
        );

      app.Run();
    }
  }
}
