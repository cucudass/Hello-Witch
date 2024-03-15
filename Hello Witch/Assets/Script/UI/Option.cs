using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Option : MonoBehaviour
{
    [SerializeField] private Slider BgmSlider;
    [SerializeField] private Slider SfxSlider;

    FullScreenMode screenMode;
    public Toggle fullscreenBtn;
    public Dropdown resolutiondropdown;
    List<Resolution> resolutions = new List<Resolution>();
    int resolutionNum;

    private void OnEnable() {
        BgmSlider.value = SoundManager.instance.Bgm.volume;
        SfxSlider.value = SoundManager.instance.SFX[0].volume;

        //InitUI();
    }

    void Start() {
        BgmSlider = transform.Find("BgmSlider").GetComponentInChildren<Slider>();
        SfxSlider = transform.Find("SfxSlider").GetComponentInChildren<Slider>();
    }

    public void ChangeBgmSound() {
        SoundManager.instance.Bgm.volume = BgmSlider.value;
    }

    public void ChangeSfxSound() {
        foreach (var item in SoundManager.instance.SFX) {
            item.volume = SfxSlider.value;
        }
    }

    public void ResetVolum() {
        BgmSlider.value = 0.6f;
        SfxSlider.value = 0.7f;

        //Reset
        SoundManager.instance.Bgm.volume = BgmSlider.value;
        foreach (var item in SoundManager.instance.SFX) {
            item.volume = SfxSlider.value;
        }
    }

    void InitUI() {
        for (int i = 0; i < Screen.resolutions.Length; i++) {//해당 모니터의 해상도를 가져와서 추가
            if (Screen.resolutions[i].refreshRate > 60)
                resolutions.Add(Screen.resolutions[i]);
        }
        resolutions.AddRange(Screen.resolutions);
        resolutiondropdown.options.Clear(); //드롭다운 초기화

        int optionNum = 0; //처음에 초기화
        foreach (Resolution item in resolutions) {
            Dropdown.OptionData option = new Dropdown.OptionData();
            option.text = $"{item.width} x {item.height}";
            resolutiondropdown.options.Add(option);

            if (item.width == Screen.currentResolution.width && item.height == Screen.currentResolution.height)
                resolutiondropdown.value = optionNum;
            optionNum++;
        }
        resolutiondropdown.RefreshShownValue(); //드롭다운이 변경되었으니 새로고침
        fullscreenBtn.isOn = Screen.fullScreenMode.Equals(FullScreenMode.FullScreenWindow) ? true : false;
    }

    public void DropboxOptionChange(int x) {
        resolutionNum = x;
    }

    public void Active() {
        gameObject.SetActive(true);
    }

    public void FullBtn(bool isFull) {
        screenMode = isFull ? FullScreenMode.FullScreenWindow : FullScreenMode.Windowed;
    }

    public void OkBtnClick() {
        Screen.SetResolution(resolutions[resolutionNum].width, resolutions[resolutionNum].height, screenMode);
    }

    public void Disable() {
        gameObject.SetActive(false);
        GameManager.instance.isInGame = false;
    }
}
