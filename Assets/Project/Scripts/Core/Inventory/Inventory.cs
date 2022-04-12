using System.Collections.Generic;
public class Inventory
{
    private IItem[] ItemsType=>_config.Items().ToArray();
    public List<Slot> _slots { get; private set; }

    private ConfigInventory _config;
    public Inventory(ConfigInventory config)
    {
        _config = config;
        _slots = new List<Slot>();

        for (int i = 0; i < ItemsType.Length; i++)
        {
            _slots.Add(new Slot(ItemsType[i]));
        }
    }
   
    public bool TryAddItem(IItem item)
    {
        var typeSlot = _slots.Find(slot => slot.ItemType == item.Type);
        if (!typeSlot.IsFull)
            typeSlot.Additem(item);

        return false;
    }
    public IItem TryTakeItem(IItem item)
    {
        var typeSlot = _slots.Find(slot => slot.ItemType == item.Type);
        return typeSlot.TakeItem();
    }
}
