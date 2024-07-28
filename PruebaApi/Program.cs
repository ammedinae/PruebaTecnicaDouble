using Microsoft.AspNetCore.Mvc.ApiExplorer;
using PruebaApi.Business;
using PruebaApi.Modules.swagger;
using PruebaApi.Modules.Versioning;
using Asp.Versioning.ApiExplorer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddHttpContextAccessor();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwagger();
builder.Services.AddVersioning();
builder.Services.AddMemoryCache();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();


builder.Services.AddBusinessServices(builder.Configuration);

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    //c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebService API");
    //c.RoutePrefix = string.Empty;
    var provider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();
    for (int i = 0; i < provider.ApiVersionDescriptions.Count; i++)
    {
        ApiVersionDescription? description = provider.ApiVersionDescriptions[i];
        c.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
    }
});

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();

app.MapControllers();

app.UseEndpoints(_ => { });

app.Run();
