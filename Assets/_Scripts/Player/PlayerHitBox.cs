using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitBox : MonoBehaviour {
    public void Damage() {
        Debug.Log("Damage!");
        //Destroy(transform.parent.gameObject);
        //UIManager.Instance.GameOverScreen();
    }
}