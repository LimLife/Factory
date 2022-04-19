using UnityEngine;

[CreateAssetMenu (fileName = "Config",menuName = "Config/Storage",order =64)]
public class ConfigStorage : ScriptableObject
{
    public int CapacityStorage => _capacityStorage;
    [SerializeField] private int _capacityStorage;
}
