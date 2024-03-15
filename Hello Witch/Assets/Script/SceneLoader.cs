using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum SceneID { TITLE, GAME }
public class SceneLoader : Singleton<SceneLoader>
{
    public void LoadScene(SceneID sceneID) {
        SceneManager.LoadScene((int)sceneID);
        GameManager.instance.ExitPanel = null;
    }
}
