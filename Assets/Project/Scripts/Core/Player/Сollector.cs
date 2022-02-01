using UnityEngine;
using System.Collections.Generic;

[RequireComponent (typeof(Rigidbody))]
[RequireComponent (typeof(CapsuleCollider))]
public class Сollector : Player, IInitialize
{
    [SerializeField] private GreenItem _green;
    [SerializeField] private BlackItem _black;
    [SerializeField] private RedItem _red;

    [SerializeField] private GameObject _pointBlack;
    [SerializeField] private GameObject _pointRed;
    [SerializeField] private GameObject _pointGreen;

    public override int Capacity { get; protected set; } = 10; //test
    public int RemainingCapacityBlack => Capacity - _blackItem.Count;
    public int RemainingCapacityRed => Capacity - _redItem.Count;
    public int RemainingCapacityGreen => Capacity - _greenItem.Count;

    public bool IsFullBlack => _blackItem.Count == Capacity;
    public bool IsFullRed => _redItem.Count == Capacity;
    public bool IsFullGreen => _greenItem.Count == Capacity;
    public bool IsEmptyBlack => _blackItem.Count == 0;
    public bool IsEmptyRed => _redItem.Count == 0;
    public bool IsEmptyGreen => _greenItem.Count == 0;

    private float _offSet = 0.2f;
    protected override Stack<BlackItem> _blackItem { get; set; }

    protected override Stack<RedItem> _redItem { get; set; }

    protected override Stack<GreenItem> _greenItem { get; set; }

    public void Initialize()
    {
        _greenItem = new Stack<GreenItem>(Capacity);
        _blackItem = new Stack<BlackItem>(Capacity);
        _redItem = new Stack<RedItem>(Capacity);
    }

    public override void AddItem(ItemType item)
    {
        InstantiateItem(item);
    }
    public int CountItems(ItemType item)
    {
        switch (item)
        {
            case ItemType.Red:
                return _redItem.Count;
            case ItemType.Black:
                return _blackItem.Count;

            case ItemType.Green:
                return _greenItem.Count;
            default:
                return 0;
        }
    }
    public override void DeliveryItme(ItemType item) 
    {
        RemoveBaggage(item);
    }

    private void RemoveBaggage(ItemType item)
    {
        switch (item)
        {
            case ItemType.Red:
                if (IsEmptyRed)
                {
                    return;
                }
                var redprefab = _redItem.Pop();
                Destroy(redprefab.gameObject);
                break;
            case ItemType.Black:
                if (IsEmptyBlack)
                {
                    return;
                }
                var blackprefab = _blackItem.Pop();
                Destroy(blackprefab.gameObject);
                break;
            case ItemType.Green:
                if (IsEmptyGreen)
                {
                    return;
                }
                var greenprefab = _greenItem.Pop();
                Destroy(greenprefab.gameObject);
                break;
        }
    }
    private void InstantiateItem(ItemType item)
    {
        switch (item)
        {
            case ItemType.Red:
                var prefabRed = Instantiate(_red, new Vector3
                    (_pointRed.transform.position.x, _offSet * _redItem.Count, _pointRed.transform.position.z),
                    Quaternion.identity, _pointRed.transform);

                _redItem.Push(prefabRed);
                break;
            case ItemType.Black:
                var prefabBlack = Instantiate(_black, new Vector3
                    (_pointBlack.transform.position.x, _offSet * _blackItem.Count, _pointBlack.transform.position.z),
                    Quaternion.identity, _pointBlack.transform);

                _blackItem.Push(prefabBlack);

                break;
            case ItemType.Green:
                var prefabGreen = Instantiate(_green, new Vector3
                    (_pointGreen.transform.position.x, _offSet * _greenItem.Count, _pointGreen.transform.position.z),
                    Quaternion.identity, _pointGreen.transform);

                _greenItem.Push(prefabGreen);
                break;
        }
    }
}
