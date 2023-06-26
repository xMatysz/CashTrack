using CashTrack.Api;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<Expense>();
builder.Services.AddSingleton<ExpenseRepository>();
builder.Services.AddControllers();
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

app.MapGet("/expenses", ([FromServices] ExpenseRepository repo) => repo.GetAll());
app.MapGet("/expenses/{id}", ([FromServices] ExpenseRepository repo, Guid id) =>
{
	var expense = repo.GetById(id);
	return expense is not null ? Results.Ok(expense) : Results.NotFound();
});
app.MapPost("/expenses", ([FromServices]ExpenseRepository repo, [FromBody]Expense expense) =>
{
	repo.Create(expense);
	return Results.Created($"/expenses/{expense.Id}", expense);
});

app.Run();