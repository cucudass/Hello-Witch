using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetItem : MonoBehaviour
{
    public float magnetFoce = 10f;
    [SerializeField] private Transform playerPos;
    public Transform PlayerTras => playerPos;

    private void OnEnable() {
        transform.position = playerPos.position;
    }

    private void Update() {
        transform.position = playerPos.position;
    }
}
