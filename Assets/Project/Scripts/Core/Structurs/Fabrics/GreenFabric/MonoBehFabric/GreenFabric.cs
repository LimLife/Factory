using UnityEngine;

public class GreenFabric : Fabric
{
    public new IExchange Exchange { get; }

    [SerializeField] private GameObject Prefab;
    [SerializeField] private TextMesh _info;

    private readonly BlackItem _black;
    private readonly RedItem _red;

    public void Message(string msg)
    {
        _info.text = msg;
    }
    private void OnTriggerEnter(Collider other)
    {      
        var player = other.GetComponent<Сollector>();
        if (other == player)
        {
            var tryadd = Exchange.TryAdd(_black);
            if (tryadd)
                if (tryadd && player.Exchange.TryTake(_black)) // есть ли место или есть ли предметы
                    Exchange.TryGiveItem(player.Exchange.TryGetItem());// добовляем в инвентарь по типу из фабрики  

            var tryadds = Exchange.TryAdd(_red);
            if (tryadds)
                if (tryadds && player.Exchange.TryTake(_red)) // есть ли место или есть ли предметы
                    Exchange.TryGiveItem(player.Exchange.TryGetItem());// добовляем в инвентарь по типу из фабрики  
        }
    }
}
