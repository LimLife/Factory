using System;
public interface IExchange
{
    IItem TryGetItem();
    void TryGiveItem(IItem item);
    bool TryAdd(IItem item);
    bool TryTake(IItem item);
}