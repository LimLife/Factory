using UnityEngine;

public class RefeneseFabric : MonoBehaviour
{
    public BlackFactory FabricBlack => _fabric;
    public MonoBehStorage StorageBlack => _stroage;
    public ConfigFabric Config => _config;

    [SerializeField] private BlackFactory _fabric;
    [SerializeField] private MonoBehStorage _stroage;
    [SerializeField] private ConfigFabric _config;
}
