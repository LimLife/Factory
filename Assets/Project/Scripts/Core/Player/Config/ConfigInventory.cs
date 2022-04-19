using UnityEngine;
[CreateAssetMenu(fileName = "Config", menuName = "Config/Inventory", order = 64)]

public class ConfigInventory : ScriptableObject
{
    public int CapacitySlot => _capacitySlot;
    [SerializeField] private int _capacitySlot;
   
}
