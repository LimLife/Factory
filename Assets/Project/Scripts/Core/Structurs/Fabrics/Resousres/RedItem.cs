using System;
using UnityEngine;

public class RedItem :MonoBehaviour, IItem
{
    public  Color CoclorItem => throw new NotImplementedException();

    public Type Type => GetType();
}
