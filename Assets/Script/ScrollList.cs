using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollList : MonoBehaviour {
	public GameObject prefab;
	 public Transform contentPanel;
	public int itemAmount;

	// Use this for initialization
	void Start () {
		CreateItemList();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void CreateItemList() {
		for (int i = 0; i < itemAmount; ++i) {
			GameObject itemObject = Instantiate(prefab) as GameObject;
			Item item = itemObject.GetComponent<Item>();
			item.itemImage.sprite = Resources.Load<Sprite>((i + 1).ToString());
			item.transform.SetParent(contentPanel);
		}

	}
}
