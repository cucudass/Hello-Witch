using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapSelect : MonoBehaviour
{
    [SerializeField] public Sprite[] MapSprites;

    public void SelectMap(int num) {
        GameManager.instance.GetTexture = MapSprites[num].texture;
        GameManager.instance.Num = num;
    }

    public void MapPanelOpen() {
        gameObject.SetActive(true);
    }

    public void MapPanelExit() {
        gameObject.SetActive(false);
    }
}
