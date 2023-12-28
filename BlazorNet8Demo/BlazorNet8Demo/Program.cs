using BlazorNet8Demo.Client.Pages;
using BlazorNet8Demo.Components;
using ViewModels.StudentVM;
using RepoLayer.StudentRepo;
using SharedModels.StudentModels;
using ServerServices.StudentServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();


// Register our Dependency Injections
builder.Services.AddScoped<IStudentVM, StudentVM>();
builder.Services.AddScoped<IStudentRepo, StudentRepo>();
builder.Services.AddScoped<IStudentService, StudentService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
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
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(SelectStudentDemo).Assembly);

app.Run();
