using SpaceShipWarBa.Controllers;
using SpaceShipWarBa.ScriptableObjects;
using UnityEngine;
using UnityEngine.UI;

namespace SpaceShipWarBa.Uis
{
    public class DisplayHealthImage : MonoBehaviour
    {
        [SerializeField] TwoIntParametreEventHandlerSO _eventHandler;
        
        Image _healthImage;
        
        void Awake()
        {
            _healthImage = GetComponent<Image>();
        }

        void OnEnable()
        {
            _eventHandler.OnTwoIntEvent += HandleOnTookDamage;
        }

        void OnDisable()
        {
            _eventHandler.OnTwoIntEvent -= HandleOnTookDamage;
        }
        
        void HandleOnTookDamage(int currentHealth, int maxHealth)
        {
            float currentValue = (float)currentHealth / (float)maxHealth;
            _healthImage.fillAmount = currentValue;
        }
    }    
}

