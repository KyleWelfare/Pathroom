using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class TextColorChanger : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Color defaultColor = new Color(255.0f/255.0f, 210.0f/255.0f, 159.0f/255.0f);
    public void OnPointerEnter(PointerEventData eventData)
    {
        GetComponent<Text>().color = Color.white;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        GetComponent<Text>().color = defaultColor;
    }
}