using UnityEngine;

[CreateAssetMenu(fileName = "Config", menuName = "Config/Fabric", order = 64)]
public class ConfigFabric : ScriptableObject
{
    public float TimeProduse => _timeProduse;
    [SerializeField] private float _timeProduse;
}
