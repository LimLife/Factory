﻿using System;
using UnityEngine;

public class GreenItem : Item,IInitialize
{

    public override Color CoclorItem => throw new NotImplementedException();

    public override ItemType ItemType => _item;
    private ItemType _item;

    public void Initialize()
    {
        _item = ItemType.Green;
    }
}