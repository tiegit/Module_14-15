public class Inventory
{
    private Item _currentItem;

    public bool IsEmpty
    {
        get
        {
            if (_currentItem == null)
                return true;

            if (_currentItem.gameObject == null)
                return true;

            return false;
        }
    }

    public void SetItem(Item item) => _currentItem = item;

    public void UseCurrentItem(CharacterStats characterStats)
    {
        _currentItem.Use(characterStats);

        ClearCurrentItem();
    }

    public void ClearCurrentItem() => _currentItem = null;
}