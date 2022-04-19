using ProductProduce;
public class CharacterHandler : IExchange
{
    private Inventory _inventory;
    private UIInventory _ui;
    private Slot _temp;

    public void Initialize(ConfigInventory config, Сollector сollector)
    {
        _inventory = new Inventory(config);
        сollector.Initialie(this);
    }

    public void ForUI(UIInventory uI)
    {
        _ui = uI;
    }
    public IItem TryGetItem()
    {
        var item = _temp.TakeItem();
        _ui.RefreshUI(_temp);
        return item;
    }
    public void TryGiveItem(IItem item)
    {
        _temp.Additem(item);
        _ui.RefreshUI(_temp);
    }
    public bool TryAdd(ItemsType item)
    {
        var slot = _inventory.Slots.Find(s => s.Type == item || s.IsSlotEmpty);
        if (slot.IsFull)
        {
            return false;
        }
        _temp = slot;
        _temp.SetItem(item);
        return true;
    }
    public bool TryTake(ItemsType item)
    {
        var slot = _inventory.Slots.Find(s => s.Type == item && !s.IsEmpty);
        if (slot != null)
        {
            _temp = slot;
            return true;
        }
        return false;
    }
}
