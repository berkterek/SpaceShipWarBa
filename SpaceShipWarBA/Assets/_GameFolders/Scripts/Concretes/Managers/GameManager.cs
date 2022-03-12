using UnityEngine;

namespace SpaceShipWarBa.Managers
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] int _gameplayScore;
        [SerializeField] int _bestScore;

        const string BEST_SCORE = "best_score";

        public static GameManager Instance { get; private set; }
        public int GameplayScore => _gameplayScore;
        public event System.Action<int> OnScoreChanged;

        void Awake()
        {
            SetThisObjectToSingleton();
        }

        void Start()
        {
            if (PlayerPrefs.HasKey(BEST_SCORE))
            {
                _bestScore = PlayerPrefs.GetInt(BEST_SCORE);
            }
        }

        void OnDestroy()
        {
            PlayerPrefs.SetInt(BEST_SCORE,_bestScore);
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
            OnScoreChanged?.Invoke(_gameplayScore);

            if (_gameplayScore > _bestScore)
            {
                _bestScore = _gameplayScore;
            }
        }
    }
}