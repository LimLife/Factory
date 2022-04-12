using UnityEngine;
public class ReferenceGreenFabric : MonoBehaviour
{
    public GreenFabric Fabric => _fabric;
    public ConfigFabric Config => _config;
    public MonoBehStorage Storage => _storage;

    [SerializeField] private GreenFabric _fabric;
    [SerializeField] private ConfigFabric _config;
    [SerializeField] private MonoBehStorage _storage;

}
