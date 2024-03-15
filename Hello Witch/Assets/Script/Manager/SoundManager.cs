using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum Sfx { Jump = 0, Hit, Dead, Coin, Item, ButtonC }

public class SoundManager : Singleton<SoundManager>
{
    [Header("BGM")]
    public AudioClip bgmCilp;
    AudioSource bgmPlayer;
    public AudioSource Bgm => bgmPlayer; 

    [Header("SFX")]
    public AudioClip[] sfxCilps;
    AudioSource[] sfxPlayers;
    public AudioSource[] SFX => sfxPlayers;
    public int channels;
    int channelIndex;

    [Header("Volume")]
    [SerializeField] float BgmVolume = 0.6f;
    [SerializeField] float SfxVolume = 0.7f;

    protected override void Awake() {
        if (instance == null)
            instance = this;
        else {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);

        Init();
    }
    /*
    private void Start() {
        if (OptionPanel.activeSelf) {
            BgmSlider = OptionPanel.transform.Find("BgmSlider").GetComponentInChildren<Slider>();
            SfxSlider = OptionPanel.transform.Find("SfxSlider").GetComponentInChildren<Slider>();
        }
    }

    public void ChangeBgmSound() {
        bgmPlayer.volume = BgmSlider.value;
    }

    public void ChangeSfxSound() {
        foreach (var item in sfxPlayers) {
            item.volume = SfxSlider.value;
        }
    }
    */
    void Init() {
        //BGM
        GameObject bgmObject = new GameObject("bgmPlayer");
        bgmObject.transform.parent = transform;
        bgmPlayer = bgmObject.AddComponent<AudioSource>();
        bgmPlayer.loop = true;
        bgmPlayer.playOnAwake = false;
        bgmPlayer.volume = BgmVolume;
        bgmPlayer.clip = bgmCilp;

        //SFX
        GameObject sfxObject = new GameObject("sfxPlayer");
        sfxObject.transform.parent = transform;
        sfxPlayers = new AudioSource[channels];
        
        for (int i = 0; i < sfxPlayers.Length; i++) {
            sfxPlayers[i] = sfxObject.AddComponent<AudioSource>();
            sfxPlayers[i].playOnAwake = false;
            sfxPlayers[i].volume = SfxVolume;
            sfxPlayers[i].loop = false;
        }
    }

    public void PlayBgm(bool isPaly) {
        if (isPaly)
            bgmPlayer.Play();
        else
            bgmPlayer.Stop();
    }

    public void SfxPlayer(Sfx sfx) {
        for (int i = 0; i < sfxPlayers.Length; i++) {
            int loopIndex = (i + channelIndex) % sfxPlayers.Length;

            if (sfxPlayers[loopIndex].isPlaying)
                continue;

            channelIndex = loopIndex;
            sfxPlayers[channelIndex].clip = sfxCilps[(int)sfx];
            sfxPlayers[channelIndex].Play();
            break;
        }
    }
}
