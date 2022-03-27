using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class HoverNextStage : MonoBehaviour
{
    [SerializeField] private GameObject buttonText;
    private Color defaultColor = new Color(255, 210, 159);

    public void OnPointerEnter()
    {
        buttonText.GetComponent<Text>().color = Color.white;
    }

    public void OnPointerExit()
    {
        buttonText.GetComponent<Text>().color = defaultColor;
    }
}
