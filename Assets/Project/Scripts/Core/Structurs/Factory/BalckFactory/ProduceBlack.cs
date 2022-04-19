using BlackFabricStorage;
using ProductProduce;
using UnityEngine;
public class ProduceBlack : ISystemUpDate, IExchange
{
    private BlackStorageFinifshProduct _blackfinish;
    private RefeneseFabric _blackFabric;
    
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
        list.FabricBlack.Initialize(this);// controller <=> model
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
        BlackProduct black = new BlackProduct();
        _blackfinish.GiveProduct(black);
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

    /// <summary>
    /// Produse black don`t need resourses
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    public bool TryAdd(ItemsType item)
    {
        return false;
    }
    public bool TryTake(ItemsType item)
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