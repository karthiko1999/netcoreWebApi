using Microsoft.EntityFrameworkCore;
using StudentManagement.Data;
using StudentManagement;
using StudentManagement.Repositories;
using System.Reflection;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.OpenApi.Models;
using System.Reflection.Metadata;

public class Program
{
    [Obsolete]
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        // change the swagger to support the Authentication
        builder.Services.AddSwaggerGen(options => {
            var securityscheme = new OpenApiSecurityScheme
            {
                Name = "JWT Authentication",
                Description = "Enter a Valid JWT bearer Token..",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.Http,
                Scheme = "bearer",
                BearerFormat = "JWT",
                Reference = new OpenApiReference
                {
                    Id = JwtBearerDefaults.AuthenticationScheme,
                    Type = ReferenceType.SecurityScheme
                }
            };
            options.AddSecurityDefinition(securityscheme.Reference.Id,securityscheme);
            options.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    securityscheme,new String[]{}
                }
            });
        });

        builder.Services.AddMvc();


        var connectionString = builder.Configuration.GetConnectionString("StudentDBConnectionString");
        builder.Services.AddDbContext<StudentDbContext>(options =>
            {
                options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
            });

        builder.Services.AddControllers();

        //Register the RepositoryServices to IOC
        builder.Services.AddScoped<IStudentRepository, StudentRepository>();
        builder.Services.AddScoped<IGradeRepository, GradeRepository>();
        builder.Services.AddScoped<IStudentAddressRepository, StudentAddressRepository>();
        //FluentAPI services
        builder.Services.AddControllers().AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<Program>());




        // Here WE need to register all our Authentication services to IOC

        builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters()
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = builder.Configuration["Jwt:Issuer"],
                ValidAudience = builder.Configuration["Jwt:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
            };
        });
        // User Repository for Authentication
        // builder.Services.AddSingleton<IUserRepository, StaticUserRepository>(); this is for static list of users.
        
        builder.Services.AddScoped<IUserRepository, UserRepository>();
        builder.Services.AddSingleton<ITokenHandler, StudentManagement.Repositories.TokenHandler>();


        // Provide the assembly that contains profiles to AutoMapper
        builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

        var app = builder.Build();


        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        // ADD Authentication middleware to pipeline before Authorization
        app.UseAuthentication();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}

