using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.GetComponentInChildren<PlayerWeapon>()) {
            Destroy(gameObject);
        } else {
            // If we touched the player,
            PlayerHitBox player = collision.gameObject.GetComponent<PlayerHitBox>();
            if (player) {
                // Damage it
                player.Damage();
            }
        }
    }
}