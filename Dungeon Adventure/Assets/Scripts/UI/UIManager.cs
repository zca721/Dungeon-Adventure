using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour {
    [SerializeField]
    TextMeshProUGUI textPillarsCount, textVictoryCondition, textGameOver;

    [SerializeField]
    GameObject pillarCondition, victoryCondition, gameOverCondition, gameOverBackGroundCondition, restartCondition, mainMenuCondition;
    private static UIManager instance;

    public static UIManager MyInstance {
        get {
            if (instance == null)
                instance = new UIManager();

            return instance;
        }
    }

    private void Awake() {
        if (instance == null) {
            instance = this;
        } else {
            DestroyImmediate(this);
        }
    }

    public void UpdatePillarUI(int pillars, int victory) {
        textPillarsCount.text = "Pillars " + pillars + " out of " + victory;
    }

    public void HidePillarUI() {
        pillarCondition.SetActive(false);
    }

    public void ShowVictoryCondition(int pillars, int victory) {
        victoryCondition.SetActive(true);
        textVictoryCondition.text = "Need " + (victory - pillars) + " pillars to exit";
    }

    public void HideVictoryCondition() {
        victoryCondition.SetActive(false);
    }

    public void ShowGameOver() {
        gameOverCondition.SetActive(true);
        gameOverBackGroundCondition.SetActive(true);
        restartCondition.SetActive(true);
        mainMenuCondition.SetActive(true);
        // textGameOver.text = "GAME OVER";
    }
}
