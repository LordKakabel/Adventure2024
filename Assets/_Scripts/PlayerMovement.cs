using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    [SerializeField] float _speed = 5.0f;
    [SerializeField] float _swordSwingTime = 1.0f;
    [SerializeField] GameObject _sword;

    bool _canMove = true;
    WaitForSeconds _swordSwingYield;

    private void Awake() {
        _swordSwingYield = new WaitForSeconds(_swordSwingTime);
    }

    private void Update() {
        if (_canMove && Input.GetKeyDown(KeyCode.Space)) {
            _canMove = false;
            _sword.SetActive(true);
            StartCoroutine(SwingSword());
        }
    }

    private void FixedUpdate() {
        if (_canMove) {
            HandleMovement();
        }
    }

    private void HandleMovement() {
        Vector3 move = new(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        transform.position += _speed * Time.deltaTime * move;
        Vector3 direction = move.normalized;

        if (move != Vector3.zero) {
            transform.up = direction;
        }
    }

    private IEnumerator SwingSword() {
        yield return _swordSwingYield;
        _sword.SetActive(false);
        _canMove = true;
    }
}