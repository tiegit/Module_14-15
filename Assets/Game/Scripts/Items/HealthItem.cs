using UnityEngine;

public class HealthItem : Item
{
    [SerializeField] private float _healthIncrease = 20f;

    public override void Use(CharacterStats characterStats)
    {
        characterStats.AddHealth(_healthIncrease);

        ApplyEffect();

        DestroyItem();
    }
}
