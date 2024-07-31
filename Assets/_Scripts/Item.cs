using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {
    public ItemSO ItemSO;

    public void CreateItem(ItemSO itemSO) {
        ItemSO = itemSO;
        GetComponent<SpriteRenderer>().sprite = itemSO.Sprite;
        GetComponent<SpriteRenderer>().color = itemSO.Color;
    }
}