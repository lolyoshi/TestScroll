using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ClickAction : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button != PointerEventData.InputButton.Left)
        {
            return;
        }

        Item item = gameObject.GetComponent<Item>();
        if (item == null)
        {
            return;
        }

        GameObject announcementObject = GameObject.Find("Text_Announcement");
        Text announcementText = announcementObject.GetComponent<Text>();
        if (announcementText != null) {
            announcementText.text = "Image " + item.itemIndex + " is clicked!";
        } 
    }
}
