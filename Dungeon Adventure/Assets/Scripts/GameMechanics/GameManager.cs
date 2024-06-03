using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static int collectedPillars = 0;

    private static int victoryCondition = 4;

    public static int levelCounter = 0;

    // private static GameManager instance;
    // private static GameManager instance;
    // private void Awake() {
    //     if (instance == null) {
    //         instance = this;
    //     } else {
    //         DestroyImmediate(this);
    //     }
    // }

    // public static GameManager MyInstance {
    //     get {
    //         if (instance == null)
    //             instance = new GameManager();

    //         return instance;
    //     }
    // }

    private void Start() {
        UIManager.MyInstance.UpdatePillarUI(collectedPillars, victoryCondition);
    }
    
    public static void AddPillars(int pillars) {
        collectedPillars += pillars;
        Debug.Log(collectedPillars);
        UIManager.MyInstance.UpdatePillarUI(collectedPillars, victoryCondition);
    }

    public static void Finish() {
        if (collectedPillars >= victoryCondition && levelCounter == 0) {
            collectedPillars = 0;
            // levelCounter++;
            SceneManager.LoadScene("Winner Menu");
        } else if (collectedPillars >= victoryCondition && levelCounter == 1) {
            SceneManager.LoadScene("Winner Menu");
        } else {
            UIManager.MyInstance.ShowVictoryCondition(collectedPillars, victoryCondition);
        }
    }
}
