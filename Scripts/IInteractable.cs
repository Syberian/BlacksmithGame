﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable
{
    bool CanGrab { get; }
    bool CanMakeAction { get; }
    bool CanUseItem { get; }
    List<ItemStage> ItemStages { get; }
    void Interact(GameObject player);
    void Action(GameObject player);
    void ItemUsage(GameObject player, int itemIndex, Item item);
}

public enum ItemStage
{
    ToBeHeated,
    ToBeForged,
    ToBeCooled,
    ToBeSharpened,
    
}