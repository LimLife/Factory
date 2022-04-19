using UnityEngine;

[CreateAssetMenu(fileName = "Config", menuName = "Config/Player", order = 64)]

public class ConfigPlayer : ScriptableObject
{
    // Create button for input
    [SerializeField] private KeyCode _up;
}
