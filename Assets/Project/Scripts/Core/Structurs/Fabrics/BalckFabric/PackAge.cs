using UnityEngine;
public class PackAge : MonoBehaviour,IInitialize
{
    public ProduceBlack Produse{ get; private set; } 
    [SerializeField] private RefeneseFabric _fabic;
   
    public void Initialize()
    {
        Produse = new ProduceBlack();
        Produse.Initialize(_fabic);
    }
}
