using UnityEngine;

[RequireComponent (typeof(Rigidbody))]
public class ProjectileItem : Item
{
    [SerializeField] private float _projectileSpeed = 10f;
    [SerializeField] private float _projectileLifeTime = 3f;

    public override void Use(CharacterStats characterStats)
    {
        if (TryGetComponent(out Rigidbody rigidbody))
        {
            rigidbody.isKinematic = false;

            rigidbody.velocity = transform.forward * _projectileSpeed;
        }

        ApplyEffect();

        DestroyItem(_projectileLifeTime);
    }
}
