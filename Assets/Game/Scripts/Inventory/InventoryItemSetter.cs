using UnityEngine;

public class InventoryItemSetter
{
    private Transform _characterTransform;
    private Transform _itemHolder;
    private Inventory _inventory;

    public InventoryItemSetter(Transform characterTransform, Transform itemHolder, Inventory inventory)
    {
        _characterTransform = characterTransform;
        _itemHolder = itemHolder;
        _inventory = inventory;
    }

    public void SetItem(Item item)
    {
        if (_inventory.IsEmpty == false)
        {
            Debug.Log($"<color=orange>Инвентарь полон, нужно воспользоваться ранее подобранным предметом. Для использования нажми F</color>");
            return;
        }

        item.Initialize(_characterTransform, _itemHolder);

        _inventory.SetItem(item);

        Debug.Log($"<color=white>В инвентарь добавлен предмет типа {item.GetType().Name}. Для использования нажми F</color>");
    }
}