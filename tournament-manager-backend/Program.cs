using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Serialization;
using System.Text;
using tournament_manager_backend.Data;
using tournament_manager_backend.helpers;


string jwtSecret = Environment.GetEnvironmentVariable("ApplicationSettings__JWT_Secret") ?? throw new InvalidOperationException("Connection string 'TournamentAppDBCon' is not configured.");


var builder = WebApplication.CreateBuilder(args);

// Add DbContext configuration
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));



//jwt_authentification
builder.Services.AddAuthentication(cfg => {
    cfg.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    cfg.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    cfg.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x => {
    x.RequireHttpsMetadata = false;
    x.SaveToken = false;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(
            Encoding.UTF8
            .GetBytes(jwtSecret)
        ),
        ValidateIssuer = false,
        ValidateAudience = false,
        ClockSkew = TimeSpan.Zero
    };
});

//JSON Serializer
builder.Services.AddControllers().AddNewtonsoftJson(
    options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
    ).AddNewtonsoftJson(options => options.SerializerSettings.ContractResolver = new DefaultContractResolver());


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<AuthHelpers>(provider =>
{
    var dbContext = provider.GetRequiredService<ApplicationDbContext>();
    return new AuthHelpers(dbContext, jwtSecret);
});

var app = builder.Build();


//Enable CORS
app.UseCors(c => c.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
