using System;
using UnityEngine;
using System.Collections;

public class CreatedEntity : MonoBehaviour, IInitialize
{
    public event Action<TypeFabric> OnVisit;
    [SerializeField] private ProduceBlack _black;
    [SerializeField] private ProduceGreen _green;
    [SerializeField] private ProduceRed _red;


    public void Initialize()
    {
        _black.Initialize();
        _red.Initialize();
        _green.Initialize();
        Subcribe();
        StartCoroutine(UpDataFabric());
    }

    private readonly WaitForSeconds _timer = new WaitForSeconds(1f); //test

    private TypeFabric _fabric;
    public void Subcribe()
    {
        _black.OnEnterToFabric += Visit;
        _red.OnEnterToFabric += Visit;
        _green.OnEnterToFabric += Visit;
    }

    public bool DownloadResourses(TypeFabric type)
    {
        switch (type)
        {
            case TypeFabric.FabricTypeOne:
                return false;
            case TypeFabric.FabricTypeTwo:
                return AddResoursesSecondFabric();

            case TypeFabric.FabricTypeThree:
                return AddResoursesThirdFabric();
            default:
                return false;
        }
    }
    public int Release(int capacityAdding)
    {
        int product;
        switch (_fabric)
        {
            case TypeFabric.FabricTypeOne:
                product = FabricBlackOut(capacityAdding);
                break;
            case TypeFabric.FabricTypeTwo:
                product = FabricRedOut(capacityAdding);
                break;
            case TypeFabric.FabricTypeThree:
                product = FabricGreenOut(capacityAdding);
                break;
            default:
                return 0;
        }
        return product;
    }

    private bool AddResoursesSecondFabric()
    {
        if (_red.FreePlaceBlackResourses != 0)
        {
            _red.AddResourses();

            return true;
        }
        return false;

    }
    private bool AddResoursesThirdFabric()
    {
        if (_green.FreePlaceBlackResourses != 0 || _green.FreePlaceRedResourses != 0)
        {
            _green.AddResourses();
            return true;
        }
        return false;
    }

    private int FabricBlackOut(int capacityAdding)
    {
        return _black.FinishProduct <= capacityAdding ? _black.FinishProduct : _black.FinishProduct - capacityAdding;
    }
    private int FabricRedOut(int capacityAdding)
    {
        return _red.FinishProduct <= capacityAdding ? _red.FinishProduct : _red.FinishProduct - capacityAdding;
    }
    private int FabricGreenOut(int capacityAdding)
    {
        return _green.FinishProduct <= capacityAdding ? _green.FinishProduct : _green.FinishProduct - capacityAdding;
    }

    private void Visit(TypeFabric fabric)
    {
        _fabric = fabric;
        OnVisit?.Invoke(_fabric);
    }

    private IEnumerator UpDataFabric()
    {
        while (true)
        {
            yield return _timer;
            _black.Production();
            _red.Production();
            _green.Production();
        }
    }

}
