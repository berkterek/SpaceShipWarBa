using SpaceShipWarBa.Abstracts.DataContainers;

namespace SpaceShipWarBa.Abstracts.Controllers
{
    public interface IProjectileController : IEntityController,IAttackerController
    {
        IProjectileStats Stats { get; }
    }    
}

