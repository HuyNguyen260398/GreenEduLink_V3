using AutoMapper;
using GEL.Services.PostAPI.DbContexts;
using GEL.Services.PostAPI.Profiles;
using GEL.Services.PostAPI.Repos;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddCors(o =>
{
    o.AddPolicy("CorsPolicy",
        builder => builder.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader());
});

IMapper mapper = MappingConfig.RegisterMaps().CreateMapper();
builder.Services.AddSingleton(mapper);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<IPostRepo, PostRepo>();
//builder.Services.AddScoped<IPostRepo, InMemPostRepo>();

builder.Services.AddControllers();

//builder.Services.AddAuthentication("Bearer")
//                .AddJwtBearer("Bearer", options =>
//                {
//                    options.Authority = "https://localhost:7102/";
//                    options.TokenValidationParameters = new TokenValidationParameters
//                    {
//                        ValidateAudience = false
//                    };
//                });

//builder.Services.AddAuthorization(options =>
//{
//    options.AddPolicy("ApiScope", policy =>
//    {
//        policy.RequireAuthenticatedUser();
//        policy.RequireClaim("scope", "gel");
//    });
//});

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.Authority = builder.Configuration["Auth0:Authority"];
    options.Audience = builder.Configuration["Auth0:ApiIdentifier"];
});

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "GEL.Services.PostAPI", Version = "v1" });
    c.EnableAnnotations();
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = @"Enter 'Bearer' [space] and your token",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                },
                Scheme = "oauth2",
                Name = "Bearer",
                In = ParameterLocation.Header
            },
            new List<string>()
        }
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "GEL.Services.PostAPI v1"));
}

app.UseHttpsRedirection();

app.UseCors("CorsPolicy");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
