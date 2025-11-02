using UnityEngine;

public class DirectionalRotator
{
    private const float SensitivityLimit = 0.05f;

    private PlayerInput _playerInput;
    private Rigidbody _rigidbody;

    private float _rotationSpeed;

    public DirectionalRotator(PlayerInput playerInput, Rigidbody rigidbody, float rotationSpeed)
    {
        _playerInput = playerInput;
        _rigidbody = rigidbody;
        _rotationSpeed = rotationSpeed;
    }

    public void CustomFixedUpdate(float deltaTime)
    {
        Vector3 direction = new Vector3(_playerInput.HorizontalInput, 0, _playerInput.VerticalInput);

        if (direction.magnitude < SensitivityLimit)
            return;

        Vector3 targetDirection = direction.normalized;

        Quaternion targetRotation = Quaternion.LookRotation(targetDirection);

        float lerpFactor = Mathf.Clamp01(_rotationSpeed * deltaTime);
        Quaternion newRotation = Quaternion.Slerp(_rigidbody.transform.rotation, targetRotation, lerpFactor);

        _rigidbody.MoveRotation(newRotation);
    }
}
