using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System.Data;
using BestBuyBestPractices;

var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

string connString = config.GetConnectionString("DefaultConnection");

IDbConnection conn = new MySqlConnection(connString);

var repo = new DapperDepartmentRepository(conn);
var departments = repo.GetAllDepartment();
foreach (var department in departments)
{
    Console.WriteLine($"{department.DepartmentID} - {department.Name}");
}
Console.WriteLine("---------------------------------");

var x = new DapperProductRepository(conn);
var products = x.GetAllProducts();
foreach (var product in products)
{
    Console.WriteLine($"{product.ProductID} - {product.Name}");
}
Console.WriteLine("---------------------------------");

var y = new DapperProductRepository(conn);

Console.WriteLine($"What is the new product name?");
var productName = Console.ReadLine();

Console.WriteLine($"What is the new product's price?");
var productPrice = Convert.ToDouble(Console.ReadLine());

Console.WriteLine($"What is the new product's category id?");
var productCategoryID = Convert.ToInt32(Console.ReadLine());

y.CreateProduct(productName, productPrice, productCategoryID);