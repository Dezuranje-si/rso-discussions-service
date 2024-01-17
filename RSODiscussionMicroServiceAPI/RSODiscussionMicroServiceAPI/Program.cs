using Carter;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using RSO.Core.BL;
using RSO.Core.Configurations;
using RSO.Core.DiscussionModels;
using RSO.Core.Repository;
using RSODiscussionMicroServiceAPI.GraphQL;
using HotChocolate;

var builder = WebApplication.CreateBuilder(args);

// Register the IOptions object.
builder.Services.AddOptions<DiscussionServicesSettingsConfiguration>()
    .BindConfiguration("DiscussionServicesSettingsConfiguration");
//Explicitly register the settings objects by delegating to the IOptions object.
builder.Services.AddSingleton(resolver => resolver.GetRequiredService<IOptions<DiscussionServicesSettingsConfiguration>>().Value);

//builder.Services.AddGraphQLServer().AddQueryType(q => q.Name("Query")).AddType<DiscussionQueryResolver>();

builder.Services.AddGraphQLServer().AddQueryType<Query>();

// Database connection
builder.Services.AddDbContext<DiscussionServicesRSOContext>(options =>
options.UseNpgsql(builder.Configuration.GetConnectionString("DiscussionServicesRSOdB")));

// Razor pages
builder.Services.AddRazorPages();

// Lazy cache
builder.Services.AddLazyCache();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IDiscussionRepository, DiscussionRepository>(); //In each microservice a different repository/serice is inlcuded. If more tables are needed add more repos related to the microservice.
builder.Services.AddScoped<IDiscussionLogic, DiscussionLogic>(); //In each microservice a different repository/serice is inlcuded.*/


//Carter
builder.Services.AddHttpContextAccessor();
builder.Services.AddCarter();
// Add services to the container.
builder.Services.AddAuthorization();
builder.Services.AddEndpointsApiExplorer();

//builder.Services.AddOpenApiDocument(options =>
//{
//    options.PostProcess = document =>
//    {
//        document.Info = new()
//        {
//            Version = "v1",
//            Title = "DiscussionCodeFirst microservices API",
//            Description = "DiscussionLogic microservices API endpoints",
//            TermsOfService = "Lol.",
//            Contact = new()
//            {
//                Name = "Aleksander Kovac & Urban Poljsak",
//                Url = "https://www.youtube.com/watch?v=dQw4w9WgXcQ"
//            }
//        };
//    };
//    options.UseControllerSummaryAsTagDescription = true;
//});
// APP.
var app = builder.Build();
app.MapGraphQL();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
// Carter
app.MapCarter();
//app.UseOpenApi();
//app.UseSwaggerUi3(options =>
//{
//    options.Path = "/openapi/graphql";
//    options.TagsSorter = "DiscussionCodeFirst";
//});

app.UseAuthentication();
app.UseAuthorization();

//app.UseEndpoints(endpoints =>
//{
//    endpoints.MapRazorPages();
//    endpoints.MapControllers();
//});