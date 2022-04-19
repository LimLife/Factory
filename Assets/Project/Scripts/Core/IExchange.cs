using System;
public interface IExchange
{
    IItem TryGetItem();
    void TryGiveItem(IItem item);
    bool TryAdd(ItemsType item);
    bool TryTake(ItemsType item);
}