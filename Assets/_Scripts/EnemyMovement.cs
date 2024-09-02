using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {
	private enum State { Idle, Wandering, Chase }

	[SerializeField] State _state = State.Wandering;
    [SerializeField] float _speed = 5.0f;
    [SerializeField] List<Transform> _waypoints = new();
    [SerializeField] float _idleTime = 3.0f;
    [SerializeField] float _waypointMinimumDistance = 0.05f;

    Vector3 _direction;
    int _currentWaypoint = 0;
    WaitForSeconds _idleTimeYield;

    private void Awake() {
        _idleTimeYield = new WaitForSeconds(_idleTime);
    }

    private void Update() {
        switch (_state) {
            case State.Idle:
                break;
            case State.Wandering:
                MoveTowardWaypoint();
                break;
            case State.Chase:
                MoveTowardPlayer();
                break;
            default:
                break;
        }
    }

    private void MoveTowardWaypoint() {
        // If there are waypoints,
        if (_waypoints.Count > 0) {
            // If we are very close to the current waypoint, assign the next one
            if (Vector3.Distance(transform.position, _waypoints[_currentWaypoint].position) <= _waypointMinimumDistance) {
                _currentWaypoint++;
                if (_currentWaypoint >= _waypoints.Count)
                    _currentWaypoint = 0;
            } else {
                // Else continue towards the current waypoint
                Move(_waypoints[_currentWaypoint]);
            }
        }
    }

    private void MoveTowardPlayer() {
        PlayerMovement player = FindAnyObjectByType<PlayerMovement>();
        Move(player.transform);        
    }

    private void Move(Transform target) {
        Vector3 move = (target.position - transform.position).normalized;
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
            StartCoroutine(IdleTimeCoroutine());
        }
    }

    private IEnumerator IdleTimeCoroutine() {
        yield return _idleTimeYield;

        _state = State.Wandering;
    }
}
