//var builder = WebApplication.CreateBuilder(args);

//// Add services to the container.

//builder.Services.AddControllers();
//// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

//var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

//app.UseHttpsRedirection();

//app.UseAuthorization();

//app.MapControllers();

//app.Run();

using WebApplication6;
using Supabase;

class Program
{
    public static void Main()
    {
        var builder = WebApplication.CreateBuilder();
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        string? url = builder.Configuration["SupabaseSetting.ApiUrl"];
        string? key = builder.Configuration.["SupabaseSetting.ApiKey"];
        var options = new Supabase.SupabaseOptions
        {
            AutoConnectRealtime = true,
        };

        SupaBaseContent.Client supabase = new SupaBaseContent().Client(url, key, options);
        SupaBaseContent supabaseContext = new();
        builder.Services.AddSingleton(supabase);
        builder.Services.AddSingleton(supabaseContext);

        var app = builder.Build();
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