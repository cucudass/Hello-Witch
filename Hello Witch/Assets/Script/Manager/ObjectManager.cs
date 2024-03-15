using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    [SerializeField] private Transform spawnPos;

    [Header("Enemy")]
    public GameObject[] EenmyPrefabs;
    [SerializeField] private int epSize = 8;
    List<GameObject>[] EnemyPool;

    [Header("Coin")]
    public GameObject[] CoinPrefabs;
    [SerializeField] private int coSize = 5;
    List<GameObject>[] CoinPool;

    [Header("Item")]
    public GameObject[] ItemPrefabs;
    [SerializeField] private int itSize = 5;
    List<GameObject>[] ItemPool;

    List<GameObject>[] objectPool;
    int obSize = 0;

    WaitForSeconds wait = new WaitForSeconds(3f);
    int eIndex = 0, spIndex = 0, cIndex = 0, itemIndex = 0, ran = 0;
    Enemy enemy;

    private void Awake() {
        EnemyPool = new List<GameObject>[EenmyPrefabs.Length];
        ItemPool = new List<GameObject>[ItemPrefabs.Length];
        CoinPool = new List<GameObject>[CoinPrefabs.Length];

        //AdjustPostion();
    }

    private void OnEnable() {
        if (!GameManager.instance.isSpawn) {
            Generate();
            GameManager.instance.isSpawn = true;
        }
    }

    void Start() {
        StartCoroutine(SpawnEenmy());
    }

    IEnumerator SpawnEenmy() {
        while (!GameManager.instance.isDead) {
            eIndex = UnityEngine.Random.Range(0, EenmyPrefabs.Length);
            GameObject EnemyObject = MakeObj("E", eIndex);
            EnemyObject.transform.position = spawnPos.transform.position;
            EnemyObject.SetActive(true);
            enemy = EnemyObject.GetComponent<Enemy>();

            ran = UnityEngine.Random.Range(0, 10);

            if (enemy.itemSp.Length == 1)
                spIndex = 0;
            else
                spIndex = UnityEngine.Random.Range(0, enemy.itemSp.Length);

            //Item
            if (ran == 0) {
                itemIndex = UnityEngine.Random.Range(0, ItemPrefabs.Length);

                GameObject itemObject = MakeObj("I", itemIndex);
                itemObject.transform.position = enemy.itemSp[spIndex].transform.position;
            } else {
                //Coin
                cIndex = UnityEngine.Random.Range(0, CoinPrefabs.Length);

                GameObject coinObject = MakeObj("C", cIndex);
                coinObject.transform.position = enemy.itemSp[spIndex].transform.position;
                coinObject.GetComponent<Coin>().ActiveResetChildPosition();
            }
            yield return wait;
        }
    }

    void Generate() {
        //Enemy Pool
        for (int i = 0; i < EenmyPrefabs.Length; i++) {
            EnemyPool[i] = new List<GameObject>();
            for (int j = 0; j < epSize; j++) {
                GameObject obj = Instantiate(EenmyPrefabs[i]);
                obj.transform.parent = gameObject.transform;
                obj.SetActive(false);
                EnemyPool[i].Add(obj);
            }
        }
        //Coin Pool
        for (int i = 0; i < CoinPrefabs.Length; i++) {
            CoinPool[i] = new List<GameObject>();
            for (int j = 0; j < coSize; j++) {
                GameObject obj = Instantiate(CoinPrefabs[i]);
                obj.transform.parent = gameObject.transform;
                obj.SetActive(false);
                CoinPool[i].Add(obj);
            }
        }

        //Item Pool
        for (int i = 0; i < ItemPrefabs.Length; i++) {
            ItemPool[i] = new List<GameObject>();
            for (int j = 0; j < itSize; j++) {
                GameObject obj = Instantiate(ItemPrefabs[i]);
                obj.transform.parent = gameObject.transform;
                obj.SetActive(false);
                ItemPool[i].Add(obj);
            }
        }
    }

    public GameObject MakeObj(string type, int index) {
        switch (type) {
            case "E":
                objectPool = EnemyPool;
                obSize = epSize;
                break;
            case "C":
                objectPool = CoinPool;
                obSize = coSize;
                break;
            case "I":
                objectPool = ItemPool;
                obSize = itSize;
                break;
        }

        for (int i = 0; i < objectPool[index].Count; i++) {
            if (!objectPool[index][i].activeSelf) {
                objectPool[index][i].SetActive(true);

                return objectPool[index][i];
            }
        }
        return AddObject(objectPool[index][0]);
    }

    public GameObject AddObject(GameObject addObject) {
        GameObject obj = Instantiate(addObject);
        obj.transform.parent = gameObject.transform;
        obj.SetActive(true);

        return obj;
    }

    public void ActivateObjectAndChildren(GameObject parentObject) {
        parentObject.SetActive(true);
        foreach (Transform child in parentObject.transform) {
            child.gameObject.SetActive(true);
        }
    }

    public void ReturnObj(GameObject obj) {
        obj.SetActive(false);
    }
}
