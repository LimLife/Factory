using System;
using UnityEngine;

public class ProduceRed : Structure, IInitialize
{
    public event Action<TypeFabric> OnEnterToFabric;
    [SerializeField] private TextMesh _message;
    [SerializeField] private StorageResourses _resourses;
    [SerializeField] private FinishedStorage _finishedProduct;
    [SerializeField] private GameObject _showEnter;
    public override TypeFabric Fabric => _fabric;
    public ItemType Product => _product.ItemType;
    public int FinishProduct => _finishedProduct.CountProuduct(_fabric);
    public int FreePlaceBlackResourses => _resourses.RemainigCamacityBlack;

    private TypeFabric _fabric;
    private readonly RedItem _product;
    private string _info;
    public void Initialize()
    {
        _fabric = TypeFabric.FabricTypeTwo;
        _finishedProduct.SetStorage(_fabric);
        _resourses.SetStorage(_fabric);
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
        if (_resourses.IsEmptyFerstItem == true)
        {
             _info = $"Производство остоновленно \n на складе отсутствует продукт Black";
            Message(_info,true);
            return;
        }
        else
        {
            _resourses.IssueItem(_fabric);
        }
        if (_finishedProduct.IsFullSecondItem == true)
        {
            string msg = $"Производство остоновленно \n склад полн продуктом Red";
            Message(msg,true);
            ;
            return;
        }
        Message(_info, false);
        _finishedProduct.PutFabricProduct(_fabric);
    }
    public override bool AddResourses()
    {
        if (!_resourses.IsFullFirtsItem)
        {
            _resourses.PutItem(_fabric);
            return true;
        }
        else
            return false;
    }

    public override void GetProduct()
    {
        if (_finishedProduct.IsEmptySecondItem)
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
            _showEnter.gameObject.SetActive(true);
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

}
