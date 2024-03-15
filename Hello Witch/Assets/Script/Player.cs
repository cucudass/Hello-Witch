using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private float UpPower;
    [SerializeField] private GameObject MagnetZone;

    bool isSuper;
    bool fDown;

    Rigidbody2D rigid;
    Animator anim;
    SpriteRenderer sprite;
    Vector3 newPos;
    WaitForSeconds itemTime = new WaitForSeconds(10f);

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();

        //AdjustPostion();
    }

    private void OnEnable() {
        if(GameManager.instance.AnimCon != null)
            anim.runtimeAnimatorController = GameManager.instance.AnimCon;
    }

    void Update()
    {
        GetInput();
        PlayerUp();
        rigid.gravityScale = 0.5f;
    }
    
    void GetInput() {
        fDown = Input.GetButtonDown("Fire1");
    }

    void PlayerUp() {
        if (fDown && !GameManager.instance.isDead) {
            anim.SetBool("isJump", true);
            rigid.velocity = Vector2.up * UpPower;
            SoundManager.instance.SfxPlayer(Sfx.Jump);
            Invoke("PlayerRun", 1f);
        }
    }

    void PlayerRun() {
        anim.SetBool("isJump", false);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        switch (collision.tag) {
            case "Enemy":
                if (!isSuper) {
                    GameManager.instance.isDead = true;
                    anim.SetTrigger("onDefeat");
                    SoundManager.instance.SfxPlayer(Sfx.Dead);
                    gameObject.SetActive(false);
                }
                break;
            case "Coin":
                if (!GameManager.instance.isDead) {
                    GameManager.instance.coinCnt += 10;
                    SoundManager.instance.SfxPlayer(Sfx.Coin);
                    collision.gameObject.SetActive(false);
                }
                break;
            case "Item":
                if (!GameManager.instance.isDead) {
                    SoundManager.instance.SfxPlayer(Sfx.Item);
                    collision.gameObject.SetActive(false);

                    if (collision.name.Contains("item_magnet")) {
                        StartCoroutine("MagnetSet");
                    }
                    if(collision.name.Contains("item_super")) {
                        StartCoroutine("SuerSet");
                    }
                }
                break;
        }
    }

    IEnumerator MagnetSet() {
        MagnetZone.SetActive(true);
        yield return itemTime;

        MagnetZone.SetActive(false);
        yield return null;
    }

    IEnumerator SuerSet() {
        isSuper = true;
        sprite.color = new Color(1, 1, 1, 0.5f);

        yield return itemTime;

        sprite.color = new Color(1, 1, 1, 1);
        isSuper = false;
    }
}
