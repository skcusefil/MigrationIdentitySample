using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MigrationIdentity.Data;
using MigrationIdentity.Entities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<IdentDataContext>(opt =>
{
    opt.UseSqlite("Data source=database.db");
});

builder.Services.AddIdentityCore<AppUser>(opt => {
    opt.Password.RequireNonAlphanumeric = false;
})
         .AddRoles<AppRole>()
         .AddRoleManager<RoleManager<AppRole>>()
         .AddSignInManager<SignInManager<AppUser>>()
         .AddRoleValidator<RoleValidator<AppRole>>()
         .AddEntityFrameworkStores<IdentDataContext>();

builder.Services.AddAuthentication();

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

app.Run();
