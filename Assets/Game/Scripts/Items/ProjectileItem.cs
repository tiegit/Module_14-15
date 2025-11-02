using UnityEngine;

public class ProjectileItem : Item
{
    private const float _projectileSpeed = 10f;
    [SerializeField] private GameObject _projectilePrefab;

    public override void Use(CharacterStats characterStats)
    {
        GameObject projectile = Instantiate(_projectilePrefab, transform.position, Quaternion.identity);

        Rigidbody rigidbody = projectile.GetComponent<Rigidbody>();

        if (rigidbody != null)
            rigidbody.velocity = transform.forward * _projectileSpeed;

        ApplyEffectAndDestroy();
    }
}
