using UnityEngine;
public class BlackFactory : Factory
{
    [SerializeField] private GameObject Prefab;
    [SerializeField] private TextMesh _info; // сделать отделтную сущность FabricInfo.cs
    public override IExchange Exchange => _exchange;
    public override ItemsType ProductItem => ItemsType.Black;

    private IExchange _exchange; 
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
    public void Initialize(IExchange exchange)
    {
        _exchange = exchange;
    }   
}

