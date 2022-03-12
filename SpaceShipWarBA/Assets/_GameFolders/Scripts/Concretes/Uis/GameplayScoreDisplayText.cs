using SpaceShipWarBa.Abstracts.Uis;

namespace SpaceShipWarBa.Uis
{
    public class GameplayScoreDisplayText : BaseScoreDisplayText
    {
        protected override void HandleOnGameOvered(int gameplayScore, int bestScore)
        {
            _scoreText.text = gameplayScore.ToString();
        }
    }
}