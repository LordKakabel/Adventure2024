using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unlockable : MonoBehaviour {
	[SerializeField] ItemSO _itemSONeededToUnlock;

    private void OnCollisionEnter2D(Collision2D collision) {
        // If the player has the needed item, delete it and destroy self
        if (collision.gameObject.GetComponent<PlayerMovement>()) {
            if (ItemUI.Instance.GetItemSO() == _itemSONeededToUnlock) {
                ItemUI.Instance.DropItem();
                Destroy(gameObject);
            }
        }
    }
}