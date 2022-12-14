using EditorialService.BL.Common;
using EditorialService.BL.Domain.Model.Entities;
using EditorialService.BL.UseCases;
using EditorialService.Controller.Security;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<EditorialDbContext>(x=>x.UseInMemoryDatabase("EditorialDb"));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("basic", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "basic",
        In = ParameterLocation.Header,
        Description = "Basic Authorization header using the Bearer scheme."
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "basic"
                    }
                },
                new string[] {}
        }
     });
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});
builder.Services.AddScoped<IPublishedUseCase,PublishedUseCase>();
builder.Services.AddScoped<IEditorUseCase, EditorUseCase>();
builder.Services.AddScoped<IWriterUseCase, WriterUseCase>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddAuthentication("BasicAuthentication")
    .AddScheme<AuthenticationSchemeOptions, BasicAuthHandler>("BasicAuthentication",null);
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Editors", policy => policy.RequireClaim("RoleId","2"));
    options.AddPolicy("Writers", policy => policy.RequireClaim("RoleId", "1"));
});

var app = builder.Build();

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

static void AddEditorialDb(WebApplication app)
{
    var scope = app.Services.CreateScope();
    var db = scope.ServiceProvider.GetRequiredService<EditorialDbContext>();

    Person person1 = new Person { PersonId = 1, Name = "user1" };
    Person person2 = new Person { PersonId = 2, Name = "user2" };
    Person person3 = new Person { PersonId = 3, Name = "user3" };
    db.people.Add(person1);
    db.people.Add(person2);
    db.people.Add(person3);
    Role role1 = new Role { RoleId = 1, Name = "Writer" };
    Role role2 = new Role { RoleId = 2, Name = "Editor" };
    Role role3 = new Role { RoleId = 3, Name = "Commentarist" };
    db.roles.Add(role1);
    db.roles.Add(role2);
    db.roles.Add(role3);
    Permissions permissions1 = new Permissions { PermissionsId = 1, RoleId=1, CanApproveReject = false, CanCreateEditPost=true };
    Permissions permissions2 = new Permissions { PermissionsId = 2, RoleId = 2, CanApproveReject = true, CanCreateEditPost = false };
    Permissions permissions3 = new Permissions { PermissionsId = 3, RoleId = 3, CanApproveReject = false, CanCreateEditPost = false };
    db.permissions.Add(permissions1);
    db.permissions.Add(permissions2);
    db.permissions.Add(permissions3);
    User user1 = new User { UserId = 1, PersonId = 1, RoleId = 1, UserName = "Writer1", Password = "123Writer" };
    User user2 = new User { UserId = 2, PersonId = 2, RoleId = 2, UserName = "Editor1", Password = "123Editor" };
    User user3 = new User { UserId = 3, PersonId = 3, RoleId = 3, UserName = "Commentarist1", Password = "123Commentarist" };
    db.users.Add(user1);
    db.users.Add(user2);
    db.users.Add(user3);
    Post post1 = new Post { PostId = 1, AuthorId = 1, ApprovedBy = 2, IsApproved = true, Title = "Title1", Content = "loremp ipsun", Submited=false };
    Post post2 = new Post { PostId = 2, AuthorId = 1, IsApproved = false, Title = "Title2", Content = "loremp ipsun", Submited=true };
    Post post3 = new Post { PostId = 3, AuthorId = 1, ApprovedBy = 2, IsApproved = true, Title = "Title3", Content = "loremp ipsun", Submited=false };
    Post post4 = new Post { PostId = 4, AuthorId = 1, IsApproved = false, Title = "Title4", Content = "loremp ipsun", Submited = true };
    Post post5 = new Post { PostId = 5, AuthorId = 1, IsApproved = false, Title = "Title4", Content = "loremp ipsun", Submited = false };
    db.posts.Add(post1);
    db.posts.Add(post2);
    db.posts.Add(post3);
    db.posts.Add(post4);
    db.posts.Add(post5);
    Comment comment1 = new Comment { CommentId = 1, PostId = 1, CommentAuthorId = 3, beforeApproved = false, Content = "Hi" };
    Comment comment2 = new Comment { CommentId = 2, PostId = 1, CommentAuthorId = 1, beforeApproved = false, Content = "Hi2" };
    Comment comment3 = new Comment { CommentId = 3, PostId = 1, CommentAuthorId = 2, beforeApproved = true, Content = "Hi3" };
    Comment comment4 = new Comment { CommentId = 4, PostId = 2, CommentAuthorId = 2, beforeApproved = true, Content = "Hi4" };
    Comment comment5 = new Comment { CommentId = 5, PostId = 2, CommentAuthorId = 2, beforeApproved = false, Content = "Hi5" };
    db.comments.Add(comment1);
    db.comments.Add(comment2);
    db.comments.Add(comment3);
    db.comments.Add(comment4);

    db.SaveChanges();
}

AddEditorialDb(app);
app.Run();
