using UnityEngine;

public class RefereneseRedFabric : MonoBehaviour
{
    public MonoBehStorage Storage => _strorage;
    public RedFactory RedFabric => _redFabric;
    public ConfigFabric Config => _config;

    [SerializeField] private MonoBehStorage _strorage;
    [SerializeField] private RedFactory _redFabric;
    [SerializeField] private ConfigFabric _config;
}
