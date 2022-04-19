using RedFabricStorage;
using ProductProduce;
using UnityEngine;
public class ProduceRed : ISystemUpDate, IExchange
{
    private RefereneseRedFabric _referenct;
    private RedStorage _resourses;
    private RedStorageFinishProduct _finishRed;

    private float _repitTime => _referenct.Config.TimeProduse;
    private float _second;
    private float _timeRemainder;

    public void Inititalize(RefereneseRedFabric list)
    {
        _referenct = list;
        list.RedFabric.SetExchange(this);

        _resourses = new RedStorage();
        _resourses.Initialize(list.Storage.StorageResourses, list.Storage.Config);

        _finishRed = new RedStorageFinishProduct();
        _finishRed.Initialize(list.Storage.StorageProduct, list.Storage.Config);
    }
    public void Produce()
    {
        if (_resourses.IsEmpty)
        {
            Message("No Resourses");
            return;
        }
        GiveProduct();
    }

    public void GiveProduct()
    {
        if (_finishRed.IsFull)
        {
            Message("Too more products");
            return;
        }
        var reosurses = _resourses.GetResourses();
        RedProduct red = new RedProduct(reosurses.Black);
        _finishRed.GiveProduct(red);
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
    public void Execute()
    {
        Timer();
    }

    public IItem TryGetItem()
    {
        return _finishRed.GetItem();
    }
    public void TryGiveItem(IItem item) 
    {
        _resourses.GiveResourses(item);
    }
    public bool TryAdd(ItemsType item)
    {
        if (_resourses.IsFull)
            return false;
        return true;
    }
    public bool TryTake(ItemsType item)
    {
        if (_finishRed.IsEmpty)
            return false;
        return true;
    }

    private void Message(string msg)
    {
        _referenct.RedFabric.Message(msg);
    }
}

