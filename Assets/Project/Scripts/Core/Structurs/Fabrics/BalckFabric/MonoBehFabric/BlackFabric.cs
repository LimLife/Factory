using UnityEngine;
public class BlackFabric : Fabric
{
    [SerializeField] private GameObject Prefab;
    [SerializeField] private TextMesh _infoFabric;
    public new IExchange Exchange { get; private set; }
    public new IItem ProductItem => _product;


    [SerializeField] private BlackItem _product;

    public void Message(string mes)
    {
        if (mes == string.Empty)
            _infoFabric.gameObject.SetActive(false);
        else
        {
            _infoFabric.gameObject.SetActive(true);
            _infoFabric.text = mes;
        }
    }
    public void SetExchange(IExchange exchange)
    {
        Exchange = exchange;
    }
}

