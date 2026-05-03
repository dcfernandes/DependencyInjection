using WebApi.Example;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddTransient<Service, Service>();
builder.Services.AddTransient<ICicloVidaTransient, CicloVidaTransient>();
builder.Services.AddScoped<ICicloVidaScoped, CicloVidaScoped>();
builder.Services.AddSingleton<ICicloVidaSingleton, CicloVidaSingleton>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();
app.MapControllers();

app.Run();
