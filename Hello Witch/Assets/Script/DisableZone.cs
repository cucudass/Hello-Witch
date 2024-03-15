using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision) {
        Coin coin = collision.GetComponent<Coin>();
        if (coin != null)
            coin.gameObject.SetActive(false);

        Enemy enemy = collision.GetComponent<Enemy>();
        if (enemy != null)
            enemy.gameObject.SetActive(false);

        Item item = collision.GetComponent<Item>();
        if (item != null)
            item.gameObject.SetActive(false);
    }
}
