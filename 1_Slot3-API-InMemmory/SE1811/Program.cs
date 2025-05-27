using Microsoft.EntityFrameworkCore;
using SE1811.CustomFommatter;
using SE1811.DAO;

var builder = WebApplication.CreateBuilder(args);
builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenAnyIP(7271, listenOptions =>
    {
        listenOptions.UseHttps(); // Có thể chỉ dùng dev cert hoặc chỉ định file cert
    });
});
// mac dinh api no trav e json
builder.Services.AddControllers();
builder.Services.AddControllers().AddXmlDataContractSerializerFormatters();
builder.Services.AddDbContext<ProductContext>(op => op.UseSqlServer(
       builder.Configuration.GetConnectionString("product")
    ));
//builder.Services.AddControllers(options =>
//{
//    // Thêm bộ định dạng CSV
//    options.OutputFormatters.Add(new CsvOutputFomatter());
//});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
