using API.Controllers.Simulators.Models;

namespace API.Hubs.Interfaces
{
    public interface IPositionClient
    {
        Task ReceiveMessage(string message);
        Task ReceiveNewPosition(Position newPosition);
        Task StopSimulation(string message);
    }
}