using UnityEngine;
using System.Collections;

public class Game : MonoBehaviour, IInitialize
{
    [SerializeField] CreatedEntity _created;

    [SerializeField] private CharacterInput _inputPlayer;

    [SerializeField] private Сollector _palyer;

    private ItemType _item;
    private WaitForSeconds _timeWait = new WaitForSeconds(1f);
    public void Initialize()
    {
        _palyer.Initialize();
        _created.Initialize();
        Subscribe();
    }
    public void Subscribe()
    {
        _created.OnVisit += Visit;
        _created.OnVisit += DownloadResourses;
    }

    private IEnumerator WaitDownload(ItemType item, TypeFabric fabric)
    {
        int resourses = _palyer.CountItems(item);
        while (resourses > 0)
        {
            yield return _timeWait;
            resourses--;
            if (_created.DownloadResourses(fabric))
            {
                _palyer.DeliveryItme(item);
            }
            else
                yield break;
        }
        yield break;
    }
    private IEnumerator WaitDelivery(ItemType item,int count)
    {
        while (count > 0)
        {
            yield return _timeWait;
            _palyer.AddItem(item);
            count--;
        }
        yield break;
    }

    private void Visit(TypeFabric fabric)
    {
        int product;
        switch (fabric)
        {
            case TypeFabric.FabricTypeOne:
                _item = ItemType.Black;
                product = _created.Release(_palyer.RemainingCapacityBlack);
                if (!_palyer.IsFullBlack)
                {
                    StartCoroutine(WaitDelivery(_item,product));
                }
                else
                    return;
                break;
            case TypeFabric.FabricTypeTwo:
                _item = ItemType.Red;
                product = _created.Release(_palyer.RemainingCapacityRed);
                if (!_palyer.IsFullRed)
                {
                    StartCoroutine(WaitDelivery(_item, product));
                }
                else
                    return;
                break;
            case TypeFabric.FabricTypeThree:
                _item = ItemType.Green;
                product = _created.Release(_palyer.RemainingCapacityGreen);
                if (!_palyer.IsFullGreen)
                {
                    StartCoroutine(WaitDelivery(_item, product));
                }
                else
                    return;
                break;
        }
    }

    private void DownloadResourses(TypeFabric fabric)
    {
        switch (fabric)
        {
            case TypeFabric.FabricTypeOne:

                return;
            case TypeFabric.FabricTypeTwo:
                if (_palyer.IsEmptyBlack)
                {
                    return;
                }
                GiveResoursesBlack(fabric);
                break;
            case TypeFabric.FabricTypeThree:
                if (!_palyer.IsEmptyBlack)
                {
                    GiveResoursesBlack(fabric);
                }
                else
                    return;
                if (!_palyer.IsEmptyRed)
                {
                    GiveResoursesRed(fabric);
                }
                else
                    return;
                break;

        }
    }
    private void GiveResoursesBlack(TypeFabric fabric)
    {
        _item = ItemType.Black;
        StartCoroutine(WaitDownload(_item,fabric));
    }
    private void GiveResoursesRed(TypeFabric fabric)
    {
        _item = ItemType.Red;
        StartCoroutine(WaitDownload(_item, fabric));

    }   
}
