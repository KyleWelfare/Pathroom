using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationLevelComplete : LevelComplete
{    
    [SerializeField] private Vector2[] rotatedCorrectPieceLocations;
    [SerializeField] private GameObject[] rotatedStageCompletePathBlocks;

    protected override void Awake()
    {
        base.Awake();
    }

    protected override void Update()
    {
        base.Update();

        for (int i = 0; i < puzzlePieces.Length; i++)
        {            
            if ((Vector2)puzzlePieces[i].transform.position == rotatedCorrectPieceLocations[i] && puzzlePieces[i].transform.eulerAngles.z == 180 && !puzzlePieces[i].IsSelected()) 
            {
                stageComplete = true;                
            }
            else
            {
                stageComplete = false;                
                break;
            }
        }

        if (stageComplete && stageNotYetCompleted)
        {
            Debug.Log("stage complete");
            StageComplete(rotatedStageCompletePathBlocks);
        }
    }
}
