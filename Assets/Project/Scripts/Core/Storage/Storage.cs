using System.Collections.Generic;
using UnityEngine;

public abstract class Storage : MonoBehaviour
{
    public virtual void PutItem(TypeFabric fabric)
    {

    }
    public virtual void PutFabricProduct(TypeFabric type)
    {

    }
    public abstract void IssueItem(TypeFabric type);

    protected abstract Stack<BlackItem> _blackItems { get; set; }
    protected abstract Stack<RedItem> _redItems { get; set; }
    protected abstract Stack<GreenItem> _greenItems { get; set; }

}
