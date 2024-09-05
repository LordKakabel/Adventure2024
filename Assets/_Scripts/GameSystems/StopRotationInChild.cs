using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopRotationInChild : MonoBehaviour {
    private void Update() {
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }
}
