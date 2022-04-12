using UnityEngine;

public class RefereneseRedFabric : MonoBehaviour
{
    public MonoBehStorage Storage => _strorage;
    public RedFabric RedFabric => _redFabric;
    public ConfigFabric Config => _config;

    [SerializeField] private MonoBehStorage _strorage;
    [SerializeField] private RedFabric _redFabric;
    [SerializeField] private ConfigFabric _config;
}
