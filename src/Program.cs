using arktiktest;
using Microsoft.OpenApi.Models;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using FluentValidation;

var builder = WebApplication.CreateBuilder(args);
builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Services.AddEndpointsApiExplorer();//swagger
builder.Services.AddScoped<IValidator<MaterialDTO>, MaterialValidator>();//validator
builder.Services.AddScoped<IValidator<SellerDTO>, SellerValidator>();//validator
builder.Services.AddSwaggerGen(Options=>{
    Options.SwaggerDoc("v1",new OpenApiInfo{
        Version = "v1",
        Title = "API Биржы материалов",
        Description = @" RESTful API для управления товарами на 'Бирже материалов'. 
            Каждый товар представляет собой уникальный материал с названием и стоимостью, 
            а также информацию о продавце, который предлагает этот товар на бирже."
    });
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    Options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
}); 
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));//mediatr
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<DbMain>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
} 
app.UseStaticFiles();
app.UseRouting();
app.MapControllers();
app.Run();
