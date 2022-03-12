using System;
using SpaceShipWarBa.Managers;
using TMPro;
using UnityEngine;

namespace SpaceShipWarBa.Uis
{
    public class DisplayScoreText : MonoBehaviour
    {
        [SerializeField] TMP_Text _scoreText;

        void Awake()
        {
            if (_scoreText == null)
            {
                _scoreText = GetComponent<TMP_Text>();    
            }
        }

        void Start()
        {
            _scoreText.text = GameManager.Instance.GameplayScore.ToString();
        }

        void OnEnable()
        {
            if (GameManager.Instance == null) return;
            GameManager.Instance.OnScoreChanged += HandleOnScoreChanged;
        }

        void OnDisable()
        {
            if (GameManager.Instance == null) return;
            GameManager.Instance.OnScoreChanged -= HandleOnScoreChanged;
        }
        
        void HandleOnScoreChanged(int gameplayScore)
        {
            _scoreText.text = gameplayScore.ToString();
        }
    }    
}