using UnityEngine;

public abstract class Item : MonoBehaviour
{
    [SerializeField] private GameObject _particlePrefab;

    public abstract void Use(CharacterStats characterStats);

    protected virtual void DestroyItem(float delay = 0) => Destroy(gameObject, delay);

    public void ApplyEffect()
    {
        if (_particlePrefab != null)
            Instantiate(_particlePrefab, transform.position, Quaternion.identity);
    }
}
