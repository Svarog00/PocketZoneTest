using Assets._Code.Interfaces;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Assets._Code.UI
{
    public class UI_Joystick : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler, IEndDragHandler, IInputService
    {
        [SerializeField] private Image _backgroundImage;
        [SerializeField] private Image _handle;
        [SerializeField] private float _moveBorder;

        private Vector3 _inputDirection;

        public Vector3 InputDirection => _inputDirection;

        public void OnDrag(PointerEventData eventData)
        {
            Vector2 offset = Vector2.zero;
            float backgroundSizeX = _backgroundImage.rectTransform.sizeDelta.x;
            float backgroundSizeY = _backgroundImage.rectTransform.sizeDelta.y;

            if (RectTransformUtility
                .ScreenPointToLocalPointInRectangle(_backgroundImage.rectTransform, eventData.position, null, out offset) == true)
            {
                offset.x /= backgroundSizeX;
                offset.y /= backgroundSizeY;
                _inputDirection = offset;
                _inputDirection = _inputDirection.magnitude > 1 ? _inputDirection.normalized : _inputDirection;

                _handle.rectTransform.anchoredPosition =
                    new Vector2(_inputDirection.x * (backgroundSizeX / _moveBorder), _inputDirection.y * (backgroundSizeY / _moveBorder));
            }
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            ResetJoysyick();
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            OnDrag(eventData);
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            ResetJoysyick();
        }
        private void ResetJoysyick()
        {
            _handle.transform.localPosition = Vector3.zero;
            _inputDirection = Vector3.zero;
        }

    }
}