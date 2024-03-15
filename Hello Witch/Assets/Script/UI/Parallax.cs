using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Parallax : MonoBehaviour
{
    [SerializeField] Rect rect;
    [SerializeField] RawImage rawImage;

    [SerializeField] float speed = 0.25f;

    private void Awake() {
        rawImage = GetComponent<RawImage>();
    }
    
    private void OnEnable() {
        if(GameManager.instance.GetTexture != null)
            rawImage.texture = GameManager.instance.GetTexture;
    }
    
    void Update()
    {
        if (!GameManager.instance.isDead) {
            rect = rawImage.uvRect;
            rect.x += Time.deltaTime * speed;

            rawImage.uvRect = rect;
        }
    }
}
