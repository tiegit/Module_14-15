using UnityEngine;

public class CharacterInteraction : MonoBehaviour
{
    private ItemSetter _itemSetter;

    public void Initialize(ItemSetter itemSetter)
    {
        _itemSetter = itemSetter;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Item item))
        {
            _itemSetter.SetItem(item);
        }
    }
}
