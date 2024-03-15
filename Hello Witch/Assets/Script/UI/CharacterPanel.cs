using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterPanel : MonoBehaviour
{
    [SerializeField] Sprite[] sprites;
    [SerializeField] RuntimeAnimatorController[] animCon;
    [SerializeField] RuntimeAnimatorController[] StartCon;
    [SerializeField] Image CharacterImage;

    void Awake()
    {
        CharacterImage.sprite = sprites[0];
    }

    public void SelectChar(int num) {
        CharacterImage.sprite = sprites[num];
        GameManager.instance.AnimCon = animCon[num];
    }

    public void CharPanelOpen() {
        gameObject.SetActive(true);
    }

    public void CharPanelExit() {
        gameObject.SetActive(false);
    }
}
