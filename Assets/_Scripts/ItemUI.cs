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

    public bool IsHoldingItem() {
        return _heldItem != null;
    }

    public ItemSO GetItemSO() { return _heldItem; }

    public void SetItem(ItemSO item) {
		_heldItem = item;
		_itemSlotImage.enabled = true;
		_itemSlotImage.sprite = item.Sprite;
		_itemSlotImage.color = item.Color;
	}

    public ItemSO DropItem() {
        _itemSlotImage.enabled = false;
        ItemSO droppedCopy = _heldItem;
        _heldItem = null;
        return droppedCopy;
    }
}
