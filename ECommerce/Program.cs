using Microsoft.EntityFrameworkCore;
using ECommerceContextt.Infra.Domain;
using System.Reflection;
using ECommerce.Infra.Contract;
using ECommerce.Infra.Repository;
using ECommerce.Core.Contract;
using ECommerce.Core.Services;
using FluentValidation.AspNetCore;
using Serilog;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;
using ECommerceContextt.Infra.Domain.Entities;
using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;
//using ECommerce.Serilog;
//using ECommerce.Serilog;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<ECommerceContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ECommerce"),
    dbOpt => dbOpt.MigrationsAssembly(Assembly.GetExecutingAssembly().GetName().Name)));

builder.Services.AddControllers().AddFluentValidation(c => c.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly()));



// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IUser, UserRepo>();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IProduct, ProductRepo>();
builder.Services.AddTransient<IProductService, ProductService>();
builder.Services.AddTransient<IProCategoriesService, ProCategoriesService>();
builder.Services.AddTransient<IProductCategories, ProductCategoriesRepo>();
builder.Services.AddTransient<IOrder,OrderRepo>();
builder.Services.AddTransient<IOrderService, OrderServices>();
builder.Services.AddTransient<IImage, ImageRepo>();
builder.Services.AddTransient<IImageService, ImageServices>();





//builder.Services.AddSwaggerGen(opt =>
//{
//    var securityDefinition = new OpenApiSecurityScheme
//    {
//        Type = SecuritySchemeType.Http,
//        In = ParameterLocation.Header,
//        Name = HeaderNames.Authorization,
//        Scheme = JwtBearerDefaults.AuthenticationScheme
//    };
//    opt.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme, securityDefinition);
//    opt.AddSecurityRequirement(new OpenApiSecurityRequirement
//    {
//        {securityDefinition, Array.Empty<string>()}
//    });

//    opt.OperationFilter<AuthResponsesOperationFilter>();
//});
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
       Description = "Standard Authorization header using the Bearer scheme(\"bearer {token}\")",
       In=ParameterLocation.Header,
       Name="Authorization",
       Type=SecuritySchemeType.ApiKey
    });
    options.OperationFilter<SecurityRequirementsOperationFilter>();
});

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8
            .GetBytes(builder.Configuration.GetSection("AppSettings:Key").Value)),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });
static IEdmModel GetEdmModel()            //OData
{
    ODataConventionModelBuilder builder = new();
    builder.EntitySet<Product>("Product");
    return builder.GetEdmModel();
}
builder.Services.AddControllers().AddOData(opt => opt.AddRouteComponents("v1", GetEdmModel()).Filter().Select().Expand().OrderBy().Count());
builder.Services.AddSwaggerGen(c =>
{
    //c.SwaggerDoc("v1", new() { Title = "ODataTutorial", Version = "v1" });
});
//ECommerce.Serilog.Serilog.InitializerLoggers(builder.Configuration);

string Conn = builder.Configuration.GetConnectionString("ECommerce");
string tableName = "Logs";
//var log = new LoggerConfiguration()
//    .WriteTo.MSSqlServer(
//        connectionString: Conn,
//        tableNam
//      //  sinkOptions: sinkOpts,
//     //   columnOptions: columnOpts
//    ).CreateLogger();

var log = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .WriteTo.MSSqlServer(Conn, tableName)
     .CreateLogger();



builder.Logging.AddSerilog(log);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

//builder.Logging.AddSerilog(); 
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
//app.UseMiddleware<Middleware>();


app.MapControllers();

app.Run();

