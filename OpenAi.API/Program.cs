using OpenAI.GPT3.Extensions;
using OpenAI.GPT3.Interfaces;
using OpenAI.GPT3.Managers;
using OpenAI.Helpers.DTO;
using OpenAI.Helpers.DTO.Profiles;
using OpenAI.Helpers.Services.OpenAICompletion;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddOpenAIService(settings => settings.ApiKey = "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");
builder.Services.AddScoped(typeof(IOpenAIService), typeof(OpenAIService));
builder.Services.AddScoped(typeof(IOpenAICompletionServices), typeof(OpenAICompletionServices));
builder.Services.AddAutoMapper(typeof(CompletionProfiles));

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
