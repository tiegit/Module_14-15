using UnityEngine;

public class CharacterStats
{
    private float _healthValue;
    private float _moveSpeed;
    private float _rotationSpeed;

    public CharacterStats(float health, float moveSpeed, float rotationSpeed)
    {
        CurrentHealth = _healthValue = health;
        CurrentMoveSpeed = _moveSpeed = moveSpeed;
        CurrentRotationSpeed = _rotationSpeed = rotationSpeed;
    }

    public float CurrentHealth { get; private set; }
    public float CurrentMoveSpeed { get; private set; }
    public float CurrentRotationSpeed { get; private set; }

    public void AddHealth(float amount)
    {
        CurrentHealth += amount;
        Debug.Log($"«доровье игрока обновилось и теперь составл€ет: {CurrentHealth}");
    }

    public void AddMoveSpeed(float amount)
    {
        CurrentRotationSpeed += amount;
        Debug.Log($"—корость игрока обновилось и теперь составл€ет: {CurrentRotationSpeed}");
    }

    public void Reset()
    {
        CurrentHealth = _healthValue;
        CurrentMoveSpeed = _moveSpeed;
        CurrentRotationSpeed = _rotationSpeed;
    }
}
