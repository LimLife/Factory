using UnityEngine;

public class RedPackage : MonoBehaviour,IInitialize
{
    public ProduceRed Produse { get; private set; }
    [SerializeField] private RefereneseRedFabric _redFabric;
    public void Initialize()
    {
        Produse = new ProduceRed();
        Produse.Inititalize(_redFabric);
    }

}
