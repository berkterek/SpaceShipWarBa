using SpaceShipWarBa.Managers;
using TMPro;
using UnityEngine;

namespace SpaceShipWarBa.Abstracts.Uis
{
    public abstract class BaseScoreDisplayText : MonoBehaviour
    {
        [SerializeField] protected TMP_Text _scoreText;

        void Awake()
        {
            if (_scoreText == null)
            {
                _scoreText = GetComponent<TMP_Text>();
            }
        }

        void OnEnable()
        {
            GameManager.Instance.OnGameOvered += HandleOnGameOvered;
        }

        void OnDisable()
        {
            GameManager.Instance.OnGameOvered -= HandleOnGameOvered;
        }

        protected abstract void HandleOnGameOvered(int gameplayScore, int bestScore);
    }
}