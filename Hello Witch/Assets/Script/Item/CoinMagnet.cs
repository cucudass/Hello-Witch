using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinMagnet : MonoBehaviour
{
    public float magnetStrength = 5;
    public float distanceStretch = 10f;

    private bool magnetZone;
    private Transform magnetTrans;

    Rigidbody2D rigid;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        if (magnetZone) {
            Vector2 dir = magnetTrans.position - transform.position;
            float distance = Vector2.Distance(magnetTrans.position, transform.position);
            float magnetDistanceStr = (distanceStretch / distance) * magnetStrength;
            rigid.AddForce(magnetDistanceStr * dir, ForceMode2D.Force);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Magnet") {
            magnetTrans = collision.transform;
            magnetZone = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.tag == "Magnet") {
            magnetZone = false;
        }
    }
}
