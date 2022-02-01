using System.Collections.Generic;
using UnityEngine;

public abstract class Player : MonoBehaviour
{
    public abstract int Capacity { get; protected set; }

    protected abstract Stack<BlackItem> _blackItem { get; set; }
    protected abstract Stack<RedItem> _redItem { get; set; }
    protected abstract Stack<GreenItem> _greenItem { get; set; }
    public abstract void AddItem(ItemType item);
    public abstract void DeliveryItme(ItemType item);

}
