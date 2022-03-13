using SpaceShipWarBa.Abstracts.Uis;
using SpaceShipWarBa.Managers;

namespace SpaceShipWarBa.Uis
{
    public class PlayButton : BaseButton
    {
        protected override void HandleOnButtonClicked()
        {
            GameManager.Instance.LoadGameScene();
        }
    }    
}