using UnityEngine;

public class CharacterInteraction : MonoBehaviour
{
    private InventoryItemSetter _itemSetter;

    public void Initialize(InventoryItemSetter itemSetter)
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
