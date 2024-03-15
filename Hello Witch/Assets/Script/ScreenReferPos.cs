using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenReferPos : MonoBehaviour
{
    //ȭ�� ����(16:9)
    Vector2 referenceResolution = new Vector2(16f, 9f);

    public void AdjustPostion() {
        //���� ȭ�� �ػ��� ���� ���� ������ ���
        float aspectRatio = (float)Screen.width / (float)Screen.height;
        //���� ������ ���� �ػ��� ������ ������ ������ ���͸� ���
        float scaleFactor = aspectRatio / (referenceResolution.x / referenceResolution.y);

        //������Ʈ�� ���� ��ġ�� ���ο� ��ġ�� ����
        Vector3 newPos = transform.position;
        newPos.x *= scaleFactor;
        newPos.y *= scaleFactor;

        transform.position = newPos;
    }
}
