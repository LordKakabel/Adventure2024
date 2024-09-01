using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    [SerializeField] float _speed = 5.0f;
    [SerializeField] float _swordSwingTime = 1.0f;
    [SerializeField] GameObject _sword;

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
    }

    private void SwingSword() {
        _canMove = false;
        _sword.SetActive(true);
        // Added position change to help trigger detection.
        _sword.transform.position = _sword.transform.position + (Vector3.one * 0.0001f);
        StartCoroutine(SwingSwordCoroutine());
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

        // Added position change to help trigger detection.
        _sword.transform.position = _sword.transform.position - (Vector3.one * 0.0001f);
        _sword.SetActive(false);
        _canMove = true;
    }

    public Vector3 GetDirection() {
        return _direction;
    }
}