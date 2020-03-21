using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InteractableStation : MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject grabSprite = null;
    [SerializeField] private GameObject actionSprite = null;
    [SerializeField] private List<ItemStage> itemStages = null;
    public bool canGrabFrom = false;
    public bool canMakeAction = false;
    public bool canUseItem = false;
    private void ShowTooltips()
    {
        if(canGrabFrom)
            grabSprite.SetActive(true);
        if(canMakeAction)
            actionSprite.SetActive(true);
    }
    private void HideTooltips()
    {
        if(canGrabFrom)
            grabSprite.SetActive(false);
        if(canMakeAction)
            actionSprite.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
            ShowTooltips();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
            HideTooltips();
    }

    public bool CanGrab => canGrabFrom;
    public bool CanMakeAction => canMakeAction;

    public bool CanUseItem => canUseItem;
    public List<ItemStage> ItemStages => itemStages;

    public virtual void Interact(GameObject player)
    {
        throw new NotImplementedException();
    }

    public virtual void Action(GameObject player)
    {
        throw new NotImplementedException();
    }
    public virtual void ItemUsage(GameObject player, int index, Item item)
    {
        throw new NotImplementedException();
    }
}
