using Board.Entities;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<BoardContext>(
    option => option.UseSqlServer(builder.Configuration.GetConnectionString("BoardConnectionString"))
    );

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using var scope = app.Services.CreateScope();
var dbContext = scope.ServiceProvider.GetService<BoardContext>();

var pendingMigrations = dbContext.Database.GetPendingMigrations();
if (pendingMigrations.Any())
{
    dbContext.Database.Migrate();
}

var users = dbContext.users.ToList();
if (!users.Any())
{
    var user1 = new User()
    {
        FullName = "userOne",
        Email = "userOne@test.com",
        Address = new Address() { City = "London", Street = "Newgate 12" }
        
    };
    var user2 = new User()
    {
        FullName = "userTwo",
        Email = "userTwo@test.com",
        Address = new Address() { City = "Dortmund", Street = "Hagener 10" }

    };

    dbContext.users.AddRange(user1, user2);

    dbContext.SaveChanges();
}


app.Run();

