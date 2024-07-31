using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    private void OnTriggerStay2D(Collider2D collision) {
        if (collision.gameObject.GetComponentInChildren<PlayerWeapon>()) {
            Destroy(gameObject);
        }
    }
}