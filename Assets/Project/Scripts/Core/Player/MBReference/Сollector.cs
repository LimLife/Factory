using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]
public class Сollector : Player
{
    public IExchange Exchange { get; private set; }
    [Space(10), Header("Game Object : Character model")]
    [SerializeField] private Сollector _character;

    private Transform _trnasform;
    public void Initialie(IExchange exchange)
    {
        _trnasform = gameObject.GetComponent<Transform>();
        Exchange = exchange;
    }
    public void Move(Vector3 diraction) // i want pattern command this is only view
    {
        _trnasform.Translate(diraction * 0.3f);
    }
    private void OnTriggerEnter(Collider other)
    {
        var fabric = other.GetComponent<Factory>();
        if (other.GetComponent<Factory>())
        {
            var inventory = Exchange.TryAdd(fabric.ProductItem);
            var structure = fabric.Exchange.TryTake(fabric.ProductItem);
            if (inventory && structure)
                Exchange.TryGiveItem(fabric.Exchange.TryGetItem());
        }
    }
}
