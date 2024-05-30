// See https://aka.ms/new-console-template for more information
using Newtonsoft.Json;
using PSKDotNetCore.NLayer.BusinessLogic.Services;
using PSKDotNetCore.NLayer.DataAccess;
using System.Xml;

Console.WriteLine("Hello, World!");

BL_Blog bl_Blog = new BL_Blog();
var lst = bl_Blog.GetBlog(20);

var jsonStr = JsonConvert.SerializeObject(lst, Newtonsoft.Json.Formatting.Indented);
Console.WriteLine(jsonStr);
