var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Creamos el servicio que trae la configuracion del AppSettings
var provider = builder.Services.BuildServiceProvider();
var configuration = provider.GetRequiredService<IConfiguration>();
    
builder.Services.AddCors(options =>
{
    //Obtiene el valor de la url del front
    var frontendURL = configuration.GetValue<string>("frontend_url");

    //Se crea la politica de conexion entre React y C#(ASP .NET Core)
    options.AddDefaultPolicy(builder =>
    {
        //Obtiene donde se va a conectar y habilita todas las solicitudes http
        builder.WithOrigins(frontendURL).AllowAnyMethod().AllowAnyHeader();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();
