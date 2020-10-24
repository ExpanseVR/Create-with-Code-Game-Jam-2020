using CreateWithCodeGameJam2020.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHolder : MonoBehaviour
{
    [SerializeField]
    private Item _itemHeld;

    [SerializeField]
    private Transform _itemHeldSpot;

    [SerializeField]
    private bool _rotateItem;

    [SerializeField]
    private float _rotateItemSpeed = 5f;


    private void OnEnable()
    {
        Item.onGetItem += CancelHolding;
    }

    private void Start()
    {
        _itemHeld.gameObject.transform.position = _itemHeldSpot.position;
    }

    void Update()
    {
        if (!_rotateItem)
            return;

        _itemHeld.transform.Rotate(_itemHeldSpot.up, _rotateItemSpeed * Time.deltaTime);
    }

    private void CancelHolding (Item.ItemType itemType)
    {
        if (_itemHeld.GetItemType() == itemType)
            _rotateItem = false;
    }
}
