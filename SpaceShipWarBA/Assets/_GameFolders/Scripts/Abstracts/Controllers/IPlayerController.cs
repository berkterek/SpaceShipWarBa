using SpaceShipWarBa.Abstracts.DataContainers;
using SpaceShipWarBa.Abstracts.Inputs;

namespace SpaceShipWarBa.Abstracts.Controllers
{
    public interface IPlayerController : IEntityController,IAttackerController,IHealthController
    {
        IInputReader InputReader { get; }
        IPlayerStats Stats { get; }
    }
}