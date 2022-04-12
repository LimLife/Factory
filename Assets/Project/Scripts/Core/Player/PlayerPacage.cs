using UnityEngine;

public class PlayerPacage : MonoBehaviour,IInitialize
{
    public PlayerInput InputPlayer { get; private set; }
    private CharacterHandler _handler;
    [SerializeField] private ConfigInventory _inventory;
    [SerializeField] private Сollector _collector;
    public void Initialize()
    {
        _handler = new CharacterHandler();
        _handler.Initialize(_inventory,_collector);
        InputPlayer = new PlayerInput(_collector);
    }
   
}
