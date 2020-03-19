using System;
using System.Collections;
using System.Collections.Generic;
using UI;
using UnityEngine;

public class Interacting : MonoBehaviour
{
    private IInteractable _interactable = null;
    private bool _canInteract = false;
    private bool _canGrab = false;
    private bool _canMakeAction = false;
    private bool _canUseItem = false;
    
    private void Awake()
    {
        GrabButton.OnGrabPressed += Grabbed;
        ActionButton.OnActionButtonPressed += ActionUsed;
        InventorySlot.OnInventorySlotClicked += InventorySlotUse;
    }
    private void OnTriggerStay(Collider other)
    {
        if (GetInteractable(other.gameObject) && !_canInteract)
        {
            _canInteract = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        _canInteract = false;
    }
    private bool GetInteractable(GameObject temp)
    {
        _interactable = temp.GetComponent<IInteractable>();
        if (_interactable != null)
        {
            _canGrab = _interactable.CanGrab;
            _canMakeAction = _interactable.CanMakeAction;
            _canUseItem = _interactable.CanUseItem;
        }

        return _interactable != null;
    }

    private void Grabbed()
    {
        if(_canGrab) _interactable?.Interact(gameObject);
    }

    private void ActionUsed()
    {
        if(_canMakeAction) _interactable?.Action(gameObject);
    }
    private void InventorySlotUse(int index)
    {
        if(_canUseItem) _interactable?.ItemUsage(gameObject, index);
    }
}
