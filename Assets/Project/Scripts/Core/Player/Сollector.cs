using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]
public class Сollector : Player
{
    public IExchange Exchange { get; private set; }

    [Space(10), Header("Game Object : Character model")]
    [SerializeField] private Сollector _character; // monobeh 

    [Space(10), Header("Some time prefab")]

    [SerializeField] private GreenItem _green;
    [SerializeField] private BlackItem _black;
    [SerializeField] private RedItem _red;

    [Space(10), Header("BackPack on the back")]

    [SerializeField] private GameObject _pointBlack;
    [SerializeField] private GameObject _pointRed;
    [SerializeField] private GameObject _pointGreen;
    public void Initialie(IExchange exchange)
    {
        Exchange = exchange;
    }
    // Add method moving
    public void Move(Vector3 diraction)
    {
        _character.transform.Translate(diraction * 0.3f);
    }
    private void OnTriggerEnter(Collider other)
    {
        var fabric = other.GetComponent<Fabric>();
        if (fabric)
        {
            var tryadd = Exchange.TryAdd(fabric.ProductItem); //если есть в инвентаре

            if (tryadd)
            {
                Exchange.TryGiveItem(fabric.Exchange.TryGetItem());
            }
        }
    }
}
