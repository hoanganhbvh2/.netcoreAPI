using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;
using SE1811.CustomFommatter;
using SE1811.DAO;
using SE1811.model;

var builder = WebApplication.CreateBuilder(args);
builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenAnyIP(7271, listenOptions =>
    {
        listenOptions.UseHttps(); 
    });
});

// mac dinh api no trav e json
builder.Services.AddControllers();
//builder.Services.AddControllers().AddXmlDataContractSerializerFormatters();
builder.Services.AddDbContext<ProductContext>(op => op.UseSqlServer(
       builder.Configuration.GetConnectionString("product")
    ));
builder.Services.AddControllers()
.AddOData(options => options
.Select()
.Count()
.Filter()
.OrderBy()
.SetMaxTop(100)
.Expand()
.AddRouteComponents("odata", GetEdmModel()));

IEdmModel GetEdmModel()
{
    ODataConventionModelBuilder odataBuilder = new ODataConventionModelBuilder();
    odataBuilder.EntitySet<Book>("Test"); // Replace with your entity
    odataBuilder.EntitySet<Product>("Test2");
    return odataBuilder.GetEdmModel();
}

var jwtSettings = builder.Configuration.GetSection("jwt");
var secretKey = jwtSettings["secret"];

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = jwtSettings["issuer"],
            ValidAudience = jwtSettings["audience"],
            IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(secretKey))
        };
    });

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("AllowAll");
app.UseHttpsRedirection();
//app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Values}/{action=index}/{id?}");
app.MapControllers();
app.Run();

