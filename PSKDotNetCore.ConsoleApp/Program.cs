
using PSKDotNetCore.ConsoleApp;
using System.Data;
using System.Data.SqlClient;

Console.WriteLine("Hello, World!");

AdoDotNetExample adoDotNetExample = new AdoDotNetExample();

//adoDotNetExample.Create("AdoDotNet","Ko Sann Lynn Htun","C# AdoDotNet Course" );

//adoDotNetExample.Read();

//adoDotNetExample.Update(17,"AdoDotNet Update" , " Update Author" , " Update Content");

//adoDotNetExample.Edit(12);

adoDotNetExample.Delete(31);


Console.ReadKey();