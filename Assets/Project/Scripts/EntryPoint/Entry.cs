using UnityEngine;

public class Entry : MonoBehaviour
{
    [SerializeField] private Game _game;
  //  [SerializeField] private UI _ui;


    private void Awake()
    {
        _game.Initialize();
    }
}
