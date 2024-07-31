using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    [SerializeField] float _speed = 5.0f;
    [SerializeField] float _swordSwingTime = 1.0f;
    [SerializeField] GameObject _sword;
    [SerializeField] GameObject _itemPrefab;
    [SerializeField] float _droppedItemAreaRadius = (0.75f / 2);

    Vector3 _direction;
    bool _canMove = true;
    WaitForSeconds _swordSwingYield;

    private void Awake() {
        _swordSwingYield = new WaitForSeconds(_swordSwingTime);
    }

    private void Update() {
        if (_canMove && Input.GetKeyDown(KeyCode.Space)) {
            SwingSword();
        }

        if (Input.GetKeyDown(KeyCode.Q)) {
            DropItem();
        }
    }

    private void SwingSword() {
        _canMove = false;
        _sword.SetActive(true);
        StartCoroutine(SwingSwordCoroutine());
    }

    private bool DropItem() {
        // If there IS an item to be dropped,
        if (ItemUI.Instance.IsHoldingItem()) {

            // Look for a free area behind the player
            Vector2 dropPoint = transform.position - _direction;
            Collider2D result = Physics2D.OverlapCircle(dropPoint, _droppedItemAreaRadius);

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

    private void FixedUpdate() {
        if (_canMove) {
            HandleMovement();
        }
    }

    private void HandleMovement() {
        Vector3 move = new(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        transform.position += _speed * Time.deltaTime * move;

        if (move != Vector3.zero) {
            _direction = move.normalized;
            transform.up = _direction;
        }
    }

    private IEnumerator SwingSwordCoroutine() {
        yield return _swordSwingYield;

        _sword.SetActive(false);
        _canMove = true;
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