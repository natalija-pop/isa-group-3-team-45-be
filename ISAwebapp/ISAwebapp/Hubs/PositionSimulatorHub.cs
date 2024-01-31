using API.Controllers.Simulators.Models;
using API.Hubs.Interfaces;
using Microsoft.AspNetCore.SignalR;

namespace API.Hubs
{
        public class PositionSimulatorHub: Hub<IPositionClient>
        {
            public override async Task OnConnectedAsync()
            {
                await Clients.All.ReceiveMessage($"{Context.ConnectionId} has joined");
            }

            public async Task ReceiveNewPosition(Position newPosition)
            {
                await Clients.All.ReceiveNewPosition(newPosition);
            }

            public async Task StopSimulation(string message)
            {
                await Clients.All.StopSimulation(message);
            }
        }
}