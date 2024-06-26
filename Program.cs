﻿using codesome.Data;
using Microsoft.EntityFrameworkCore;
using MudBlazor.Services;
using Blazored.LocalStorage;
using MudBlazor;
using codesome.Data.Services.Courses;
using codesome.Data.Services.Lessons;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.AspNetCore.Components.Authorization;
using codesome.Authentication;
using codesome.Data.Services.Users;
using Microsoft.AspNetCore.Identity;
using codesome.Data.Services.Enrollments;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddDbContext<codesomeContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("codesomeContext");
    if (string.IsNullOrEmpty(connectionString))
    {
        throw new InvalidOperationException("Connection string not found.");
    }

    options.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 27)))
    .LogTo(Console.WriteLine, LogLevel.Information)
    .EnableSensitiveDataLogging()
    .EnableDetailedErrors();
});

builder.Services.AddAuthenticationCore();
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddServerSideBlazor();
builder.Services.AddMudServices();
builder.Services.AddHttpClient();
builder.Services.AddScoped<ProtectedSessionStorage>();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();
builder.Services.AddScoped<MudThemeProvider>();
builder.Services.AddTransient<ISnackbar, SnackbarService>();
builder.Services.AddTransient<ICoursesService, CoursesService>();
builder.Services.AddTransient<ILessonsService, LessonsService>();
builder.Services.AddTransient<IStudentEnrollmentService, StudentEnrollmentService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ICategoriesService, CategoriesService>();
builder.Services.AddScoped<ICourseCategoriesService, CourseCategoriesService>();
builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddRoles<IdentityRole>().AddEntityFrameworkStores<codesomeContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
