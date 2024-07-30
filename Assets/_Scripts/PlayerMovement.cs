using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
	[SerializeField] float _speed = 5.0f;

    private void FixedUpdate() {
        Vector3 move = new(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        transform.position += _speed * Time.deltaTime * move;
        Vector3 direction = move.normalized;

        if (move != Vector3.zero) {
            transform.up = direction;
        }
    }
}