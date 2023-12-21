using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "teste");
app.MapPost("/user", () => new {Name = "testando", Age = 35});
app.MapGet("/AddHeader", (HttpResponse response) => {
    response.Headers.Add("Test", "marcelo");
    return new {Name = "Stephany batista", Age = 35};

});

app.MapPost("/saveproduct", (Product product) => {
    return product.Code + " - " + product.Name;

});


//api.app.com/users?datastart={date}&dateend={date}
app.MapGet("/getproduct", ([FromQuery] string dateStart,[FromQuery] string DateEnd) => {
    return dateStart + " - " + DateEnd;
});


//api.app.com/user/{code}
app.MapGet("/getproduct/{code}", ([FromRoute] string code) => {
    return code;
});

app.MapGet("/getproductbyheader", (HttpRequest request) =>{
    return request.Headers["product-code"].ToString();
});

app.Run();


public class Product{
    public string Code {get; set;}
    public string Name { get; set; }
}
