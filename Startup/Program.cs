using Doctors.Infrastructure;
using Startup.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContexts(builder.Configuration);
MapperRegistration.AddTinyMapper(builder.Services);
builder.Services.AddServices();
builder.Services.AddAssemblies();
builder.Services.AddMassTransitServices();
builder.Services.AddCorsPolicy(builder.Configuration);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCustomRateLimiter(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
}
app.MapControllers();

app.UseCors("AllowLocalhost");
app.UseHttpsRedirection();
app.UseRateLimiter();

app.Run();