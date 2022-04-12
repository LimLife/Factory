using UnityEngine;

public class PlayerContainer : MonoBehaviour
{
    public IExchange Exchange { get; private set; }

    [SerializeField] private GameObject Prefab;

    public void SetExchange(IExchange exchange)
    {
        Exchange = exchange;
    }

    private void OnTriggerEnter(Collider other)
    {
        var fabric = other.GetComponent<Fabric>(); // кеш фабрики
        var item = fabric.ProductItem; // кеш предмета
        if (other == fabric)
        {
            var tryadd = Exchange.TryAdd(item);
            if (tryadd && fabric.Exchange.TryTake(item)) // есть ли место или есть ли предметы
                Exchange.TryGiveItem(fabric.Exchange.TryGetItem());// добовляем в инвентарь по типу из фабрики  
        }
    }
}
