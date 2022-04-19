using UnityEngine;

public class Factory : MonoBehaviour
{
    public virtual IExchange Exchange { get; private set; }
     
    public virtual ItemsType ProductItem { get; private set; }
}

