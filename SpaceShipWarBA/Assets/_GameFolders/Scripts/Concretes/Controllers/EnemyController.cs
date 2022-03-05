using SpaceShipWarBa.Abstracts.Controllers;

namespace SpaceShipWarBa.Controllers
{
    public class EnemyController : BaseCharacterController, IEnemyController
    {
        protected override void FireProcess()
        {
            // _currentAttackTime += Time.deltaTime;
            //
            // if (_currentAttackTime > _stats.FireRate)
            // {
            //     _currentAttackTime = 0f;
            //     Instantiate(_stats.Projectile, transform.position, Quaternion.identity);
            // }
        }
    }
}