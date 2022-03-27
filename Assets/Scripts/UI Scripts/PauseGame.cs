using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{
    public static PauseGame instance;
    private bool isPaused;
    [SerializeField] private GameObject pauseScreen;

    void Awake()
    {
        instance = this;    
    }

    void Update()
    {
        if (Input.GetKeyDown("escape") && !LevelComplete.instance.IsStageCompleted()) {
            TogglePause();
        }
    }

    public void TogglePause()
    {
        if (!isPaused)
        {
            Time.timeScale = 0;
            pauseScreen.SetActive(true);
            isPaused = true;
        }
        else
        {
            Time.timeScale = 1;
            pauseScreen.SetActive(false);
            isPaused = false;
        }
    }

    public bool IsGamePaused()
    {
        return isPaused;
    }


}
