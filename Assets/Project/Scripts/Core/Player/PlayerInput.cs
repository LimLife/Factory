using UnityEngine;
public class PlayerInput : ISystemUpDate
{
    private Сollector _collector;   
    public PlayerInput(Сollector сollector)
    {
        _collector = сollector;
    }
    public void Execute()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");

        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        _collector.Move(movement);
    }
}
