using BankingSystem.DataBase;
using BankingSystem.Repository.Repository.IRepository;
using BankingSystem.Services.IServices;
using BankingSystem.Repository.Repository;
using BankingSystem.Services.Services;
using Microsoft.EntityFrameworkCore;
using BankingSystem.MappingProfiles;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddScoped<IBankAccountService, BankAccountService>();
builder.Services.AddScoped<IBankTransactionService, BankTransactionService>();
builder.Services.AddScoped<IAccountTypeService, AccountTypeService>();
builder.Services.AddScoped<IPaymentMethodService, PaymentMethodService>();
builder.Services.AddScoped<IBankAccountPostingService, BankAccountPostService>();
builder.Services.AddScoped<IAccountTypeRepo, AccountTypeRepo>();
builder.Services.AddScoped<IPaymentMethodRepo, PaymentMethodRepo>();
builder.Services.AddScoped<IBankAccountRepo, BankAccountRepo>();
builder.Services.AddScoped<IBankTransactionRepo, BankTransactionRepo>();
builder.Services.AddScoped<IBankAccountPostingRepo, BankAccountPostingRepo>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDbContext>(o => o.UseSqlServer(builder.Configuration.GetConnectionString("BankingSystemConnection"),
                                                      x => x.MigrationsAssembly("BankingSystem.Migration")));

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
app.UseRouting();

app.Run();

