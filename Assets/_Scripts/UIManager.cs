using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour {
    public static UIManager Instance { get; private set; }

    [SerializeField] TextMeshProUGUI _winText;

    private void Awake() {
        if (Instance != null) { Debug.LogError("There is more than one UIManager instance!"); }
        Instance = this;

        _winText.enabled = false;
    }

    public void WinScreen() {
        _winText.enabled = true;
        Time.timeScale = 0;
    }
}
