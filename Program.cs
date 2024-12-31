using System.Text;
using HODPoc.DBContext;
using HODPoc.Models.BAO;
using HODPoc.Models.DAO;
using HODPoc.Models.Entities;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpContextAccessor();

builder.Services.AddDbContext<HODContext>(option =>
    option.UseSqlServer(builder.Configuration.GetConnectionString("Default"))
);
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<StudentBao>();
builder.Services.AddScoped<StudentDao>();
builder.Services.AddScoped<SubjectBao>();
builder.Services.AddScoped<SubjectDao>();
builder.Services.AddScoped<TeacherDao>();
builder.Services.AddScoped<TeacherBao>();
builder.Services.AddScoped<HodBao>();
builder.Services.AddScoped<HodDao>();
builder.Services.AddScoped<LoginBao>();
builder.Services.AddScoped<LoginDao>();
builder
    .Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])
            ),
        };
    });

// Add authorization
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("HodRole", policy => policy.RequireRole("Hod"));
    options.AddPolicy("TeacherRole", policy => policy.RequireRole("Teacher", "Hod"));
    options.AddPolicy("StudentRole", policy => policy.RequireRole("Student", "Hod", "Teacher"));
    options.AddPolicy(
        "SubjectRole",
        policy => policy.RequireRole("Student", "Hod", "Teacher", "Subject")
    );
});
builder.Services.AddSwaggerGen(c =>
{
    // Add security definition for Bearer token
    c.AddSecurityDefinition(
        "Bearer",
        new OpenApiSecurityScheme
        {
            In = ParameterLocation.Header,
            Description = "Enter JWT token with Bearer prefix (e.g., 'Bearer <token>')",
            Name = "Authorization",
            Type = SecuritySchemeType.ApiKey,
            BearerFormat = "JWT",
        }
    );

    // Add security requirement
    c.AddSecurityRequirement(
        new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer",
                    },
                },
                new string[] { }
            },
        }
    );
});

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
        c.RoutePrefix = string.Empty; // Serves Swagger UI at the app's root
    });
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
