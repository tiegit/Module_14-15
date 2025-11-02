public class Inventory
{
    public Item CurrentItem { get; private set; }

    public void SetItem(Item item) => CurrentItem = item;

    public void Reset() => CurrentItem = null;
}