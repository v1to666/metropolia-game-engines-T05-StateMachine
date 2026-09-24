using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponHolder : MonoBehaviour
{
    [SerializeField] private Weapon _weapon;

    private bool _inHands = false;

    private InputSystem_Actions _inputSystem;
    private InputAction _weaponAction;

    private void Awake()
    {
        _inputSystem = new InputSystem_Actions();
        _inputSystem.Enable();
        _weaponAction = _inputSystem.Player.Weapon;
    }

    private void Start()
    {
        Hide();
    }

    private void OnEnable()
    {
        _weaponAction.started += ctr => Toggle();
    }

    private void OnDisable()
    {
        _weaponAction.started -= ctr => Toggle();
    }

    private void Toggle()
    {
        if (_inHands)
        {
            Hide();
        }
        else
        {
            Show();
        }
    }

    private void Show()
    {
        _weapon.gameObject.SetActive(true);

        _inHands = true;
    }

    private void Hide()
    {
        _weapon.gameObject.SetActive(false);

        _inHands = false;
    }
}
