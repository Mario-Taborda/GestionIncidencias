using GestionIncidencias.Bussiness.Mapping;
using GestionIncidencias.Bussiness.Interfaces;
using GestionIncidencias.Bussiness.Services;
using GestionIncidencias.Domain.Interfaz;
using GestionIncidencias.Infraestructure.Data;
using GestionIncidencias.Infraestructure.Repositories;
using GestionIncidencias.Infraestructure.Repository;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http.Features;

namespace GestionIncidencias.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");          
            builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(connectionString, sqlOptions =>
            {
                sqlOptions.EnableRetryOnFailure(
                    maxRetryCount: 5,
                    maxRetryDelay: TimeSpan.FromSeconds(30),
                    errorNumbersToAdd: null);
            }));
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", policy =>
                {
                    policy.WithOrigins("http://localhost:5127", "https://localhost:7133")
                          .AllowAnyMethod()
                          .AllowAnyHeader();
                });
            });
            builder.Services.AddScoped<IIncidenciaRepository, IncidenciaRepository>();
            builder.Services.AddScoped<IIncidenciaService, IncidenciaService>();
            builder.Services.AddScoped<IncidenciaRepository>();

            builder.Services.AddScoped<ITipoIncidenciaRepository, TipoIncidenciaRepository>();
            builder.Services.AddScoped<TipoIncidenciaService, TipoIncidenciaService>();
            builder.Services.AddScoped<TipoIncidenciaRepository>();

            builder.Services.AddScoped<IEstadoRepository, EstadoRepository>();
            builder.Services.AddScoped<EstadoService, EstadoService>();
            builder.Services.AddScoped<EstadoRepository>();

            builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            builder.Services.AddScoped<IUsuarioService, UsuarioService>();
            builder.Services.AddScoped<UsuarioRepository>();

            builder.Services.AddScoped<IFlujoIncidenciaRepository, FlujoIncidenciaRespository>();
            builder.Services.AddScoped<FlujoIncidenciaService, FlujoIncidenciaService>();
            builder.Services.AddScoped<FlujoIncidenciaRespository>();

            builder.Services.AddScoped<IEncargadoRepository, EncargadoRepository>();
            builder.Services.AddScoped<EncargadoService, EncargadoService>();
            builder.Services.AddScoped<EncargadoRepository>();

            builder.Services.AddScoped<ITipoSolucionRepository, TipoSolucionRepository>();
            builder.Services.AddScoped<TipoSolucionService, TipoSolucionService>();
            builder.Services.AddScoped<TipoSolucionRepository>();

            builder.Services.AddScoped<IEmailService, EmailService>();
            
            builder.Services.AddSwaggerGen();
            builder.Services.AddEndpointsApiExplorer();
        
            builder.Services.Configure<FormOptions>(options =>
            {
                options.ValueLengthLimit = int.MaxValue;
                options.MultipartBodyLengthLimit = int.MaxValue;
                options.MemoryBufferThreshold = int.MaxValue;
            });
            builder.WebHost.ConfigureKestrel(options =>
            {
                options.Limits.MaxRequestBodySize = long.MaxValue;
            });
            builder.Services.AddControllers()
           .AddJsonOptions(options => {
            options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
            options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
            });
            builder.Services.AddAutoMapper(cfg => { cfg.AddProfile<MappingProfile>(); });
            builder.Services.AddOpenApi();
            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseCors("AllowAll");
            app.UseAuthentication();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}
