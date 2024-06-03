using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    public void RestartButton() {
        SceneManager.LoadScene("Scene 1");
    }

    public void MainMenuButton() {
        SceneManager.LoadScene("Main Menu");
    }
}
