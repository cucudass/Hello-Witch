using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : Movement
{
    [SerializeField] Transform[] childObject;
    [SerializeField] Vector3[] savePosition;

    private void Awake() {
        ChildPosition();
    }

    void Update()
    {
        Move();
    }
    /*
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "DZ") {
            ObjectManager.instance.ReturnObj(gameObject);
        }
    }
    */
    void ChildPosition() {
        savePosition = new Vector3[childObject.Length];

        for (int i = 0; i < childObject.Length; i++) {
            savePosition[i] = childObject[i].localPosition;
        }
    }

    public void ActiveResetChildPosition() {
        for (int i = 0; i < childObject.Length; i++) {
            childObject[i].gameObject.SetActive(true);
            childObject[i].localPosition = savePosition[i];
        }
    }
}
