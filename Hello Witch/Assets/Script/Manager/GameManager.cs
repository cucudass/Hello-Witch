using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager> {
    public bool isDead = false;
    public bool isStart = false;
    public bool isInGame = false;
    public bool isSpawn = false;

    public int coinCnt = 0;
    float playTime;

    public GameObject ExitPanel;
    Transform parent;

    [Header("Character")]
    RuntimeAnimatorController animCon;
    RuntimeAnimatorController startCon;
    public RuntimeAnimatorController AnimCon {
        set { animCon = value; }
        get { return animCon; }
    }

    [Header("Map&Enemy")]
    Texture texture;
    int num;
    public Texture GetTexture {
        set { texture = value; }
        get { return texture; }
    }
    public int Num {
        set { num = value; }
        get { return num; }
    }

    private void Start() {
        if (!PlayerPrefs.HasKey("coinCnt"))
            PlayerPrefs.SetInt("coinCnt", coinCnt);
    }
    public void GameStart() {
        isStart = true;
        //NowScoreText.text = "0";
        SoundManager.instance.PlayBgm(true);
    }

    void Update()
    {
        if (!isDead)
            playTime += Time.deltaTime;

        if (isInGame) Time.timeScale = 0;
        else Time.timeScale = 1;

        MobileBackButton();
    }

    private void LateUpdate() {
        //Time UI
        int hour = (int)(playTime / 3600);
        int min = (int)((playTime - hour * 3600) / 60);
        int second = (int)(playTime % 60);
        //playtimeText.text = string.Format("{0:00}", hour) + ":" + string.Format("{0:00}", min) + ":" + string.Format("{0:00}", second);

        //Coin Cnt UI
        //coinText.text = string.Format("{0:N0}", coinCnt);
    }

    public void GameStartPanel() {
        SceneLoader.instance.LoadScene(SceneID.TITLE);
        SoundManager.instance.PlayBgm(false);
    }

    public void Quit() {
        Application.Quit();
    }

    public void MobileBackButton() {
        if(Input.GetKeyDown(KeyCode.Escape)) {
            isInGame = true;
            if (ExitPanel == null) {
                parent = GameObject.Find("UI").GetComponent<Transform>();
                ExitPanel = Instantiate(Resources.Load<GameObject>("ExitPanel"), parent);
            } else {
                ExitPanel.SetActive(true);
            }
        }
    }
}
