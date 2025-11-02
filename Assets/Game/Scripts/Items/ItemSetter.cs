using UnityEngine;

public class ItemSetter
{
    private Transform _itemHolder;
    private Inventory _inventory;

    public ItemSetter(Transform itemHolder, Inventory inventory)
    {
        _itemHolder = itemHolder;
        _inventory = inventory;
    }

    public void SetItem(Item item)
    {
        if (_inventory.CurrentItem != null)
        {
            Debug.Log($"Инвентарь полон, нужно воспользоваться ранее подобранным предметом. Для использования нажми F");
            return;
        }

        item.transform.SetParent(_itemHolder);
        item.transform.localPosition = Vector3.zero;
        item.transform.localRotation = Quaternion.identity;

        _inventory.SetItem(item);
    }
}
