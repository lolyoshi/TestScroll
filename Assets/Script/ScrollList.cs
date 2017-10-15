using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollList : MonoBehaviour
{
    public GameObject prefab;
    public Transform contentPanel;
    public ScrollRect scrollView;
    public int itemAmount;

    private const int IMAGE_COUNT = 10;
    private const int PADDING = 20;

    // Use this for initialization
    void Start()
    {
        CreateItemList();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void CreateItemList()
    {
        RectTransform rowRectTransform = prefab.GetComponent<RectTransform>();
        RectTransform containerRectTransform = contentPanel.GetComponent<RectTransform>();

        if (rowRectTransform == null || containerRectTransform == null) {
            return;
        }

        //adjust the height of the container so that it will just barely fit all its children
        float scrollHeight = (-rowRectTransform.rect.height + PADDING) * itemAmount;
        containerRectTransform.sizeDelta = new Vector2(containerRectTransform.rect.width, scrollHeight);

        for (int i = 0; i < itemAmount; ++i)
        {
            GameObject itemObject = Instantiate(prefab) as GameObject;
            Item item = itemObject.GetComponent<Item>();
            item.itemImage.sprite = Resources.Load<Sprite>(((i % 10) + 1).ToString());
            item.itemImage.preserveAspect = true;
            item.transform.SetParent(contentPanel);
            item.itemIndex = i + 1;

            //move and size the new item
            RectTransform rectTransform = item.GetComponent<RectTransform>();
            float y = (rowRectTransform.rect.height - PADDING) * i + rowRectTransform.rect.height / 2 ;
            rectTransform.localPosition = new Vector3(rowRectTransform.rect.width / 2, y, 0);
        }
    }
}
