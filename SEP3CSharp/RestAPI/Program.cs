using System.Text;
using Application.DaoInterfaces;
using Application.Logic;
using Application.LogicInterfaces;
using EfcEmployeeDataAccess;
using EfcEmployeeDataAccess.DAOs;
using gRPC;
using gRPC.ServiceImplementations;
using gRPC.ServiceInterfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Shared.Auth;
using Shared.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DataContext>();
builder.Services.AddScoped<IEmployeeDao,EmployeeEfcDao>();

// gRPC Service Clients
AppContext.SetSwitch("System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", true);

Uri grpcUri = new Uri("http://localhost:9090");
builder.Services.AddGrpcClient<ProductGrpcService.ProductGrpcServiceClient>(o => {
    o.Address = grpcUri;
});
builder.Services.AddGrpcClient<OrderGrpcService.OrderGrpcServiceClient>(o => {
    o.Address = grpcUri;
});
builder.Services.AddGrpcClient<WarehouseGrpcService.WarehouseGrpcServiceClient>(o => {
    o.Address = grpcUri;
});
builder.Services.AddGrpcClient<WarehouseProductGrpcService.WarehouseProductGrpcServiceClient>(o => {
    o.Address = grpcUri;
});
builder.Services.AddGrpcClient<Ping.PingClient>(o => {
    o.Address = grpcUri;
});
builder.Services.AddGrpcClient<CustomersGrpcService.CustomersGrpcServiceClient>(o => {
    o.Address = grpcUri;
});

// gRPC Services
builder.Services.AddScoped<IPingService, PingService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IWarehouseService, WarehouseService>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IWarehouseProductService, WarehouseProductService>();

// Logic dependencies
builder.Services.AddScoped<IAuthLogic, AuthLogic>();
builder.Services.AddScoped<IPingLogic, PingLogic>();
builder.Services.AddScoped<IOrderLogic, OrderLogic>();
builder.Services.AddScoped<IProductLogic, ProductLogic>();
builder.Services.AddScoped<IWarehouseLogic, WarehouseLogic>();
builder.Services.AddScoped<ICustomerLogic, CustomerLogic>();
builder.Services.AddScoped<IWarehouseProductLogic, WarehouseProductLogic>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidAudience = builder.Configuration["Jwt:Audience"],
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
});

AuthorizationPolicies.AddPolicies(builder.Services);

var app = builder.Build();

app.UseCors(x => x
    .AllowAnyMethod()
    .AllowAnyHeader()
    .SetIsOriginAllowed(origin => true) // allow any origin
    .AllowCredentials());


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();