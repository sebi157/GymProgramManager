using GPM;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddControllers();
    builder.Services.Configure<MongoDBSettings>(
        builder.Configuration.GetSection("MongoDBSettings"));
    builder.Services.AddSingleton<IMongoClient, MongoClient>(sp =>
    {
        var settings = sp.GetRequiredService<IOptions<MongoDBSettings>>().Value;
        return new MongoClient(settings.Connection_String);
    });
    builder.Services.AddScoped<IProgramService, ProgramService>();
    
}
var app = builder.Build();
{
    app.UseExceptionHandler("/error");
    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}

