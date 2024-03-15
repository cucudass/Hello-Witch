using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraResolution : MonoBehaviour
{
    private void Awake() {
        Camera cam = GetComponent<Camera>();

        Rect rt = cam.rect;

        //화면 비는 16:9
        float scale_height = ((float)Screen.width / Screen.height) / ((float)16f / 9f);
        float scale_width = 1f / scale_height;

        //비율 계산 공식
        if (scale_height < 1) {
            rt.height = scale_height;
            rt.y = (1f - scale_height) / 2f;
        } else {
            rt.width = scale_width;
            rt.x = (1f - scale_width) / 2f;
        }
        cam.rect = rt;
    }
    //여백 부분 검은색 처리
    //GL.Clear(깊이 삭제 여부, 색상 삭제 여부, 삭제된 영역의 배경 색상);
    void OnPreCull() => GL.Clear(true, true, Color.black);
}
