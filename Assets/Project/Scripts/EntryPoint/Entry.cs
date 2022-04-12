using UnityEngine;
using System.Collections.Generic;

public class Entry : MonoBehaviour
{
    [Space(10), Header("Fabric Adding")]
    [SerializeField] private PackAge _blackFabric;
    [SerializeField] private RedPackage _redFabric;
    [SerializeField] private GreenPackage _greenFabrci;
    [SerializeField] private PlayerPacage _palyer;

    private List<ISystemUpDate> _upDateSystem;
    private List<ISystemEvent> _eventSystem;
    private List<IInitialize> _initialize;

    //Systems Type
    //1. System UpDate    ---evry Time.deltatime  calling
    //2. System Event     ---one calling for sub and one for unsub
    //3. System Init      ---one time in to starting app

    private void Awake()
    {
        _upDateSystem = new List<ISystemUpDate>();
        
        //_eventSystem = new List<ISystemEvent>();
        Initialize();
        AddUpdateSystem();
    }
    private void Initialize()
    {      
        _initialize = new List<IInitialize>
        {
            _blackFabric,
            _redFabric,
            _greenFabrci,
            _palyer
        };
        foreach (var item in _initialize)
        {
            item.Initialize();
        }
    }
    private void AddUpdateSystem()
    {
        _upDateSystem = new List<ISystemUpDate>
        {
            _blackFabric.Produse,
            _redFabric.Produse,
            _greenFabrci.Produse,
            _palyer.InputPlayer
        };       
    }
    private void AddEventSyestem()
    {

    }
    private void Subscribe()
    {

    }
    private void UnSubscribe()
    {

    }
    private void Update()
    {
        foreach (var item in _upDateSystem)
        {
            item.Execute();
        }
    }
}
