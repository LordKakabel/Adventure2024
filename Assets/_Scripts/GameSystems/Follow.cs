using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour {
	public Transform TransformToFollow;

    [SerializeField] Vector3 _offset = Vector3.zero;

    private void Update() {
        transform.position = TransformToFollow.position + _offset;
    }
}
