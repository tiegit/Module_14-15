using UnityEngine;

public class DirectionalRotator
{
    private const float SensitivityLimit = 0.05f;

    private PlayerInput _playerInput;
    private Rigidbody _rigidbody;
    CharacterStats _characterStats;

    public DirectionalRotator(PlayerInput playerInput, Rigidbody rigidbody, CharacterStats characterStats)
    {
        _playerInput = playerInput;
        _rigidbody = rigidbody;
        _characterStats = characterStats;
    }

    public void CustomFixedUpdate(float deltaTime)
    {
        Vector3 direction = new Vector3(_playerInput.HorizontalInput, 0, _playerInput.VerticalInput);

        if (direction.magnitude < SensitivityLimit)
            return;

        Vector3 targetDirection = direction.normalized;

        Quaternion targetRotation = Quaternion.LookRotation(targetDirection);

        float lerpFactor = Mathf.Clamp01(_characterStats.CurrentRotationSpeed * deltaTime);
        Quaternion newRotation = Quaternion.Slerp(_rigidbody.transform.rotation, targetRotation, lerpFactor);

        _rigidbody.MoveRotation(newRotation);
    }
}
