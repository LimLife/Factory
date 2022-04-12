using UnityEngine;

public class Fabric : MonoBehaviour
{
    public IExchange Exchange { get; }

    public IItem ProductItem { get; private set; }
}

