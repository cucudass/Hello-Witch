using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] Button startButton;

    public void Execute() {
        startButton.interactable = false;
        SceneLoader.instance.LoadScene(SceneID.GAME);
    }

    public void Exit() {
        Application.Quit();
    }
}
