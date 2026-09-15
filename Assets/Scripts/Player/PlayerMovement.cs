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
    }

    private void Move()
    {
        Vector2 moveDirection = _moveAction.ReadValue<Vector2>();

        Vector3 targetDirection = _mainCamera.transform.right * moveDirection.x + _mainCamera.transform.forward * moveDirection.y;
        targetDirection.y = 0f;

        Vector3 targetVelocity = targetDirection.normalized * _speed * Time.deltaTime;

        _characterController.Move(targetVelocity);
    }
}
