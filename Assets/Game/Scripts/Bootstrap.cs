using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private Character _character;
    [SerializeField] private float _health = 10f;
    [SerializeField] private float _moveSpeed = 6f;
    [SerializeField] private float _rotationSpeed = 10f;

    private PlayerInput _playerInput;
    private CharacterStats _characterStats;
    private Game _game;

    private void Awake()
    {
        _playerInput = new PlayerInput();
        _characterStats = new CharacterStats(_health, _moveSpeed, _rotationSpeed);

        _character.Initialize(_playerInput, _characterStats);

        _game = new Game(_playerInput, _character);
    }

    private void Update()
    {
        _playerInput.CustomUpdate();

        _game.CustomUpdate();
    }
}