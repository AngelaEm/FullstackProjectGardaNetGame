using Azure.Storage.Blobs;
using GardaNetGame.Client.Components;
using GardaNetGame.Client.Components.Account;
using GardaNetGame.Client.Data;
using GardaNetGame.Client.Services;
using GardaNetGame.Shared.DTOs.Customer.Response;
using GardaNetGame.Shared.DTOs.Events.Response;
using GardaNetGame.Shared.DTOs.EventTypes.Response;
using GardaNetGame.Shared.DTOs.Games.Response;
using GardaNetGame.Shared.DTOs.Genres.Response;
using GardaNetGame.Shared.DTOs.Orders.Responses;
using GardaNetGame.Shared.Interfaces;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddRazorComponents()
	.AddInteractiveServerComponents();

builder.Services.AddHttpClient("gardaNetGameApi",
	client => 
		client.BaseAddress = new Uri("https://localhost:7265"));

//builder.Services.AddHttpClient("faqLogicApp", client =>
//{
//	client.BaseAddress = new Uri("null");
//});

builder.Services.AddCascadingAuthenticationState();
builder.Services.AddScoped<IdentityUserAccessor>();
builder.Services.AddScoped<IdentityRedirectManager>();
builder.Services.AddScoped<AuthenticationStateProvider, IdentityRevalidatingAuthenticationStateProvider>();
builder.Services.AddScoped<IEventService<EventsResponse>, EventService>();
builder.Services.AddScoped<IEventTypeService<EventTypesResponse>, EventTypeService>();
builder.Services.AddScoped<IGenreService<GenresResponse>, GenreService>();
builder.Services.AddScoped<IGameService<GameResponse>, GameService>(); 
builder.Services.AddScoped<IOrderService<OrdersResponse>, OrderService>();
builder.Services.AddScoped<ICustomerService<CustomersResponse>, CustomerService>();
builder.Services.AddAuthentication(options =>
	{
		options.DefaultScheme = IdentityConstants.ApplicationScheme;
		options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
	})
	.AddIdentityCookies();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
	options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddIdentityCore<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
	.AddRoles<IdentityRole>()
	.AddEntityFrameworkStores<ApplicationDbContext>()
	.AddSignInManager()
	.AddDefaultTokenProviders();

builder.Services.AddSingleton<IEmailSender<ApplicationUser>, IdentityNoOpEmailSender>();

//builder.Services.AddSingleton(x =>
//{
//    var config = x.GetRequiredService<IConfiguration>();
//    var blobServiceClient = new BlobServiceClient(config["AzureBlobStorage:ConnectionString"]);
//    return blobServiceClient.GetBlobContainerClient(config["AzureBlobStorage:ContainerName"]);
//});

//builder.Services.AddSingleton<BlobStorageService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseMigrationsEndPoint();
}
else
{
	app.UseExceptionHandler("/Error", createScopeForErrors: true);
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
	.AddInteractiveServerRenderMode();

// Add additional endpoints required by the Identity /Account Razor components.
app.MapAdditionalIdentityEndpoints();

app.Run();
