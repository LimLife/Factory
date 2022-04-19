using UnityEngine;

public class GreenPackage : MonoBehaviour,IInitialize
{
    public ProduceGreen Produse { get; private set; }
    [SerializeField] private ReferenceGreenFabric _fabric;

    public void Initialize()
    {
        Produse = new ProduceGreen();
        Produse.Initialize(_fabric);
    }
}
