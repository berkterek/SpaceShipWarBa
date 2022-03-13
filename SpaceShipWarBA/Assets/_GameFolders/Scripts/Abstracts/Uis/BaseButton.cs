using UnityEngine;
using UnityEngine.UI;

namespace SpaceShipWarBa.Abstracts.Uis
{
    public abstract class BaseButton : MonoBehaviour
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

        protected abstract void HandleOnButtonClicked();
    }
}