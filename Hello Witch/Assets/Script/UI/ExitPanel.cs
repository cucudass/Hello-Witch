using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitPanel : MonoBehaviour
{
    public void OKButton() {
        Application.Quit();
    }

    public void CancelButton() {
        gameObject.SetActive(false);
        GameManager.instance.isInGame = false;
    }
}
