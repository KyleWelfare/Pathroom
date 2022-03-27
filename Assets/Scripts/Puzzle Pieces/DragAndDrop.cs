using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    [SerializeField] private GameObject selectedPuzzlePiece;
    [SerializeField] private GameObject gridDisplay;
    [SerializeField] private GameObject pillar1;
    [SerializeField] private GameObject pillar2;    

    void Update()
    {
        if (!LevelComplete.instance.IsStageCompleted())
        {
            if (selectedPuzzlePiece == null)
            {
                if (Input.GetMouseButtonDown(0) && !PauseGame.instance.IsGamePaused())
                {
                    RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

                    if (hit)
                    {
                        if (hit.collider.CompareTag("PuzzlePiece"))
                        {
                            FMODUnity.RuntimeManager.PlayOneShot("event:/Fx/Pick Up");

                            selectedPuzzlePiece = hit.transform.gameObject;                            
                            selectedPuzzlePiece.GetComponent<SpriteRenderer>().sortingOrder = 10;
                            selectedPuzzlePiece.GetComponent<PuzzlePiece>().ToggleSelected();
                            gridDisplay.SetActive(true);

                            Color tmp = pillar1.GetComponent<SpriteRenderer>().color;
                            tmp.a = 0.5f;
                            pillar1.GetComponent<SpriteRenderer>().color = tmp;
                            pillar2.GetComponent<SpriteRenderer>().color = tmp;
                        }
                    }
                }
            }

            else
            {
                Vector3 MousePoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                if (!PauseGame.instance.IsGamePaused())
                    selectedPuzzlePiece.transform.position = new Vector3(Mathf.Round(MousePoint.x), Mathf.Round(MousePoint.y), 0);

                if (Input.GetMouseButtonDown(0) && !selectedPuzzlePiece.GetComponent<PuzzlePiece>().IsOverlapping() && !PauseGame.instance.IsGamePaused())
                {
                    FMODUnity.RuntimeManager.PlayOneShot("event:/Fx/Put Down");

                    selectedPuzzlePiece.GetComponent<SpriteRenderer>().sortingOrder = 0;
                    selectedPuzzlePiece.GetComponent<PuzzlePiece>().ToggleSelected();
                    selectedPuzzlePiece = null;
                    gridDisplay.SetActive(false);

                    Color tmp = pillar1.GetComponent<SpriteRenderer>().color;
                    tmp.a = 1.0f;
                    pillar1.GetComponent<SpriteRenderer>().color = tmp;
                    pillar2.GetComponent<SpriteRenderer>().color = tmp;
                }
                else if (Input.GetMouseButtonDown(0) && selectedPuzzlePiece.GetComponent<PuzzlePiece>().IsOverlapping())
                {
                    FMODUnity.RuntimeManager.PlayOneShot("event:/Fx/Unsucessful Place");
                }
            }
        }
    }
}
