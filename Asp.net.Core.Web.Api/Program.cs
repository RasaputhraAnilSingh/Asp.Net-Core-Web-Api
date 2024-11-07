using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin", builder =>
    {
        builder.WithOrigins("http://127.0.0.1:5500")  // Add your allowed origins here
               .AllowAnyHeader()
               .AllowAnyMethod();
    });
});
//Added Authentication Registrations
byte[] Secretkey = Encoding.ASCII.GetBytes(builder.Configuration.GetValue<string>("SecretKey"));
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}

 ).AddJwtBearer(options =>
 {
     //options.RequireHttpsMetadata = false;
     options.SaveToken = true;
     options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
     {
         ValidateIssuerSigningKey = true,
         IssuerSigningKey = new SymmetricSecurityKey(Secretkey),
         ValidateIssuer = false,
         ValidateAudience = false,
     };

 });
//end - Added Authentication Registrations
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
// Enable CORS
app.UseCors("AllowSpecificOrigin");
app.UseHttpsRedirection();

app.UseAuthorization();


app.MapControllers();

app.Run();
