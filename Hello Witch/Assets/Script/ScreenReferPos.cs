using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenReferPos : MonoBehaviour
{
    //화면 비율(16:9)
    Vector2 referenceResolution = new Vector2(16f, 9f);

    public void AdjustPostion() {
        //현재 화면 해상도의 가로 세로 비율을 계산
        float aspectRatio = (float)Screen.width / (float)Screen.height;
        //현재 배율을 기준 해상도의 비율로 나누어 스케일 팩터를 계산
        float scaleFactor = aspectRatio / (referenceResolution.x / referenceResolution.y);

        //오브젝트의 현재 위치를 새로운 위치로 수정
        Vector3 newPos = transform.position;
        newPos.x *= scaleFactor;
        newPos.y *= scaleFactor;

        transform.position = newPos;
    }
}
