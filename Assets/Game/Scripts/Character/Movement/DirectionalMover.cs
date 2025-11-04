using UnityEngine;

public class DirectionalMover
{
    private Rigidbody _rigidbody;
    private PlayerInput _playerInput;
    CharacterStats _characterStats;

    public DirectionalMover(PlayerInput playerInput, Rigidbody rigidbody, CharacterStats characterStats)
    {
        _playerInput = playerInput;
        _rigidbody = rigidbody;
        _characterStats = characterStats;
    }

    public void CustomFixedUpdate()
    {
        Vector3 direction = new Vector3(_playerInput.HorizontalInput, 0, _playerInput.VerticalInput);

        _rigidbody.velocity = direction.normalized * _characterStats.CurrentMoveSpeed;
    }
}
