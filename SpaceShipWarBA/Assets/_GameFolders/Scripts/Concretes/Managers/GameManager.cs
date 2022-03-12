using System.Collections;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        public event System.Action<int,int> OnGameOvered;

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

        public void GameOverProcess()
        {
            int passValue = _gameplayScore;
            _gameplayScore = 0;
            OnGameOvered?.Invoke(passValue,_bestScore);
        }

        public void LoadGameScene()
        {
            StartCoroutine(LoadGameSceneAsync());
        }

        private IEnumerator LoadGameSceneAsync()
        {
            //bu normal bir method'tur ve bu method calisipt bitmeden diger yapialr calismaz
            //SceneManager.LoadScene("Game");
            
            yield return SceneManager.LoadSceneAsync("Game"); //async await mantigi
        }

        #region Normal Method ile Asnyc ve Coroutine Methodlar arasindaki farklar

        public void Main()
        {
            Method1();
            Method2();
            Method1Async();
            //Method2Async(); Coroutine method'lar bu sekil calismaz
            StartCoroutine(Method2Async());
            Method3();
        }

        public IEnumerator Method2Async()
        {
            yield return null;
        }

        public async void Method1Async()
        {
            //process
            //process
            //process
            //process
            //process
            string value = await DataBaseProcessAsync();
            //value birseyler yapiyor 
        }

        public async Task<string> DataBaseProcessAsync()
        {
            return string.Empty;
        }

        public void Method1()
        {
            //process
            //process
            //process
            //process
            //process
        }
        
        public void Method2()
        {
            //process
            //process
            //process
            //process
            //process
        }
        
        public void Method3()
        {
            //process
            //process
            //process
            //process
            //process
        }

        #endregion
    }
}