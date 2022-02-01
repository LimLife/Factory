using System;
using UnityEngine;

public class ProduceGreen : Structure, IInitialize
{
    public event Action<TypeFabric> OnEnterToFabric;

    [SerializeField] private TextMesh _message;
    [SerializeField] private StorageResourses _resourses;
    [SerializeField] private FinishedStorage _finishedProduct;
    [SerializeField] private GameObject _showEnter;
    public override TypeFabric Fabric => _fabric;
    public ItemType Product => _product.ItemType;

    public int FreePlaceBlackResourses => _resourses.RemainigCamacityBlack;
    public int FreePlaceRedResourses => _resourses.RemainigCamacityRed;


    public int FinishProduct => _finishedProduct.CountProuduct(_fabric);
    private TypeFabric _fabric;

    private readonly GreenItem _product;
    private string _info;

    public void Initialize()
    {
        _fabric = TypeFabric.FabricTypeThree;
        _resourses.SetStorage(_fabric);
        _finishedProduct.SetStorage(_fabric);
        _finishedProduct.Initialize();
        _resourses.Initialize();
        _showEnter.gameObject.SetActive(false);
    }

    public override bool AddResourses()
    {
        _resourses.PutItem(_fabric);
        return false;
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
        if (_resourses.IsEmptyFerstItem == true || _resourses.IsEmptySecondItem == true)
        {
            _info = $"Производство остоновленно \n на складе отсутствует продукт :Black или Red ";
            Message(_info,true);
            return;
        }
        else
        {
            _resourses.IssueItem(_fabric);
        }
        if (_finishedProduct.IsFullThirdItem)
        {
            string msg = $"Производство остоновленно \n склад полн продуктом Green";
            Message(msg,true);
            return;
        }
        else
            _finishedProduct.PutFabricProduct(_fabric);
        Message(_info, false);
    }
    public override void GetProduct()
    {

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
