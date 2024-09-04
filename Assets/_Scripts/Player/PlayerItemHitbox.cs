using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItemHitbox : MonoBehaviour {
    [SerializeField] PlayerMovement _playerMovement;
    [SerializeField] GameObject _itemPrefab;
    [SerializeField] float _droppedItemAreaRadius = (0.75f / 2);
    [SerializeField] LayerMask _enemyLayerMask;

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Q)) {
            DropItem();
        }
    }

    private bool DropItem() {
        // If there IS an item to be dropped,
        if (ItemUI.Instance.IsHoldingItem()) {

            // Look for a free area behind the player
            Vector2 dropPoint = transform.position - _playerMovement.GetDirection();
            Collider2D result = Physics2D.OverlapCircle(dropPoint, _droppedItemAreaRadius, _enemyLayerMask);

            // If there IS a free area (no colliders were found), drop it
            if (!result) {
                ItemSO droppedItemSO = ItemUI.Instance.DropItem();
                GameObject droppedItem = Instantiate(_itemPrefab, dropPoint, Quaternion.identity);
                droppedItem.GetComponent<Item>().CreateItem(droppedItemSO);

                return true;
            }

            return false;
        }

        return true;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        // If there IS an item,
        Item item = collision.gameObject.GetComponent<Item>();
        if (item) {
            // If we ARE already holding an item,
            if (ItemUI.Instance.IsHoldingItem()) {
                // If we can NOT drop it, return
                if (!DropItem())
                    return;
            }

            // Pickup the item
            ItemUI.Instance.SetItem(item.ItemSO);
            Destroy(collision.gameObject);
        }
    }
}