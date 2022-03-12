using SpaceShipWarBa.Managers;
using UnityEngine;

namespace SpaceShipWarBa.Uis
{
    public class GameOverObject : MonoBehaviour
    {
        [SerializeField] CanvasGroup _canvasGroup;

        void Awake()
        {
            if (_canvasGroup == null)
            {
                _canvasGroup = GetComponent<CanvasGroup>();
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
        
        void HandleOnGameOvered(int gameplayScore, int bestScore)
        {
            _canvasGroup.alpha = 1f;
            _canvasGroup.interactable = true;
            _canvasGroup.blocksRaycasts = true;
        }
    }    
}

