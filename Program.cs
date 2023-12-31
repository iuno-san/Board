using Board.Entities;
using Microsoft.AspNetCore.Http.Json;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.Configure<JsonOptions>(options =>
{
    options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

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

var users = dbContext.Users.ToList();
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

    dbContext.Users.AddRange(user1, user2);

    dbContext.SaveChanges();
}


app.MapGet("data", async (BoardContext db) =>
{
    var user = await db.Users
    .Include(u => u.comments).ThenInclude(c => c.WorkItem)
    .Include(u => u.Address)
    .FirstAsync(u => u.Id == Guid.Parse("68366dbe-0809-490f-cc1d-08da10ab0e61"));

    /*var userComments = await db.comments.Where(c => c.AuthorId == user.Id).ToListAsync();*/

    return user;

    /*
     var authorsCommentCounts = await db.Comments
    .GroupBy(c => c.AuthorId)
    .Select(g => new { g.Key, Count = g.Count()})
    .ToListAsync();

    var topAuthor = authorsCommentCounts
        .First(a => a.Count == authorsCommentCounts.Max(acc => acc.Count));

    var userDetails = db.Users.First(u => u.Id == topAuthor.Key);

    return new { userDetails, commentCount = topAuthor.Count };
     */
});

app.MapPost("Update", async(BoardContext db) =>
{
    Epic epic = await db.Epics.FirstAsync(epic => epic.Id == 1);
    
    epic.Priority = 1;
    epic.StartDate = DateTime.Now;
    epic.Area = "Update Area";

    await db.SaveChangesAsync();

    return epic;
});

app.MapPost("create", async (BoardContext db) =>
{
    var address = new Address()
    {
        Id = Guid.Parse("b323dd7c-776a-4cf6-a92a-12df154b4a2c"),
        City = "Krak�w",
        Country = "Poland",
        Street = "D�uga"

    };

    var user = new User()
    {
        Email = "user@test.com",
        FullName = "Test User",
        Address = address,
    };

    db.Users.Add(user);
    await db.SaveChangesAsync();

    return user;


    /*Tag tag = new Tag() { Value="EF", Id=6 };

    await db.Tags.AddAsync(tag);
    await db.SaveChangesAsync();

    return tag;*/

});

app.Run();

