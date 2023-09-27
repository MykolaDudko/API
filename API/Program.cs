
using API.Helpers;
using ClassLibrary.Context;
using ClassLibrary.Extensions;
using ClassLibrary.Middlewares;
using ClassLibrary.Profiles;
using ClassLibrary.Providers;
using ClassLibrary.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Web;
using Microsoft.OpenApi.Models;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);
string connectionStringName = "Default";

if (args.Any(x => x.ToLower().Contains("migratedb")))
    connectionStringName = "Migrate";

builder.Host.ConfigureAppConfiguration((hostingContext, config) =>
    config.AddJsonFile("./config/result/appconfig.json",
                       optional: true,
                       reloadOnChange: true));


//builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
//    .AddMicrosoftIdentityWebApi(builder.Configuration.GetSection("AzureAd"));
//builder.Services.AddAuthorization(options =>
//{
//    options.AddPolicy(PolicyConstants.RequireEditRole, policy => policy.RequireRole("RequireViewRole"));
//    options.AddPolicy(PolicyConstants.RequireViewRole, policy => policy.RequireRole("RequireViewRole", "RequireEdit"));

//    options.FallbackPolicy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
//});


// Add services to the container.
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.Add(new API.Converters.DatetimeConverter());
    options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
    options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault;
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter(JsonNamingPolicy.CamelCase));
    options.JsonSerializerOptions.Converters.Add(new NetTopologySuite.IO.Converters.GeoJsonConverterFactory());


});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var connectionString = builder.Configuration.GetConnectionString(connectionStringName);
builder.Services.AddDbContext<PatramDbContext>(options =>
    options.UseMySql(connectionString, new MySqlServerVersion(ServerVersion.AutoDetect(connectionString)), x => x.UseNetTopologySuite()));

builder.Services.Scan(scan =>
        scan.FromAssembliesOf(typeof(BaseRepository<>)).AddClasses(classSelector =>
        classSelector.AssignableTo(typeof(BaseRepository<>)))
        .AddClasses(classSelector => classSelector.AssignableTo(typeof(IMessageProducer)))
        .AsImplementedInterfaces()
       .AddClasses(classSelector => classSelector.InNamespaceOf(typeof(СustomerPickUpBranchManager)))
       .AsSelf().WithScopedLifetime()
       .AddClasses(classSelector => classSelector.InNamespaceOf(typeof(CarrierBranchProviderService)))
       .AsSelf().WithSingletonLifetime());

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
builder.Services.AddDateOnlyTimeOnlyStringConverters();
builder.Services.AddAutoMapper(new Assembly[] { typeof(CarrierBranchProfile).Assembly, typeof(BaseCarrierBranchProvider).Assembly });

builder.Services.AddMemoryCache();

builder.Services.AddSwaggerGen(opt =>
{
    var assemblyName = Assembly.GetExecutingAssembly();


    opt.SwaggerDoc("v1", new()
    {
        Title = "Product API",
        Version = "v1"
    });
});

builder.Services.AddHttpClient();
builder.Services.AddHttpClient<ICarrierBranchProvider, UpsPbhCarrierBranchProvider>("ups", client =>
{
    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", "MzQ3OkRCNHp2ZTdtcVBvNWlXSmFjczZGUk44dEgxMFkzVXg5RQ==");
});

builder.Services.AddSwaggerGen(options =>
{
    //options.AddSecurityDefinition("bearer", new OpenApiSecurityScheme
    //{
    //    Scheme = "bearer",
    //    BearerFormat = "JWT",
    //    In = ParameterLocation.Header,
    //    Name = "Authorization",
    //    Description = "Bearer Authentication with JWT Token",
    //    Type = SecuritySchemeType.Http
    //});
    //options.AddSecurityRequirement(new OpenApiSecurityRequirement
    //{
    //    {
    //        new OpenApiSecurityScheme
    //        {
    //            Reference = new OpenApiReference
    //            {
    //                Id = "bearer",
    //                Type = ReferenceType.SecurityScheme
    //            }
    //        },
    //        new List<string>()
    //    }
    //});
    options.UseDateOnlyTimeOnlyStringConverters();
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (args.Any(x => x.ToLower().Contains("useswagger")) || app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();
app.UseExceptionMiddleware();
app.MapControllers();

if (connectionStringName == "Migrate")
    app.MigrateDatabase();
else
    app.Run();
public partial class Program { }
