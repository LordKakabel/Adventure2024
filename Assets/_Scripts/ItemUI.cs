using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemUI : MonoBehaviour {
	public static ItemUI Instance { get; private set; }

	[SerializeField] Image _itemSlotImage;

	ItemSO _heldItem = null;

    private void Awake() {
        if (Instance != null) { Debug.LogError("There is more than one ItemUI instance!"); }
        Instance = this;
    }

    public void SetItem(ItemSO item) {
		_heldItem = item;
		Debug.Log(_itemSlotImage.name);
		_itemSlotImage.enabled = true;
		_itemSlotImage.sprite = item.Sprite;
		_itemSlotImage.color = item.Color;
	}
}
