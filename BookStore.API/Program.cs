using BookStore.Domain.Policies;
using BookStore.Application.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// 👇 เพิ่มตรงนี้
builder.Services.AddSingleton<PromotionPolicy>();
builder.Services.AddScoped<PromotionService>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

app.Run();