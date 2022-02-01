using System;
using UnityEngine;

public class ProduceBlack : Structure, IInitialize
{
    public event Action<TypeFabric> OnEnterToFabric;

    [SerializeField] private TextMesh _message;

    [SerializeField] private StorageResourses _resourses;

    [SerializeField] private FinishedStorage _finishedProduct;
    [SerializeField] private GameObject _showEnter;
    public override TypeFabric Fabric => _fabric;
    public ItemType Product => _product.ItemType;

    public int FinishProduct => _finishedProduct.CountProuduct(_fabric);
    private TypeFabric _fabric;
    private string _info;
    private readonly BlackItem _product;

    public void Initialize()
    {
        _fabric = TypeFabric.FabricTypeOne;
        _resourses.SetStorage(_fabric);
        _finishedProduct.SetStorage(_fabric);
        _finishedProduct.Initialize();
        _resourses.Initialize();
        _showEnter.gameObject.SetActive(false);
    }

    public override void Message(string massage, bool active)
    {
        if (active)
        {
            _message.text = massage;
        }
        else
        {
            _message.text = string.Empty;
        }
    }

    public override void Production()
    {
        if (_finishedProduct.IsFullFirtsItem == true)
        {
            _info = $"Производство остоновленно \n склад полн продуктом Black";
            Message(_info,true);
            return;
        }
        Message(_info,false);
        _finishedProduct.PutFabricProduct(_fabric);
    }

    public override void GetProduct()
    {
        if (_finishedProduct.IsEmptyFerstItem)
        {
            return;
        }
        _finishedProduct.IssueItem(_fabric);
    }


    private void OnTriggerEnter(Collider other)
    {
        var player = other.gameObject.GetComponent<Сollector>();
        if (player == true)
        {
            _showEnter.SetActive(true);
            OnEnterToFabric?.Invoke(_fabric);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        var player = other.gameObject.GetComponent<Сollector>();
        if (player == true)
        {
            _showEnter.SetActive(false);
        }
    }

    public override bool AddResourses()
    {
        return false;
    }
}