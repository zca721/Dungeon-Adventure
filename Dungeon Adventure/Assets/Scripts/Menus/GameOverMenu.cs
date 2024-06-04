using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    public void RestartButton() {
        // SceneManager.LoadScene("Scene 1");
        // Gives the scene that the player is in
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MainMenuButton() {
        SceneManager.LoadScene("Main Menu");
    }
}
