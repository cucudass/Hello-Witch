using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : Movement
{   
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
}
