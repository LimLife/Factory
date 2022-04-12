using GreenFabricStorage;
using UnityEngine;
public class ProduceGreen : IExchange, ISystemUpDate
{
    private GreenStorage _resourses;
    private GreenStorageFinishProduct _finish;
    #region Prdouse
    private RedItem _red;
    private BlackItem _black;
    private GreenItem _green;
    #endregion

    private ReferenceGreenFabric _greenReference;

    private float _repitTime => _greenReference.Config.TimeProduse;
    private float _second;
    private float _timeRemainder;


    public void GiveProduct()
    {
        if (!_finish.IsFull && !GetResorses())
        {
            _finish.GiveProduct(_green);
        }
        else
            Mesage("Склад переполнен");
    }
    public bool GetResorses()
    {
        if (!_resourses.IsEmpty)
            _resourses.GetResourses(_black, _red);
        Mesage("Нет ресурсов");
        return false;
    }

    public void Initialize(ReferenceGreenFabric reference)
    {
        _greenReference = reference;
        _resourses = new GreenStorage();
        _finish = new GreenStorageFinishProduct();

    }
    public void Produce()
    {
        GiveProduct();
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

    // Exchange give two items

    public IItem TryGetItem()
    {
        return _finish.GetItem();
    }
    public void TryGiveItem(IItem item)
    {
        _resourses.GiveResourses(item);
    }
    public bool TryAdd(IItem item)
    {
        return _resourses.CheckCapacity(item);

    }
    public bool TryTake(IItem item)
    {
        if (!_finish.IsEmpty)
            return true;
        return false;
    }
    public void Execute()
    {
        Timer();
    }

    private void Mesage(string msg)
    {
        _greenReference.Fabric.Message(msg);
    }

}
