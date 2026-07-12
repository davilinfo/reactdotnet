var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddAWSLambdaHosting(LambdaEventSource.HttpApi);
builder.Services.AddCors(static options =>
{
    options.AddPolicy("development", policy =>
    {
        policy.WithOrigins("http://localhost:44450")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1",new Microsoft.OpenApi.OpenApiInfo
    {
        Title = "React Dotnet Lambda",
        Version = "v1",
    });

});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddApiVersioning(options =>
{
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.DefaultApiVersion = new Asp.Versioning.ApiVersion(1, 0);
    options.ReportApiVersions = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseDefaultFiles();
app.UseStaticFiles();
app.UseRouting();
app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "react dotnet lambda v1");
});
if (app.Environment.IsDevelopment())
{
    app.UseCors("development");
}

app.MapGet("/health", () => "Healthy");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");

app.Run();
