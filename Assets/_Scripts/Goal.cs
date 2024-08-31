using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour {
    [SerializeField] ItemSO _itemSONeededToUnlock;

    private void OnTriggerEnter2D(Collider2D collision) {
        // If the player has the needed item, display win screen
        if (collision.gameObject.GetComponent<PlayerMovement>()) {
            if (ItemUI.Instance.GetItemSO() == _itemSONeededToUnlock) {
                UIManager.Instance.WinScreen();
            }
        }
    }
}
