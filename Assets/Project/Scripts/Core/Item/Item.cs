using UnityEngine;

public abstract class Item : MonoBehaviour
{
    public abstract Color CoclorItem { get; }
   public abstract ItemType ItemType { get; }

}
