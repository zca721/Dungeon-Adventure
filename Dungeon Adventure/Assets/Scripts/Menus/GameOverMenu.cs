using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    public void RestartButton() {
        SceneManager currentScene = new SceneManager();

        // if (SceneManager.ReferenceEquals("Scene 1", "Scene 1")) {
        //     SceneManager.LoadScene("Scene 1");
        //     Debug.Log(currentScene.Equals("Scene 1"));
        //     Debug.Log(SceneManager.ReferenceEquals("Scene 1", "Scene 1"));
        // } else if (SceneManager.ReferenceEquals("Scene 2", "Scene 2")) {
        //     SceneManager.LoadScene("Scene 2"); 
        // }
        SceneManager.LoadScene("Scene 1");
        // Scene.Equals("Scene 1", "Scene 1");
        // SceneManager currentScene = new SceneManager();
        // currentScene.Equals("Scene 1");
    }

    public void MainMenuButton() {
        SceneManager.LoadScene("Main Menu");
    }
}
