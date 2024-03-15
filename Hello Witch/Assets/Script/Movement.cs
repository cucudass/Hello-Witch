using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 2.5f;

    public void Move() {
        if(!GameManager.instance.isDead)
            transform.position += Vector3.left * speed * Time.deltaTime;
    }
}
