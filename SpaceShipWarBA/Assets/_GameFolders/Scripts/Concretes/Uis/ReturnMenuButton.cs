using SpaceShipWarBa.Abstracts.Uis;
using SpaceShipWarBa.Managers;

namespace SpaceShipWarBa.Uis
{
    public class ReturnMenuButton : BaseButton
    {
        protected override void HandleOnButtonClicked()
        {
            GameManager.Instance.LoadMenuScene();
        }
    }
}

