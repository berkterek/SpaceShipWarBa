using UnityEngine;

namespace SpaceShipWarBa.Managers
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] int _gameplayScore;
        [SerializeField] int _bestScore;
        
        public static GameManager Instance { get; private set; }

        void Awake()
        {
            SetThisObjectToSingleton();
        }

        private void SetThisObjectToSingleton()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(this.gameObject);
            }
            else
            {
                Destroy(this.gameObject);
            }
        }

        public void SetScore(int statsScoreValue)
        {
            _gameplayScore += statsScoreValue;
        }
    }    
}