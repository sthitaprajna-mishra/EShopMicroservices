using Carter;

var builder = WebApplication.CreateBuilder(args);

// add services to the container
builder.Services.AddCarter(null, config =>
{
    var modules = typeof(Program).Assembly.GetTypes().Where(t => t.IsAssignableTo(typeof(ICarterModule))).ToArray();
    config.WithModules(modules);
});
builder.Services.AddMediatR(
    config =>
    {
        config.RegisterServicesFromAssembly(typeof(Program).Assembly);
    });
var app = builder.Build();

// configure the HTTP request pipeline
app.MapCarter();

app.Run();
