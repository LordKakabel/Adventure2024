using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitBox : MonoBehaviour {
    private Health _health;

    private void Awake() {
        _health = GetComponentInParent<Health>();
    }

    public void Damage() {
        _health.Damage();
    }
}