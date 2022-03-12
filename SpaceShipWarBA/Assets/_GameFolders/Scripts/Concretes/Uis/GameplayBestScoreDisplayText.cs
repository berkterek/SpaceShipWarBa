using SpaceShipWarBa.Abstracts.Uis;

namespace SpaceShipWarBa.Uis
{
    public class GameplayBestScoreDisplayText : BaseScoreDisplayText
    {
        protected override void HandleOnGameOvered(int gameplayScore, int bestScore)
        {
            _scoreText.text = bestScore.ToString();
        }
    }
}

