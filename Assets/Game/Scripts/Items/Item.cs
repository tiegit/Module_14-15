using UnityEngine;

public abstract class Item : MonoBehaviour
{
    [SerializeField] private GameObject _topParticlePrefab;
    [SerializeField] private Transform _topParticleSpawnpoint;

    [SerializeField, Space(10)] private GameObject _bottomParticlePrefab;

    protected Transform CharacterTransform;

    public abstract void Use(CharacterStats characterStats);

    public void Initialize(Transform characterTransform, Transform itemHolder)
    {
        CharacterTransform = characterTransform;

        transform.SetParent(itemHolder);
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;
    }

    protected void ApplyEffect()
    {
        if (_topParticlePrefab != null)
            Instantiate(_topParticlePrefab, _topParticleSpawnpoint.position, Quaternion.identity, CharacterTransform);

        if (_bottomParticlePrefab != null)
            Instantiate(_bottomParticlePrefab, CharacterTransform.position, Quaternion.identity, CharacterTransform);
    }

    protected void DestroyItem(float delay = 0) => Destroy(gameObject, delay);
}
