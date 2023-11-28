using arktiktest;
using Microsoft.OpenApi.Models;
using System.Reflection;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();//swagger
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
builder.Services.AddControllersWithViews();
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
