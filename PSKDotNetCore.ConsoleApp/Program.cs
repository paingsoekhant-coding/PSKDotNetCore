
using PSKDotNetCore.ConsoleApp;
using System.Data;
using System.Data.SqlClient;

Console.WriteLine("Hello, World!");

AdoDotNetExample adoDotNetExample = new AdoDotNetExample();

//adoDotNetExample.Create("AdoDotNet","Ko Sann Lynn Htun","C# AdoDotNet Course" );
//adoDotNetExample.Read();
adoDotNetExample.Update(10,"New Update Title" , "new Update Author" , "new Update Content");
Console.ReadKey();