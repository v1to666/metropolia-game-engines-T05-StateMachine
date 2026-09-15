using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform _target;

    private float _followPositionSpeed = 3f;
    private float _followRotationSpeed = 3f;
    private Vector3 _offset = new Vector3(10f, 10f, 10f);

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        FollowPosition();
        LookAt();
    }

    private void FollowPosition()
    {
        Vector3 targetPosition = _target.position + _offset;

        transform.position = Vector3.Slerp(transform.position, targetPosition, _followPositionSpeed * Time.deltaTime);
    }

    private void LookAt()
    {
        Vector3 direction = _target.position - transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(direction);

        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, _followRotationSpeed * Time.deltaTime);
    }
}
