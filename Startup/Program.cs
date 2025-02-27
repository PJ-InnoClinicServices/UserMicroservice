using Startup.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContexts(builder.Configuration);
MapperRegistration.AddTinyMapper(builder.Services);
builder.Services.AddServices();
builder.Services.AddAssemblies();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
}
app.MapControllers();
app.UseHttpsRedirection();

app.Run();