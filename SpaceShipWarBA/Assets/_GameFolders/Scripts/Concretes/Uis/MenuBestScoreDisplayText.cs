using SpaceShipWarBa.Managers;
using TMPro;
using UnityEngine;

namespace SpaceShipWarBa.Uis
{
    public class MenuBestScoreDisplayText : MonoBehaviour
    {
        TMP_Text _bestScoreText;

        void Awake()
        {
            if (_bestScoreText == null)
            {
                _bestScoreText = GetComponent<TMP_Text>();
            }
        }

        void Start()
        {
            _bestScoreText.text = GameManager.Instance.BestScore.ToString();
        }
    }    
}

