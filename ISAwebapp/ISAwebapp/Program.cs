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
builder.Services.ConfigureSignalRCors(corsPolicy);
builder.Services.ConfigureAuth();
builder.Services.ConfigureRabbitMq();

builder.Services.RegisterModules();
builder.Services.AddHttpClient();

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


var factoryHospital = new ConnectionFactory
{
    HostName = "localhost",
    Port = 5672,
    UserName = "guest",
    Password = "guest"
};


using var connection = factoryHospital.CreateConnection();
using var channel = connection.CreateModel();
QueueConsumer.ReceiveNewPosition(channel);    
QueueConsumer.StopSimulation(channel);

using var connectionHospital = factoryHospital.CreateConnection();
using var channelHospital = connectionHospital.CreateModel();

var httpClientFactory = app.Services.GetRequiredService<IHttpClientFactory>();

var hospitalQueueConsumer = new HospitalQueueConsumer(httpClientFactory);

hospitalQueueConsumer.ReceiveContract(channelHospital);
HospitalQueueProducer.SendDeliveryMessage(channelHospital);
app.Run();