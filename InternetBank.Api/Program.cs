
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
{
    builder.Services
                .AddApplication()
                .AddInfrastructure(builder.Configuration)
                .AddApi(builder.Configuration);
}
builder.Services.AddControllers();
// builder.Services.AddMediatR(Assembly.GetExecutingAssembly());



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
// app.UseShared();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();


