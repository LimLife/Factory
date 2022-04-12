using UnityEngine;
using System.Collections.Generic;
[CreateAssetMenu(fileName = "Config", menuName = "Config/Inventory", order = 64)]

public class ConfigInventory : ScriptableObject
{
    [SerializeField] private BlackItem _black;
    [SerializeField] private RedItem _red;
    [SerializeField] private GreenItem _green;

    private List<IItem> _items; // сделать не префабы а new итемы котрые будут крафтится
    public List<IItem> Items()
    {
        _items = new List<IItem>
        {
            _black,
            _red,
            _green
        };
        return _items;
    }
}
