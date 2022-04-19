using UnityEngine;

public class GreenFactory : Factory
{
    [SerializeField] private GameObject Prefab;
    [SerializeField] private TextMesh _info;

    public override IExchange Exchange => _exchange;
    public override ItemsType ProductItem => ItemsType.Green;

    private IExchange _exchange;

    public void SetExchange(IExchange exchange)
    {
        _exchange = exchange;
    }
    public void Message(string msg)
    {
        if (msg == string.Empty)
            _info.gameObject.SetActive(false);
        else
        {
            _info.gameObject.SetActive(true);
            _info.text = msg;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        var player = other.GetComponent<Сollector>();

        var tryadd = Exchange.TryAdd(ItemsType.Black);
        var invet = player.Exchange.TryTake(ItemsType.Black);

        if (tryadd && invet)
            Exchange.TryGiveItem(player.Exchange.TryGetItem());

        var tryadds = Exchange.TryAdd(ItemsType.Red);
        var invettwo = player.Exchange.TryTake(ItemsType.Red);

        if (tryadds && invettwo)
            Exchange.TryGiveItem(player.Exchange.TryGetItem());
    }
}
