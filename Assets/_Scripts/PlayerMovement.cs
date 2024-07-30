using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
	[SerializeField] float _speed = 5.0f;
    [SerializeField] float _rotationSpeed = 100.0f;

    private void FixedUpdate() {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        transform.position += move * _speed * Time.deltaTime;
        Vector3 direction = move.normalized;

        if (move != Vector3.zero) {
            transform.up = direction;
        }
    }
}
