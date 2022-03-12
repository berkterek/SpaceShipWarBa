using System;
using SpaceShipWarBa.Managers;
using UnityEngine;
using UnityEngine.UI;

namespace SpaceShipWarBa.Uis
{
    public class PlayButton : MonoBehaviour
    {
        [SerializeField] Button _button;

        void Awake()
        {
            if (_button == null)
            {
                _button = GetComponent<Button>();    
            }
        }

        void OnEnable()
        {
            _button.onClick.AddListener(HandleOnButtonClicked);
        }

        void OnDisable()
        {
            _button.onClick.RemoveListener(HandleOnButtonClicked);
        }
        
        void HandleOnButtonClicked()
        {
            GameManager.Instance.LoadGameScene();
        }
    }    
}