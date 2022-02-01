using System.Collections.Generic;
using UnityEngine;

public class FinishedStorage : Storage,IInitialize
{
    [SerializeField] private TextMesh _message;
    [SerializeField] private GameObject _indecatorFullness;

    #region Bool FullOrEmpty
    public bool IsFullFirtsItem => _blackItems.Count == MaxCapacity;
    public bool IsEmptyFerstItem => _blackItems.Count == 0;
    public bool IsEmptySecondItem => _redItems.Count == 0;
    public bool IsFullSecondItem => _redItems.Count == MaxCapacity;
    public bool IsFullThirdItem => _greenItems.Count == MaxCapacity;
    public bool IsEmptyThirdItem => _greenItems.Count == 0;

    #endregion

    public int MaxCapacity { get; private set; } = 10;


    private readonly float _removeFullness = 0.1f;
    private Vector3 _defaultScale;
    private float _defaultY = 0;

    protected override Stack<BlackItem> _blackItems { get; set; }
    protected override Stack<RedItem> _redItems { get; set; }
    protected override Stack<GreenItem> _greenItems { get; set; }


    private readonly BlackItem _blackItem;
    private readonly GreenItem _greenItem;
    private readonly RedItem _redItem;


    public void Initialize()
    {
        _defaultScale = new Vector3(_indecatorFullness.transform.localScale.x, _defaultY, _indecatorFullness.transform.localScale.z);
        _indecatorFullness.transform.localScale = _defaultScale;
    }
    private void Message(string message)
    {
        _message.text = message;
    }

    public int CountProuduct(TypeFabric type)
    {
        switch (type)
        {
            case TypeFabric.FabricTypeOne:
                return _blackItems.Count;

            case TypeFabric.FabricTypeTwo:
                return _redItems.Count;

            case TypeFabric.FabricTypeThree:
                return _greenItems.Count;
            default:
                return 0;
        }
    }
    public void SetStorage(TypeFabric type)
    {
        switch (type)
        {
            case TypeFabric.FabricTypeOne:
                _blackItems = new Stack<BlackItem>(MaxCapacity);
                break;
            case TypeFabric.FabricTypeTwo:
                _redItems = new Stack<RedItem>(MaxCapacity);
                break;
            case TypeFabric.FabricTypeThree:
                _greenItems = new Stack<GreenItem>(MaxCapacity);
                break;
            default:
                return;
        }
    }

    public override void PutFabricProduct(TypeFabric type)
    {
        string str;
        switch (type)
        {
            case TypeFabric.FabricTypeOne:
                ScaleIndecatorUp();
                _blackItems.Push(_blackItem);
                str = $"Count BlackItem :value {_blackItems.Count}";
                Message(str);
                break;
            case TypeFabric.FabricTypeTwo:
                ScaleIndecatorUp();
                _redItems.Push(_redItem);
                str = $"Count RedItem :value {_redItems.Count}";
                Message(str);

                break;
            case TypeFabric.FabricTypeThree:
                ScaleIndecatorUp();
                _greenItems.Push(_greenItem);
                str = $"Count GreenItem :value {_greenItems.Count}";
                Message(str);
                break;
            default:
                return;
        }
    }
    public override void IssueItem(TypeFabric type)
    {
        string str;
        switch (type)
        {
            case TypeFabric.FabricTypeOne:
                _blackItems.Pop();
                ScaleIndecatorDown();
                str = $"Count BlackItem :value {_blackItems.Count}";
                Message(str);

                break;
            case TypeFabric.FabricTypeTwo:
                ScaleIndecatorDown();
                _redItems.Pop();
                str = $"Count RedItem :value {_redItems.Count}";
                Message(str);

                break;
            case TypeFabric.FabricTypeThree:
                ScaleIndecatorDown();
                _greenItems.Pop();
                str = $"Count GreenItem :value {_greenItems.Count}";
                Message(str);
                break;
        }
    }

    private void ScaleIndecatorUp()
    {
        _defaultY += _removeFullness;
        _indecatorFullness.transform.localScale = new Vector3(_defaultScale.x, _defaultY,_defaultScale.z);
    }
    private void ScaleIndecatorDown()
    {
        _defaultY -= _removeFullness;
        _indecatorFullness.transform.localScale = new Vector3(_defaultScale.x, _defaultY,_defaultScale.z);
    }
}