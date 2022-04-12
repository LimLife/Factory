using UnityEngine;

public class RedFabric : Fabric
{
    public new IExchange Exchange { get; private set; }
    public new IItem ProductItem => _product;

    [SerializeField] private TextMesh _info;
    private readonly BlackItem _black; // error ref exep

    [SerializeField] private GameObject Prefab;

    private BlackItem _product;

    public void SetExchange(IExchange exchange)
    {
        Exchange = exchange;
    }
    public void Message(string msg)
    {
        _info.text = msg;
    }
    private void OnTriggerEnter(Collider other)
    {
        var player = other.GetComponent<Сollector>(); // кеш фабрики       
        if (other == player)
        {
            var tryadd = Exchange.TryAdd(_black);
            if (tryadd && player.Exchange.TryTake(_black)) // есть ли место или есть ли предметы
                Exchange.TryGiveItem(player.Exchange.TryGetItem());// добовляем в инвентарь по типу из фабрики  
        }
    }
}
