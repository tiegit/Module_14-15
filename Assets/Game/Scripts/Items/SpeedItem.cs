using UnityEngine;

public class SpeedItem : Item
{
    [SerializeField] private float _speedIncrease = 2f;

    public override void Use(CharacterStats characterStats)
    {
        characterStats.AddMoveSpeed(_speedIncrease);
        ApplyEffectAndDestroy();
    }
}
