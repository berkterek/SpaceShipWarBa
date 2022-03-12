using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShipWarBa.ScriptableObjects
{
    [CreateAssetMenu(fileName = "New Two Int Event",menuName = "Bilge Adam/Events/Two Int Event")]
    public class TwoIntParametreEventHandlerSO : ScriptableObject
    {
        public event System.Action<int, int> OnTwoIntEvent;

        public void TwoIntEventHandler(int value1, int value2)
        {
            OnTwoIntEvent?.Invoke(value1,value2);
        }
    }    
}