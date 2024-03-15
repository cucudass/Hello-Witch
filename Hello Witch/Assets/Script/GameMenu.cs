using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameMenu : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] GameObject GameOverUI;
    [SerializeField] GameObject OptionUI;

    [Header("TEXT")]
    [SerializeField] Text CoinText; //°ÔÀÓ»ó´Ü
    [SerializeField] Text bestText; //best ¹®±¸
    [SerializeField] Text NowScoreText; //È¹µæ Á¡¼ö;

    [Header("DZ")]
    [SerializeField] GameObject RetryDZ;

    private void OnEnable() {
        GameOverUI.SetActive(false);
        OptionUI.SetActive(false);
        RetryDZ.SetActive(false);
        CoinText.text = "0";
        GameManager.instance.coinCnt = 0;
        SoundManager.instance.PlayBgm(true);
    }

    void Update()
    {
        ActiveOverUI();
        ActiveDZ();
    }

    private void LateUpdate() {
        CoinText.text = string.Format("{0:N0}", GameManager.instance.coinCnt);
    }

    public void ActiveOverUI() {
        if (GameManager.instance.isDead)
            StartCoroutine("GameOverRoutine");
    }
    IEnumerator GameOverRoutine() {
        yield return null;

        SoundManager.instance.PlayBgm(false);
        CoinCntSet();
        GameOverSet();
    }
    void CoinCntSet() {
        int score = GameManager.instance.coinCnt;
        if (PlayerPrefs.GetInt("coinCnt") < score) {
            bestText.gameObject.SetActive(PlayerPrefs.GetInt("coinCnt") < score);
            PlayerPrefs.SetInt("coinCnt", score);
        }
        NowScoreText.text = string.Format("{0:N0}", score);
    }
    void GameOverSet() {
        GameOverUI.SetActive(true);
    }

    public void ActiveDZ() {
        RetryDZ.SetActive(GameManager.instance.isDead);
    }

    public void ActiveOptionUI() {
        OptionUI.SetActive(true);
        GameManager.instance.isInGame = true;
    }
    public void DisableOptionUI() {
        OptionUI.SetActive(false);
        GameManager.instance.isInGame = false;
    }
    public void TitleScene() {
        SoundManager.instance.PlayBgm(false);
        GameManager.instance.isInGame = false;
        GameManager.instance.isDead = false;
        GameManager.instance.isSpawn = false;
        //GameManager.instance.coinCnt = 0;

        SceneLoader.instance.LoadScene(SceneID.TITLE);
    }

    public void GameRestart() {
        //CoinText.text = "0";
        GameManager.instance.isDead = false;
        GameManager.instance.isSpawn = false;
        SceneLoader.instance.LoadScene(SceneID.GAME);
    }
}
