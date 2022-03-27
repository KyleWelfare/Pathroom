using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelComplete : MonoBehaviour
{
    public static LevelComplete instance;

    [SerializeField] protected PuzzlePiece[] puzzlePieces;    
    [SerializeField] protected Vector2[] correctPieceLocations;

    [SerializeField] protected GameObject[] stageCompletePathBlocks;

    protected bool stageNotYetCompleted = true;
    protected bool stageComplete = false;

    [SerializeField] protected GameObject heart;    

    protected virtual void Awake()
    {
        instance = this;
    }

    protected virtual void Update()
    {        
        for (int i = 0; i < puzzlePieces.Length; i++)
        {
            if ((Vector2)puzzlePieces[i].transform.position == correctPieceLocations[i] && (puzzlePieces[i].transform.eulerAngles.z == 0 || puzzlePieces[i].transform.eulerAngles.z == 360) && !puzzlePieces[i].IsSelected()) //
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
            StageComplete(stageCompletePathBlocks);
        }
    }

    protected void StageComplete(GameObject[] stageCompletePathBlocks)
    {
        stageNotYetCompleted = false;
        StartCoroutine(StageCompleteCo(stageCompletePathBlocks));        
    }

    protected IEnumerator StageCompleteCo(GameObject[] stageCompletePathBlocks)
    {
        float timeBetweenBlockActivation = 0.3f;
        float reductionInTimeBetweenBlockActivation = 0.05f;

        for (int i = 0; i < stageCompletePathBlocks.Length; i += 2)
        {
            stageCompletePathBlocks[i].SetActive(true);
            if (i + 1 <= stageCompletePathBlocks.Length - 1)
            {
                stageCompletePathBlocks[i + 1].SetActive(true);
                FMODUnity.RuntimeManager.PlayOneShot("event:/Fx/Victory Path");
            }
            yield return new WaitForSeconds(timeBetweenBlockActivation);
            timeBetweenBlockActivation -= reductionInTimeBetweenBlockActivation;
            reductionInTimeBetweenBlockActivation *= 0.8f;
        }

        heart.SetActive(true);                
    }

    public bool IsStageCompleted()
    {
        return !stageNotYetCompleted;
    }
}
