using PSKDotNetCore.ConsoleApp.EFCoreExamples;
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
EFCoreExample eFCoreExample = new EFCoreExample();
eFCoreExample.Run();


Console.ReadKey();