using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

namespace TMS.UI
{
    public class VirtualJoystick : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
    {
        [SerializeField] private RectTransform _joystickBackground;
        [SerializeField] private RectTransform _joystickHandle;
        [SerializeField] private float handleRange = 50f;
        [SerializeField] private GameObject _joystick;

        private Vector2 _downPosition;
        private Vector2 inputVector = Vector2.zero;

        public Vector2 InputVector => inputVector;

        public void OnPointerDown(PointerEventData eventData)
        {
            OnDrag(eventData);
            _joystick.SetActive(true);
            _downPosition = eventData.position;
        }

        public void OnDrag(PointerEventData eventData)
        {
            var localPoint = eventData.position - _downPosition;
            Vector2 clamped = Vector2.ClampMagnitude(localPoint, handleRange);
            _joystickHandle.position = clamped + _downPosition;

            inputVector = clamped / handleRange;
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            inputVector = Vector2.zero;
            _joystick.SetActive(false);
        }
    }
}