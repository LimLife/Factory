using UnityEngine;
using ProductProduce;
public class RedFactory : Factory
{
    [SerializeField] private GameObject Prefab;
    [SerializeField] private TextMesh _info;
    public override IExchange Exchange => _exchange;
    public override ItemsType ProductItem => ItemsType.Red;

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
        var inventory = player.Exchange.TryTake(ItemsType.Black);

        if (tryadd && inventory)
            Exchange.TryGiveItem(player.Exchange.TryGetItem());

    }
}
