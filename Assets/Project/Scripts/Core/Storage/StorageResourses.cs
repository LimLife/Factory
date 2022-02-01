using System.Collections.Generic;
using UnityEngine;
public class StorageResourses : Storage,IInitialize
{   
    [SerializeField] private TextMesh _message;
    [SerializeField] private GameObject _indecatorFullness;
    public int Capacity { get; private set; } = 10;

    private float _defaultY = 0;

    private readonly float _removeFullness = 0.1f;

    public int RemainigCamacityBlack => Capacity - _blackItems.Count;
    public int RemainigCamacityRed => Capacity - _redItems.Count;
    public int RemainigCamacityGreen => Capacity - _greenItems.Count;
    private Vector3 _defaultScale;
    #region Bool EmptyOrFull
    public bool IsFullFirtsItem => _blackItems.Count == Capacity;
    public bool IsEmptyFerstItem => _blackItems.Count == 0;
    public bool IsEmptySecondItem => _redItems.Count == 0;
    public bool IsFullSecondItem => _redItems.Count == Capacity;
    public bool IsFullThirdItem => _greenItems.Count == Capacity;
    public bool IsEmptyThirdItem => _greenItems.Count == 0;

    #endregion

    private readonly BlackItem _black;
    private readonly RedItem _red;
    protected override Stack<BlackItem> _blackItems { get; set; }
    protected override Stack<RedItem> _redItems { get; set; }
    protected override Stack<GreenItem> _greenItems { get; set; }
    public void Initialize()
    {
        _defaultScale = new Vector3(_indecatorFullness.transform.localScale.x, _defaultY,_indecatorFullness.transform.localScale.z);
        _indecatorFullness.transform.localScale = _defaultScale;
    }
    private void Message(string message)
    {
        _message.text = message;
    }

  
    public void SetStorage(TypeFabric type)
    {
        switch (type)
        {
            case TypeFabric.FabricTypeOne:
                return;
            case TypeFabric.FabricTypeTwo:
                _blackItems = new Stack<BlackItem>(Capacity);
                break;
            case TypeFabric.FabricTypeThree:
                _blackItems = new Stack<BlackItem>(Capacity);
                _redItems = new Stack<RedItem>(Capacity);
                break;
        }
    }
    public override void PutItem(TypeFabric fabric)
    {
        string str;
        switch (fabric)
        {
            case TypeFabric.FabricTypeOne:
                return;              
            case TypeFabric.FabricTypeTwo:
                str = $"Add Black {_blackItems.Count}";
                Message(str);
                _blackItems.Push(_black);
                ScaleIndecatorUp();
                break;
            case TypeFabric.FabricTypeThree:
                str = $"Add Black and Red {_blackItems.Count}";
                Message(str);
                _blackItems.Push(_black);
                _redItems.Push(_red);
                ScaleIndecatorUp();
                break;           
        }
    }

    public override void IssueItem(TypeFabric type)
    {
        switch (type)
        {
            case TypeFabric.FabricTypeOne:
                break;
            case TypeFabric.FabricTypeTwo:
                ScaleIndecatorDown();
                _blackItems.Pop();
                string str = $"Count :BlackItem : value {_blackItems.Count}";
                Message(str);
                break;
            case TypeFabric.FabricTypeThree:
                ScaleIndecatorDown();
                _blackItems.Pop();
                _redItems.Pop();
                string strs = $"Count :BlackItem : value {_blackItems.Count} \n Count : RedItem : value {_redItems.Count}";
                Message(strs);
                break;
            default:
                break;
        }
    }
    private void ScaleIndecatorUp()
    {
        _defaultY += _removeFullness;
        _indecatorFullness.transform.localScale = new Vector3(_defaultScale.x,_defaultY,_defaultScale.z );
    }
    private void ScaleIndecatorDown()
    {
        _defaultY -= _removeFullness;
        _indecatorFullness.transform.localScale = new Vector3(_defaultScale.x, _defaultY,_defaultScale.z);
    }
}
