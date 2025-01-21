using Core.UI;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace Core.Player
{
    public class PlayerView : MonoBehaviour
    {
        [Inject]
        private CharacterController _characterController;
        [Inject]
        private JoystickControllerMove _movementJoystick; // �������� ��� �������� ������/�����
        [Inject]
        private JoystickControllerRotate _rotationJoystick; // ����� �������� ��� �������� �����/������

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
            MoveWithJoystick();
            RotateWithJoystick();
        }

        private void MoveWithJoystick()
        {
            var inputDirection = _movementJoystick.GetInputDirection();
            _direction = inputDirection.z; // ����������� ��� Z ��� �������� ������/�����, ���� ��� ������������� ������ ���������
            _characterController.Move(_body.transform.forward * _direction * _speed * Time.deltaTime);
        }

        private void RotateWithJoystick()
        {
            var rotationInput = _rotationJoystick.GetInputDirection();
            // ������� ���� �� �����������
            _body.transform.Rotate(new Vector3(0, rotationInput.x * _bodyRotationSpeed * Time.deltaTime, 0));
            // ������� ������ �� ���������
            _head.transform.Rotate(new Vector3(-rotationInput.y * _headRotationSpeed * Time.deltaTime, 0,  0));
        }
    }
}
