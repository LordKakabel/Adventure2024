using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {
    public Action<int> OnHealthChanged;

	[SerializeField] private int _maxHealth = 3;

	private int _currentHealth;

    private void Awake() {
        _currentHealth = _maxHealth;
    }

    public void Damage(int damage = 1) {
        _currentHealth -= damage;

        if (_currentHealth < 0) {
            _currentHealth = 0;
            Dead();
        }

        OnHealthChanged?.Invoke(_currentHealth);
    }

    private void Dead() {
        Debug.Log(name + ": I are dead.");
    }

    public void Heal(int healingAmount = 1) {
        _currentHealth += healingAmount;
        if (_currentHealth > _maxHealth) { _currentHealth = _maxHealth; }

        OnHealthChanged?.Invoke(_currentHealth);
    }

    public int GetHealth() {
        return _currentHealth;
    }
}
