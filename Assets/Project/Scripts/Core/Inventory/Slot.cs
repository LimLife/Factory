using ProductProduce;
using System.Collections.Generic;
public class Slot
{
    public IItem Item { get; private set; }
    public ItemsType Type { get; private set; }    
    public bool IsFull => Amount >= _capacitySlot;
    public bool IsEmpty => _items.Count == 0;
    public bool IsSlotEmpty => Item == null;
    public int Amount => _items.Count;

    private readonly int _capacitySlot;

    private readonly Stack<IItem> _items;
    public Slot(ConfigInventory config)
    {
        _capacitySlot = config.CapacitySlot;
        _items = new Stack<IItem>(_capacitySlot);
    }
    public void SetItem(ItemsType item)
    {
        Type = item;
    }
    public void Additem(IItem item)
    {
        _items.Push(item);
    }
    public IItem TakeItem()
    {
       return _items.Pop();          
    }
}