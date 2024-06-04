using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinnerMenu : MonoBehaviour {
    public void MainMenuButton() {
        SceneManager.LoadScene("Main Menu");
    }

    public void QuitGameButton() {
        Application.Quit();
        Debug.Log("Game Closed");
    }
}
