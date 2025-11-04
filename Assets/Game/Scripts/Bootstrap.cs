using System.Collections.Generic;
using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private Character _character;
    [SerializeField] private float _health = 10f;
    [SerializeField] private float _moveSpeed = 6f;
    [SerializeField] private float _rotationSpeed = 10f;

    [SerializeField, Space(15)] private ItemSpawner _itemSpawner;
    [SerializeField] private List<SpawnPoint> _itemSpawnPoints;
    [SerializeField] private List<Item> _itemPrefabs;
    [SerializeField] private float _cooldown;

    private PlayerInput _playerInput;
    private CharacterStats _characterStats;
    private Game _game;

    private void Awake()
    {
        _playerInput = new PlayerInput();
        _characterStats = new CharacterStats(_health, _moveSpeed, _rotationSpeed);

        _character.Initialize(_playerInput, _characterStats);

        _itemSpawner.Initialize(_itemSpawnPoints, _itemPrefabs, _cooldown);

        _game = new Game(_playerInput, _character);
    }

    private void Update()
    {
        _playerInput.CustomUpdate();

        _game.CustomUpdate();
    }
}