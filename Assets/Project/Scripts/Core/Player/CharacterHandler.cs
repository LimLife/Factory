public class CharacterHandler : IExchange
{
    private Inventory _inventory;
    private IItem _temp;

    public void Initialize(ConfigInventory config, Сollector сollector)
    {
        _inventory = new Inventory(config);
        сollector.Initialie(this);
    }

    
    public IItem TryGetItem()
    {
        return _inventory.TryTakeItem(_temp);
    }
    public void TryGiveItem(IItem item)
    {
        var slot = _inventory._slots.Find(s => s.ItemType == item.Type);
        slot.Additem(item);
    }
    public bool TryAdd(IItem item)
    {
        UnityEngine.Debug.Log(item);
        var slot = _inventory._slots.Find(s => s.ItemType == item.Type);
        if (!slot.IsFull)
            _temp = slot.Item;

        return false;
    }
    public bool TryTake(IItem item)
    {
        var slot = _inventory._slots.Find(s => s.ItemType == item.Type);
        if (!slot.IsEmpty)
            _temp = slot.Item;

        return false;
    }
}
