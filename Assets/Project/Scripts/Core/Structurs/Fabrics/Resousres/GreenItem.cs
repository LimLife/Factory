using System;
using UnityEngine;

public class GreenItem :MonoBehaviour, IItem
{
    public  Color CoclorItem => throw new NotImplementedException();

    public Type Type => GetType();
}
