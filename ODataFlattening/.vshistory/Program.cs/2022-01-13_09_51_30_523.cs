using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using ODataFlattening;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddOData(options => options.AddRouteComponents("api", EdmModelBuilder.GetEdmModel()).Select().Filter().OrderBy().Count().Expand().SkipToken().SetMaxTop(100));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<FlatteningContext>(options => options.UseSqlite());
builder.Services.AddAutoMapper(typeof(Program));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

await InitDbContext(app);

app.Run();


async Task InitDbContext(WebApplication app)
{
    using (var scope = app.Services.CreateScope())
    {
        var context = scope.ServiceProvider.GetRequiredService<FlatteningContext>();
        await context.InitData();
    }
}