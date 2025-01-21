using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Core.UI
{
    public class JoystickController : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
    {
        [SerializeField]
        private Image _joystickBackground;
        [SerializeField]
        private Image _joystickHandle;

        private Vector3 _inputDirection;

        public void OnDrag(PointerEventData eventData)
        {
            Vector2 position;
            if (RectTransformUtility.ScreenPointToLocalPointInRectangle(_joystickBackground.rectTransform,
                                                                       eventData.position,
                                                                       eventData.pressEventCamera,
                                                                       out position))
            {
                position.x = (position.x / _joystickBackground.rectTransform.sizeDelta.x);
                position.y = (position.y / _joystickBackground.rectTransform.sizeDelta.y);

                float x = (_joystickBackground.rectTransform.pivot.x == 1) ? position.x * 2 + 1 : position.x * 2 - 1;
                float y = (_joystickBackground.rectTransform.pivot.y == 1) ? position.y * 2 + 1 : position.y * 2 - 1;

                _inputDirection = new Vector3(x, y, y); // Обновлено для компонентов x, y, z
                _inputDirection = (_inputDirection.magnitude > 1) ? _inputDirection.normalized : _inputDirection;

                _joystickHandle.rectTransform.anchoredPosition = new Vector3(_inputDirection.x * (_joystickBackground.rectTransform.sizeDelta.x / 3),
                                                                            _inputDirection.y * (_joystickBackground.rectTransform.sizeDelta.y / 3)); // Учтены компоненты x и y
            }
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            OnDrag(eventData);
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            _inputDirection = Vector3.zero;
            _joystickHandle.rectTransform.anchoredPosition = Vector3.zero;
        }

        // Метод для получения текущего ввода направления
        public Vector3 GetInputDirection()
        {
            return _inputDirection;
        }
    }
}
