using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    [SerializeField] private GameObject _healthBar;

    private Health _health;

    private void Awake() {
        Instantiate(_healthBar);
        _healthBar.GetComponent<Follow>().TransformToFollow = transform;
        _health = GetComponentInParent<Health>();
        _healthBar.GetComponentInChildren<HealthUI>().SetHealth(_health);
    }

    public void Damage() {
        _health.Damage();
    }

    private void OnTriggerStay2D(Collider2D collision) {
        if (collision.gameObject.GetComponentInChildren<PlayerWeapon>()) {
            Damage();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.GetComponentInChildren<PlayerWeapon>()) {
            Damage();
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