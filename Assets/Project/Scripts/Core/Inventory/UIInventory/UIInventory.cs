using UnityEngine;
using UnityEngine.UI;
public class UIInventory : MonoBehaviour
{
    [SerializeField] private Text _firstItem;
    [SerializeField] private Text _secondItem;
    [SerializeField] private Text _thirdItem;

    public void RefreshUI(Slot slots)
    {
        switch (slots.Type)
        {
            case ItemsType.Black:
                _firstItem.text = $"Black : {slots.Amount}";
                break;
            case ItemsType.Red:
                _secondItem.text = $"Red :{slots.Amount}";
                break;
            case ItemsType.Green:
                _thirdItem.text = $"Green:{slots.Amount}";
                break;
        }
    }
}
