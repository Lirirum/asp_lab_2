
var builder = WebApplication.CreateBuilder();

builder.Services.AddTransient<CompanyService>();
builder.Services.AddTransient<InfoService>();

var app = builder.Build();

builder.Configuration.AddXmlFile("conf.xml").AddIniFile("conf.ini").AddJsonFile("conf.json");
builder.Configuration.AddJsonFile("info.json");

app.Map("/info", (IConfiguration appConfig) => $"First Name: {appConfig["FirstName"]}\nLast Name: {appConfig["LastName"]}\nAge: {appConfig["Age"]}");
app.Run(async context =>
{
    var companyService = context.RequestServices.GetService<CompanyService>();
    var infoService = context.RequestServices.GetService<InfoService>();
    context.Response.ContentType = "text/plain; charset=utf-8";    
    await context.Response.WriteAsync(companyService.GetCompanyWithMostEmployees());
    await context.Response.WriteAsync(infoService.GetInfo());


});


app.Run();