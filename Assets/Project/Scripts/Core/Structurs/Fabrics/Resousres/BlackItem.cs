using System;
using UnityEngine;

public class BlackItem :MonoBehaviour, IItem
{
    public  Color CoclorItem => throw new NotImplementedException();

    public Type Type => GetType();
}
