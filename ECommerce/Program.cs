using Microsoft.EntityFrameworkCore;
using ECommerceContextt.Infra.Domain;
using System.Reflection;
using ECommerce.Infra.Contract;
using ECommerce.Infra.Repository;
using ECommerce.Core.Contract;
using ECommerce.Core.Services;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<ECommerceContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ECommerce"),
    dbOpt => dbOpt.MigrationsAssembly(Assembly.GetExecutingAssembly().GetName().Name)));
builder.Services.AddControllers();
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

app.Run();

