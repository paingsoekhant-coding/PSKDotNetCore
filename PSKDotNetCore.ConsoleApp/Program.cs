
using PSKDotNetCore.ConsoleApp;
using System.Data;
using System.Data.SqlClient;

Console.WriteLine("Hello, World!");

AdoDotNetExample adoDotNetExample = new AdoDotNetExample();

//adoDotNetExample.Create("NewAdoDotNet","Ko Sann Lynn Htun","New C# AdoDotNet Course" );

//adoDotNetExample.Read();

//adoDotNetExample.Update(27,"AdoDotNet Update" , " Update Author" , " Update Content");

//adoDotNetExample.Edit(25);

adoDotNetExample.Delete(32);


Console.ReadKey();