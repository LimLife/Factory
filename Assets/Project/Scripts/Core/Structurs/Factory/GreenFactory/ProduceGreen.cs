using GreenFabricStorage;
using ProductProduce;
using UnityEngine;
public class ProduceGreen : IExchange, ISystemUpDate
{
    private GreenStorage _resourses;
    private GreenStorageFinishProduct _finish;

    private ReferenceGreenFabric _greenReference;
    private float _repitTime => _greenReference.Config.TimeProduse;
    private float _second;
    private float _timeRemainder;
    public void Initialize(ReferenceGreenFabric reference)
    {
        _greenReference = reference;

        reference.Fabric.SetExchange(this);
        _resourses = new GreenStorage();
        _resourses.Initialize(reference.Storage.StorageResourses, reference.Storage.Config);

        _finish = new GreenStorageFinishProduct();
        _finish.Initialize(reference.Storage.StorageProduct, reference.Storage.Config);
    }
    public void GiveProduct()
    {
        if (_finish.IsFull)
        {
            Mesage("Склад переполнен");
            return;
        }
        var resourses = _resourses.GetResourses();
        GreenProduct green = new GreenProduct(resourses.Black, resourses.Red);
        _finish.GiveProduct(green);
    }

    public void Execute()
    {
        Timer();
    }

    public void Produce()
    {
        if (_resourses.IsEmpty)
        {
            Mesage("No resourses");
            return;
        }
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

    public IItem TryGetItem()
    {
        return _finish.GetItem();
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
        if (_finish.IsEmpty)
            return false;
        return true;
    }

    private void Mesage(string msg)
    {
        _greenReference.Fabric.Message(msg);
    }

}
