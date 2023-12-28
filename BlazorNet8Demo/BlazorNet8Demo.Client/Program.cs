using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using RepoLayer.StudentRepo;
using ServerServices.StudentServices;
using ViewModels.StudentVM;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

// Register our Dependency Injections
builder.Services.AddScoped<IStudentVM, StudentVM>();
builder.Services.AddScoped<IStudentRepo, StudentRepo>();
builder.Services.AddScoped<IStudentService, StudentService>();

await builder.Build().RunAsync();
