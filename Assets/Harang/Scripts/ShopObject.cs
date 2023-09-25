using System.Collections;
using System.Collections.Generic;
using System.Security;
using UnityEngine;

public class ShopObject : MonoBehaviour
{
    public GameObject sellItemPrefab;
    [SerializeField] private Transform[] spawnPoints;

    [SerializeField] private GameObject[] sellItems;
    [SerializeField] private int itemPrice;

    private bool startSeed = false;

    private int itemCount = 1;

    private GameObject honeyOut;

    private void Start()
    {
        honeyOut = GameObject.Find("HoneyOut");

        sellItems = new GameObject[spawnPoints.Length];

        for (int i = 0; i < spawnPoints.Length; i++)
        {
            SellItemSpawn(i, 0);
        }
    }

    private void Update()
    {
        //if (honeyOut.GetComponent<HoneyOut>().CurrentBigHoney / honeyOut.GetComponent<HoneyOut>().MaxBigHoney >= itemCount * 0.1 && itemCount < 7)
        //{
        //    SellItemSpawn(itemCount - 1, 0);
        //    itemCount++;
        //}
    }

    IEnumerator SellItemSpawn(int itemNum, float Time)
    {
        yield return new WaitForSeconds(Time);

        sellItems[itemNum] = Instantiate(sellItemPrefab);
        sellItems[itemNum].transform.position = spawnPoints[itemNum].transform.position;
        sellItems[itemNum].transform.rotation = spawnPoints[itemNum].transform.rotation;
    }
}