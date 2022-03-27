using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzlePiece : MonoBehaviour
{
    private bool isSelected;
    private bool isOverlapping;
    private SpriteRenderer pieceSR;

    private Color defaultColor = new Color(255, 255, 255);
    private Color selectedColor = new Color(0, 255, 0);
    private Color overlapColor = new Color(255, 0, 0);
    private float transparentAlpha = 0.5f;
    private float solidAlpha = 1.0f;
    void Awake()
    {
        pieceSR = GetComponent<SpriteRenderer>();        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if ((collision.tag == "PuzzlePiece" || collision.tag == "PlayerBlock") && isSelected)
        {
            isOverlapping = true;
            pieceSR.color = overlapColor;            
            Color tmp = pieceSR.color;
            tmp.a = transparentAlpha;
            pieceSR.color = tmp;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if ((collision.tag == "PuzzlePiece" || collision.tag == "PlayerBlock") && isSelected)
        {
            isOverlapping = false;
            pieceSR.color = selectedColor;
            Color tmp = pieceSR.color;
            tmp.a = transparentAlpha;
            pieceSR.color = tmp;
        }
    }

    public void ToggleSelected()
    {
        isSelected = !isSelected;
        SetColor();
        
    }

    private void SetColor()
    {
        if (isSelected)
        {
            pieceSR.color = selectedColor;
            Color tmp = pieceSR.color;
            tmp.a = transparentAlpha;
            pieceSR.color = tmp;
        }
        else
        {
            pieceSR.color = defaultColor;
            Color tmp = pieceSR.color;
            tmp.a = solidAlpha;
            pieceSR.color = tmp;
        }
    }

    public bool IsOverlapping()
    {
        return isOverlapping;
    }

    public bool IsSelected()
    {
        return isSelected;
    }
}
