using RedFabricStorage;
using UnityEngine;
public class ProduceRed : ISystemUpDate, IExchange //,IStructure
{
    private RefereneseRedFabric _dependList;

    private RedStorage _resourses;
    private RedStorageFinishProduct _finishRed;
    private RedItem _red;
    private float _repitTime =>_dependList.Config.TimeProduse;
    private float _second;
    private float _timeRemainder;

    public void Inititalize(RefereneseRedFabric list)
    {
        _dependList = list;
        list.RedFabric.SetExchange(this);

        _resourses = new RedStorage();
        _resourses.Initialize(list.Storage.StorageResourses, list.Storage.Config);

        _finishRed = new RedStorageFinishProduct();
        _finishRed.Initialize(list.Storage.StorageProduct, list.Storage.Config);
    }
    public void Produce()
    {
        GiveProduct();
    }
    public bool GetResorses(IItem item)
    {
        if (!_resourses.IsEmpty)
            _resourses.GetResourses((BlackItem)item);
        return false;
    }
    public void GiveProduct()
    {
        if(_finishRed.IsFull)
        {
            Message("Storage is full");
            return;
        }      
        _finishRed.GiveProduct(_red);
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

    // Exchange give two items

    public IItem TryGetItem() // get item in to storage
    {
        return _finishRed.GetItem();
    }
    public void TryGiveItem(IItem item) // put item
    {
        _resourses.GiveResourses(item);
    }
    public bool TryAdd(IItem item)
    {
        if (!_resourses.IsFull)
            _resourses.GiveResourses(item);
        return false;
    }
    public bool TryTake(IItem item)
    {
        if (!_finishRed.IsEmpty)
            return true;
        return false;
    }

    private void Message(string msg)
    {
        _dependList.RedFabric.Message(msg);
    }
}

