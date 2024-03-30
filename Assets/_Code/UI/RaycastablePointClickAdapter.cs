using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.Events;
using System;

namespace LN.MegaRunner.UI.Utilities
{
    public class RaycastablePointClickAdapter : MonoBehaviour, IPointerClickHandler
    {
        public UnityEvent ClickEvent;

        public void OnPointerClick(PointerEventData eventData)
        {
            ClickEvent?.Invoke();
        }
    }
}

