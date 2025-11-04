using UnityEngine;

public class InventoryItemSetter
{
    private Transform _itemHolder;
    private Inventory _inventory;

    public InventoryItemSetter(Transform itemHolder, Inventory inventory)
    {
        _itemHolder = itemHolder;
        _inventory = inventory;
    }

    public void SetItem(Item item)
    {
        if (_inventory.IsEmpty == false)
        {
            Debug.Log($"<color=yellow>Инвентарь полон, нужно воспользоваться ранее подобранным предметом. Для использования нажми F</color>");
            return;
        }

        item.transform.SetParent(_itemHolder);
        item.transform.localPosition = Vector3.zero;
        item.transform.localRotation = Quaternion.identity;

        _inventory.SetItem(item);

        Debug.Log($"<color=white>В инвентарь добавлен предмет типа {item.name}. Для использования нажми F</color>");
    }
}