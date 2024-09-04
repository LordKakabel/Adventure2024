using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthUI : MonoBehaviour {
    [SerializeField] private Transform _healthbar;
	[SerializeField] private GameObject _healthContainer;
	[SerializeField] private Health _health;

    private void Start() {
        _health.OnHealthChanged += Health_OnHealthChanged;
        Health_OnHealthChanged(_health.GetHealth());
    }

    private void Health_OnHealthChanged(int health) {
        DestroyAllChildren();
        for (int i = 0; i < health; i++) {
            Instantiate(_healthContainer, _healthbar);
        }
    }

    private void OnDisable() {
        _health.OnHealthChanged -= Health_OnHealthChanged;
    }

    private void DestroyAllChildren() {
        foreach (Transform child in _healthbar) {
            Destroy(child.gameObject);
        }
    }
}
