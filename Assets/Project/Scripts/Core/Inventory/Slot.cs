using System;
using System.Collections.Generic;

public class Slot
{
    public IItem Item { get; private set; }
    public Type ItemType => Item.Type;
    public int CapacitySlot; // Config
    public int Amount => _items.Count;
    public bool IsFull => CapacitySlot == Amount;
    public bool IsEmpty => Amount == 0;

    private Stack<IItem> _items;
    public Slot(IItem item)
    {
        _items = new Stack<IItem>(CapacitySlot);
        Item = item;
    }
    public void Additem(IItem item)
    {
        _items.Push(item);
    }
    public IItem TakeItem() //return items
    {
        return  _items.Pop();
    }
}