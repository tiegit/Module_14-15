using UnityEngine;

public abstract class Item : MonoBehaviour
{
    [SerializeField] private GameObject _particlePrefab;

    public abstract void Use(CharacterStats characterStats);

    protected void ApplyEffectAndDestroy()
    {
        if (_particlePrefab != null)
            Instantiate(_particlePrefab, transform.position, Quaternion.identity);

        Destroy(gameObject);
    }
}
