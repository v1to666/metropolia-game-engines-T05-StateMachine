using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Camera _mainCamera;

    private CharacterController _characterController;

    private float _speed = 10f;

    private InputSystem_Actions _inputConfig;
    private InputAction _moveAction;

    private Vector3 _targetDirection;

    private void Start()
    {
        _inputConfig = new InputSystem_Actions();
        _inputConfig.Enable();

        _moveAction = _inputConfig.Player.Move;

        _characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        Move();
        Look();
    }

    private void Move()
    {
        Vector2 moveDirection = _moveAction.ReadValue<Vector2>();

        _targetDirection = _mainCamera.transform.right * moveDirection.x + _mainCamera.transform.forward * moveDirection.y;
        _targetDirection.y = 0f;

        Vector3 targetVelocity = _targetDirection.normalized * _speed * Time.deltaTime;

        _characterController.Move(targetVelocity);
    }

    private void Look()
    {
        if (_targetDirection.sqrMagnitude > 0.01f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(_targetDirection);

            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 5f * Time.deltaTime);
        }
    }
}
