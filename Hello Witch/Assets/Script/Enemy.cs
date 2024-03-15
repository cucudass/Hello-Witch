using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Movement
{
    public GameObject[] itemSp;

    private void Start() {
        EnemySet();
    }

    void Update()
    {
        Move();
    }

    void EnemySet() {
        Transform[] children = GetComponentsInChildren<Transform>();
        foreach (Transform child in children) {
            if (child.name == "Wall") {
                child.GetComponent<Animator>().runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>($"Wall0{GameManager.instance.Num + 1}");
            }
            if (child.name == "Monster") {
                child.GetComponent<Animator>().runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>($"Monster0{GameManager.instance.Num + 1}");
            }
        }
    }
}
