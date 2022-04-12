using BlackFabricStorage;
using UnityEngine;
public class ProduceBlack : IInitFabric, ISystemUpDate, IExchange,IStructure
{
    private BlackStorageFinifshProduct _blackfinish;
    private RefeneseFabric _blackFabric;
    #region ProduseItem
    private BlackItem _product;
    #endregion

    private float _repitTime => _config.TimeProduse;
    private float _second = 0;
    private float _timeRemainder;

    private ConfigFabric _config;
    public void Initialize(RefeneseFabric list)
    {
        _blackfinish = new BlackStorageFinifshProduct();
        _config = list.Config;
        _timeRemainder = _repitTime;
        _blackFabric = list;
        list.FabricBlack.SetExchange(this);// controller <=> model
        _blackfinish.SetView(
                             list.StorageBlack.StorageProduct,
                             list.StorageBlack.Config); //controller => controller <=> model
    }
    public void GiveProduct()
    {
        if (_blackfinish.IsFull)
        {
            Message("Производство остоновленно из-за перепроизводства");
            return;
        }
        _blackfinish.GiveProduct(_product);
        // Future will evry item have be value for production
    }
    public IItem GetProduct()
    {
        return null; // 
    }
    public void Produce()
    {
        GiveProduct();
    }
    public void Execute()
    {
        Timer();
    }

    private void Timer()
    {
        var deltaTime = Time.deltaTime;
        _second += deltaTime;

        if (_second >= 1f)
        {
            _second -= 1;
            _timeRemainder -= 1;
        }
        if (_timeRemainder <= 0)
        {
            Produce();
            _timeRemainder = _repitTime;
        }      
    }

    public IItem TryGetItem()
    {
        return _blackfinish.GetItem();
    }
    public void TryGiveItem(IItem item)
    {
        return;// empty resourses, don`t adding
    }
    public bool TryAdd(IItem item)
    {
        return false; // all time false
    }
    public bool TryTake(IItem item)
    {
        if (!_blackfinish.IsEmpty)
            return true;

        return false;
    }

    private void Message(string msg)
    {
        _blackFabric.FabricBlack.Message(msg);
    }
}