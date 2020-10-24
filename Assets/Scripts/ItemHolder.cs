using UnityEngine;

namespace CreateWithCodeGameJam2020.Scripts
{
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

        [SerializeField]
        private bool _moveItem;

        [SerializeField]
        private Transform _moveEndPoint;

        [SerializeField]
        private float _moveSpeed = 5f;

        private bool _toMove = false;
        private float _count = 0f;


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
            if (_rotateItem)
                _itemHeld.transform.Rotate(_itemHeldSpot.up, _rotateItemSpeed * Time.deltaTime);
            if (_toMove)
            {
                _itemHeld.transform.position = Vector3.Lerp(_itemHeldSpot.position, _moveEndPoint.position, _count);
                _count += Time.deltaTime * _moveSpeed;
                if (_count >= 1)
                    _toMove = false;
            }
        }

        public void MoveItemHeld()
        {
            //if (!_moveItem)
            //    return;

            _toMove = true;
            _count = 0;
        }

        private void CancelHolding(Item.ItemType itemType)
        {
            if (_itemHeld.GetItemType() == itemType)
                _rotateItem = false;
        }
    }
}