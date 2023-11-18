using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Ocelot.Provider.Consul;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

static IConfiguration BuildConfiguration(IHostEnvironment env)
{
    var configurationBuilder = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("./Configurations/ocelot.json")
        .AddEnvironmentVariables();
    IConfigurationRoot Configuration = configurationBuilder.Build();
    return Configuration;
}


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//BuildConfiguration(builder.Environment);
builder.Services.AddOcelot(BuildConfiguration(builder.Environment)).AddConsul();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseOcelot().GetAwaiter().GetResult();

app.Run();
