using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PSKDotNetCore.ConsoleApp.AdoDotNetExamples;
using PSKDotNetCore.ConsoleApp.DapperExamples;
using PSKDotNetCore.ConsoleApp.EFCoreExamples;
using PSKDotNetCore.ConsoleApp.Services;
using System.Data;
using System.Data.SqlClient;

Console.WriteLine("Hello, World!");

//AdoDotNet 

//AdoDotNetExample adoDotNetExample = new AdoDotNetExample();

//adoDotNetExample.Create("NewAdoDotNet","Ko Sann Lynn Htun","New C# AdoDotNet Course" );

//adoDotNetExample.Read();

//adoDotNetExample.Update(27,"AdoDotNet Update" , " Update Author" , " Update Content");

//adoDotNetExample.Edit(25);

//adoDotNetExample.Delete(32);

//Dapper 

//DapperExample dapperExample = new DapperExample();

//dapperExample.Run();


//EFCore 
//EFCoreExample eFCoreExample = new EFCoreExample();
//eFCoreExample.Run();

var connectionString = ConnectionStrings.SqlConnectionStringBuilder.ConnectionString;
var sqlConnectionStringBuilder  = new SqlConnectionStringBuilder(connectionString);
var serviceProvider = new ServiceCollection()
    .AddScoped(n => new AdoDotNetExample(sqlConnectionStringBuilder))
     .AddScoped(n => new DapperExample(sqlConnectionStringBuilder))
    .AddDbContext<AppDbContext>(opt =>
    {
        opt.UseSqlServer(connectionString);
    })
    .AddScoped<EFCoreExample>()
    .BuildServiceProvider();

//AppDbContext db = serviceProvider.GetRequiredService<AppDbContext>();

var adoDotNetExample = serviceProvider.GetRequiredService<AdoDotNetExample>();
adoDotNetExample.Read();

//var dapperExample = serviceProvider.GetRequiredService<DapperExample>();
//dapperExample.Run();

Console.ReadKey();