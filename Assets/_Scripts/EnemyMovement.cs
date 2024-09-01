using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {
	private enum State { Idle, Chase }

	[SerializeField] State _state = State.Idle;
    [SerializeField] float _speed = 5.0f;

    Vector3 _direction;

    private void Update() {
        switch (_state) {
            case State.Idle:
                break;
            case State.Chase:
                MoveTowardPlayer();
                break;
            default:
                break;
        }
    }

    private void MoveTowardPlayer() {
        PlayerMovement player = FindAnyObjectByType<PlayerMovement>();
        Vector3 move = (player.transform.position - transform.position).normalized;
        transform.position += _speed * Time.deltaTime * move;

        if (move != Vector3.zero) {
            _direction = move.normalized;
            transform.up = _direction;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        PlayerMovement player = collision.GetComponent<PlayerMovement>();
        if (player) {
            _state = State.Chase;
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        PlayerMovement player = collision.GetComponent<PlayerMovement>();
        if (player) {
            _state = State.Idle;
        }
    }
}
