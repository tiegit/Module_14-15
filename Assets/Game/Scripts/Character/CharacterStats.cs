using UnityEngine;

public class CharacterStats
{
    private const string StatNameHealth = "Здоровье";
    private const string StatNameSpeed = "Скорость движения";
    private const string HealthColor = "green";
    private const string SpeedColor = "cyan";

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

    public void AddHealth(float amount) => CurrentHealth = AddToStat(CurrentHealth, amount, StatNameHealth, HealthColor);

    public void AddMoveSpeed(float amount) => CurrentMoveSpeed = AddToStat(CurrentMoveSpeed, amount, StatNameSpeed, SpeedColor);

    private float AddToStat(float currentValue, float amount, string statName, string color)
    {
        if (amount < 0)
        {
            Debug.LogWarning($"Попытка добавить отрицательное {statName.ToLower()}.");

            return currentValue;
        }

        float newValue = currentValue + amount;

        Debug.Log($"<color={color}>Характеристика \"{statName}\" игрока обновилась и теперь составляет: {newValue}</color>");

        return newValue;
    }

    public void Reset()
    {
        CurrentHealth = _healthValue;
        CurrentMoveSpeed = _moveSpeed;
        CurrentRotationSpeed = _rotationSpeed;
    }
}
