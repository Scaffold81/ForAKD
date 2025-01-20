using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace Core.Player
{
    public class PlayerView : MonoBehaviour
    {
        [Inject]
        private CharacterController _characterController;

        [SerializeField]
        private GameObject _body;
        [SerializeField]
        private GameObject _head;

        [SerializeField]
        private float _bodyRotationSpeed = 2f;
        [SerializeField]
        private float _headRotationSpeed = 1f;
        [SerializeField]
        private float _speed = 5f;

        private Vector2 _lookInput;
        private float _direction;

        private void Update()
        {
            LookAndRotate();
            Move();
        }

        private void Move()
        {
            _characterController.Move(_body.transform.forward * _direction * _speed * Time.deltaTime);
        }

        private void LookAndRotate()
        {
            var lookDelta = Mouse.current.delta.ReadValue();

            // Поворот тела по горизонтали
            _body.transform.Rotate(new Vector3(0, lookDelta.x * _bodyRotationSpeed * Time.deltaTime, 0));

            //поворот камеры по вертикали
            _head.transform.Rotate(new Vector3(-lookDelta.y * _headRotationSpeed * Time.deltaTime, 0, 0));
        }

        public void MoveInput(InputAction.CallbackContext context)
        {
            _direction = context.ReadValue<Vector2>().y;
        }
    }
}
