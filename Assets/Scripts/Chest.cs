using CreateWithCodeGameJam2020.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : Interactable
{
    [SerializeField]
    private Animator _lidAnimator;

    [SerializeField]
    private ItemHolder _itemHolder;

    protected override void BeginInteraction()
    {
        if (_isTriggered)
            return;

        base.BeginInteraction();
        _lidAnimator.SetTrigger("ChestOpen");
        _itemHolder.MoveItemHeld();
    }

}
