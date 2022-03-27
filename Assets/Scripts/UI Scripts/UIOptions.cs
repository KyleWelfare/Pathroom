using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIOptions : MonoBehaviour
{
    private Scene scene;

    void Awake()
    {
        scene = SceneManager.GetActiveScene();
    }

    public void NewGame()
    {
        SceneManager.LoadScene(1);

        if (PauseGame.instance.IsGamePaused())
        {
            PauseGame.instance.TogglePause();
        }
    }

    public void ResetStage()
    {
        SceneManager.LoadScene(scene.name);

        if (PauseGame.instance.IsGamePaused())
        {
            PauseGame.instance.TogglePause();
        }
    }

    public void NextStage()
    {
        if (scene.buildIndex == SceneManager.sceneCountInBuildSettings - 1)
        {
            SceneManager.LoadScene(0);
        }
        else
        {
            SceneManager.LoadScene(scene.buildIndex + 1);
        }
    }
}
