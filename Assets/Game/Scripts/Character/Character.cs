using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(CharacterInteraction))]
public class Character : MonoBehaviour
{
    [SerializeField] private Transform _itemHolder;

    private Rigidbody _rigidbody;
    private CharacterInteraction _characterInteraction;

    private PlayerInput _playerInput;
    private CharacterStats _characterStats;

    private Vector3 _initialPosition;
    private Quaternion _initialRotation;

    private Inventory _inventory;
    private DirectionalMover _mover;
    private DirectionalRotator _rotator;

    public void Initialize(PlayerInput playerInput, CharacterStats characterStats)
    {
        _rigidbody = GetComponent<Rigidbody>();
        _characterInteraction = GetComponent<CharacterInteraction>();

        _playerInput = playerInput;
        _characterStats = characterStats;

        _initialPosition = transform.position;
        _initialRotation = transform.rotation;

        _inventory = new Inventory();

        InventoryItemSetter itemSetter = new InventoryItemSetter(transform, _itemHolder, _inventory);
        _characterInteraction.Initialize(itemSetter);

        _mover = new DirectionalMover(_playerInput, _rigidbody, _characterStats);
        _rotator = new DirectionalRotator(_playerInput, _rigidbody, _characterStats);
    }

    private void FixedUpdate()
    {
        _mover.CustomFixedUpdate();
        _rotator.CustomFixedUpdate(Time.deltaTime);
    }

    public void UseItem()
    {
        if (_inventory.IsEmpty)
            return;

        _inventory.UseCurrentItem(_characterStats);
    }

    public void Reset()
    {
        transform.position = _initialPosition;
        transform.rotation = _initialRotation;

        _inventory.ClearCurrentItem();
        _characterStats.Reset();
    }
}
