using API.Controllers.Simulators.QueueParticipants;
using API.Hubs;
using API.Hubs.Interfaces;
using API.Startup;
using Microsoft.AspNetCore.SignalR;
using RabbitMQ.Client;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddSignalR();
builder.Services.AddControllers();
builder.Services.ConfigureSwagger(builder.Configuration);
const string corsPolicy = "_signalRCors";
//builder.Services.ConfigureCors(corsPolicy);
builder.Services.ConfigureSignalRCors(corsPolicy);
builder.Services.ConfigureAuth();
builder.Services.ConfigureRabbitMq();

builder.Services.RegisterModules();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseExceptionHandler("/error");
    app.UseHsts();
}

app.UseRouting();
app.UseCors(corsPolicy);
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.MapHub<PositionSimulatorHub>("/position-simulator-hub");

QueueConsumer.Initialize(app.Services.GetRequiredService<IHubContext<PositionSimulatorHub, IPositionClient>>());

var factory = new ConnectionFactory
{
    HostName = "localhost",
    Port = 5672,
    UserName = "natalija",
    Password = "natalija123",
    VirtualHost = "ISA simulator"
};
using var connection = factory.CreateConnection();
using var channel = connection.CreateModel();
QueueConsumer.ReceiveNewPosition(channel);    
QueueConsumer.StopSimulation(channel);
app.Run();