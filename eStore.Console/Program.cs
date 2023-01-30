// See https://aka.ms/new-console-template for more information
using System;
using eStore.Infrastructure.Persistance;
using eStore.Infrastructure.Persistance.Repositories;
using eStore.Application;
using eStore.Contracts.DTOs;
using eStore.Contracts;
using eStore.Api.Controllers;
using Microsoft.Extensions.Logging;

Console.WriteLine("Adding Products");
//Console.ReadLine();

var IM = new InventoryMangementController(LoggerFactory.Create(logging => logging.AddConsole()).CreateLogger<InventoryMangementController>());
var CM = new CustomerMangementController(LoggerFactory.Create(logging => logging.AddConsole()).CreateLogger<CustomerMangementController>());
var OM = new OrderManagementController(LoggerFactory.Create(logging => logging.AddConsole()).CreateLogger<OrderManagementController>());


var p1 = IM.GetProduct(new GetProductRequest() { Barcode = "BR001" });
if (p1.Product == null)
{
    var pr = IM.AddProduct(new AddProductRequest()
    {
        Barcode = "BR001",
        Category = "Clothing",
        Description = "",
        IsWeighted = false,
        Name = "White T-Shirt",
        Price = 80,
        Status = ENUMS.ProductStatus.InStock
    });
    Console.WriteLine("Product Added");
    Console.WriteLine(pr.ToString());
    p1 = IM.GetProduct(new GetProductRequest() { Barcode = "BR001" });
}
else Console.WriteLine("Product already exisit");
Console.WriteLine("");


var p2 = IM.GetProduct(new GetProductRequest() { Barcode = "BR002" });
if (p2.Product == null)
{
    var pr = IM.AddProduct(new AddProductRequest()
    {
        Barcode = "BR002",
        Category = "Clothing",
        Description = "",
        IsWeighted = false,
        Name = "White T-Shirt",
        Price = 80,
        Status = ENUMS.ProductStatus.InStock
    });
    Console.WriteLine("Product Added");
    Console.WriteLine(pr.ToString());
    p2 = IM.GetProduct(new GetProductRequest() { Barcode = "BR002" });
}
else Console.WriteLine("Product already exisit");
Console.WriteLine("");

var ChangeProductStatusResponse = IM.ChangeProductStatus(new ChangeProductStatusRequest() { ProductId = p2.Product.ProductId, NewStatus = ENUMS.ProductStatus.Damaged });
Console.WriteLine("Product(BR002) status changes");
Console.WriteLine("");

var c1 = CM.GetCustomer(new GetCustomerRequest() { Email = "ElenaLynnyk@sgp.Technology" });
if (c1.Customer == null)
{
    var cr = CM.AddCustomer(new AddCustomerRequest()
    {
        Name = "Elena Lynnyk",
        Email = "ElenaLynnyk@sgp.Technology",
        ShippingAddress = "1102, Media City , Dubai , UAE"
    });
    Console.WriteLine("Customer Added");
    Console.WriteLine(cr.ToString());
    c1 = CM.GetCustomer(new GetCustomerRequest() { Email = "ElenaLynnyk@sgp.Technology" });
}
else { Console.WriteLine("Customer already exsist"); }
Console.WriteLine("");

var c2 = CM.GetCustomer(new GetCustomerRequest() { Email = "alianwar08@gmail.com" });
if (c2.Customer == null)
{
    var cr = CM.AddCustomer(new AddCustomerRequest()
    {
        Name = "Ali Anwar",
        Email = "alianwar08@gmail.com",
        ShippingAddress = "1102, Sports City , Dubai , UAE"
    });
    Console.WriteLine("Customer Added");
    Console.WriteLine(cr.ToString());
    c2 = CM.GetCustomer(new GetCustomerRequest() { Email = "alianwar08@gmail.com" });
}
else { Console.WriteLine("Customer already exsist"); }
Console.WriteLine("");


var cartResponse = OM.GetCart(new GetCartRequest() { CustomerId = c1.Customer.CustomerId });
if (cartResponse.Cart == null)
{
    Guid[] pids = { p1.Product.ProductId };
    var cartR = OM.CreateOrUpdateCart(new CreateOrUpdateCartRequest()
    {
        CustomerId = c1.Customer.CustomerId,
        ProductIds = pids
    });
    Console.WriteLine("Customer cart created");
    Console.WriteLine(cartR);
}
else { Console.WriteLine("Cart already exsist"); }

Console.WriteLine("");

var checkOutCartResponse = OM.CheckOutCart(new CheckOutCartRequest()
{
    CustomerId = c1.Customer.CustomerId
});
Console.WriteLine("Customer order placed");
Console.WriteLine(checkOutCartResponse);
Console.WriteLine("");


