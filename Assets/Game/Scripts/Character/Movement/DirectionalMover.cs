using UnityEngine;

public class DirectionalMover
{
    private const float SensitivityLimit = 0.05f;

    private Rigidbody _rigidbody;
    private PlayerInput _playerInput;

    private float _movementSpeed;

    public DirectionalMover(PlayerInput playerInput, Rigidbody rigidbody, float movementSpeed)
    {
        _playerInput = playerInput;
        _rigidbody = rigidbody;
        _movementSpeed = movementSpeed;
    }

    public void CustomFixedUpdate()
    {
        Vector3 direction = new Vector3(_playerInput.HorizontalInput, 0, _playerInput.VerticalInput);

        _rigidbody.velocity = direction.normalized * _movementSpeed;
    }
}
