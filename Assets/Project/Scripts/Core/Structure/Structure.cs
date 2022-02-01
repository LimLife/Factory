using UnityEngine;

public abstract class Structure : MonoBehaviour
{
    public abstract TypeFabric Fabric { get; }


    public abstract void Message(string message,bool active);
    public virtual void Production()
    {

    }

    public abstract void GetProduct();
    public abstract bool AddResourses();
    
    protected virtual void GetResources()
    {

    }

}
