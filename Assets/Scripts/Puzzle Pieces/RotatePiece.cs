using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePiece : MonoBehaviour
{
    private PuzzlePiece puzzlePieceScript;
    private float currentRotation;

    private void Awake()
    {
        puzzlePieceScript = GetComponent<PuzzlePiece>();        
    }

    void Update()
    {
        if (puzzlePieceScript.IsSelected() && !LevelComplete.instance.IsStageCompleted() && !PauseGame.instance.IsGamePaused())
        {
            if (Input.GetKeyDown("space"))
            {
                FMODUnity.RuntimeManager.PlayOneShot("event:/Fx/Rotation");
                transform.Rotate(0, 0, 90);
            }
        }
    }
}
