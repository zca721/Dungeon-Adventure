using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{

    [SerializeField]
    TextMeshProUGUI textPillarsCount, textVictoryCondition;

    [SerializeField]
    GameObject victoryCondition;
    private static UIManager instance;
    private void Awake() {
        if (instance == null) {
            instance = this;
        } else {
            DestroyImmediate(this);
        }
    }

    public static UIManager MyInstance {
        get {
            if (instance == null)
                instance = new UIManager();

            return instance;
        }
    }

    public void UpdatePillarUI(int pillars, int victory) {
        textPillarsCount.text = "Pillars " + pillars + " out of " + victory;
    }

    public void ShowVictoryCondition(int pillars, int victory) {
        victoryCondition.SetActive(true);
        textVictoryCondition.text = "Need " + (victory - pillars) + " pillars to exit";
    }

    public void HideVictoryCondition() {
        victoryCondition.SetActive(false);
    }
}
