
using PSKDotNetCore.ConsoleApp;
using System.Data;
using System.Data.SqlClient;

Console.WriteLine("Hello, World!");

AdoDotNetExample adoDotNetExample = new AdoDotNetExample();

//adoDotNetExample.Read();

adoDotNetExample.Create("AdoDotNet","Ko Sann Lynn Htun","C# AdoDotNet Course" );
Console.ReadKey();