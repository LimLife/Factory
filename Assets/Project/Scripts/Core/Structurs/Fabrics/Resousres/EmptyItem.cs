using System;
using UnityEngine;

public class EmptyItem :MonoBehaviour, IItem
{

    public  Color CoclorItem => throw new NotImplementedException();

    public Type Type => throw new NotImplementedException();
}