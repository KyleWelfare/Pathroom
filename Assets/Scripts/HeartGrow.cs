using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartGrow : MonoBehaviour
{
    private float growRate = 0.7f;
    private float shrinkRate = 0.3f;

    private bool isShrinking = false;
    private bool isGrowing = true;

    private bool hasPlayedSound;

    [SerializeField] protected GameObject nextStageButton;
    void Update()
    {
        if (isGrowing && !isShrinking)
        {
            transform.localScale = new Vector2(transform.localScale.x + growRate * Time.deltaTime, transform.localScale.y + growRate * Time.deltaTime);            

            if (transform.localScale.x >= 1.3f)
            {
                isShrinking = true;
                isGrowing = false;
                growRate = 0.4f;
            }
        }

        if (isShrinking)
        {
            if (!hasPlayedSound)
            {
                FMODUnity.RuntimeManager.PlayOneShot("event:/Fx/Puzzle Complete");
                hasPlayedSound = true;
            }

            nextStageButton.SetActive(true);
            if (transform.localScale.x > 1.1)
            {
                transform.localScale = new Vector2(transform.localScale.x - shrinkRate * Time.deltaTime, transform.localScale.y - shrinkRate * Time.deltaTime);
            }

            if (transform.localScale.x <= 1.1)
            {
                isShrinking = false;
                isGrowing = true;
            }
        }
    }
}
