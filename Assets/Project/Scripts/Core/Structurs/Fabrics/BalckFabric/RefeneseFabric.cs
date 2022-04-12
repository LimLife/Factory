using UnityEngine;

public class RefeneseFabric : MonoBehaviour
{
    public BlackFabric FabricBlack => _fabric;
    public MonoBehStorage StorageBlack => _stroage;
    public ConfigFabric Config => _config;

    [SerializeField] private BlackFabric _fabric;
    [SerializeField] private MonoBehStorage _stroage;
    [SerializeField] private ConfigFabric _config;
}
