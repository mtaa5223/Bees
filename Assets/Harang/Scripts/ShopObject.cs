using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopObject : MonoBehaviour
{
    public GameObject sellItemPrefab;
    [SerializeField] private Transform[] spawnPoints;

    private GameObject[] sellItems;
    [SerializeField] private int itemPrice;

    private GameObject honeyOut;

    private void Start()
    {
        honeyOut = GameObject.Find("HoneyOut");

        sellItems = new GameObject[spawnPoints.Length];
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            StartCoroutine(SellItemSpawn(i, 0));
        }
    }

    private void Update()
    {
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            if (sellItems[i] == null)
            {
                StartCoroutine(SellItemSpawn(i, 0));
            }    
        }

        if (honeyOut.GetComponent<HoneyOut>().CurrentBigHoney >= itemPrice)
        {
            foreach (GameObject sellItem in sellItems)
            {
                sellItem.GetComponent<OVRGrabbable>().isNotGrabObject = true;
            }
        }
        else
        {
            for (int i = 0; i < spawnPoints.Length; i++)
            {
                sellItems[i].GetComponent<OVRGrabbable>().isNotGrabObject = false;
                if (sellItems[i].GetComponent<OVRGrabbable>().isGrabbed)
                {
                    honeyOut.GetComponent<HoneyOut>().CurrentBigHoney -= itemPrice;
                    sellItems[i] = null;
                }
            }
        }
    }

    IEnumerator SellItemSpawn(int itemNum, float Time)
    {
        sellItems[itemNum] = Instantiate(sellItemPrefab);
        sellItems[itemNum].transform.position = spawnPoints[itemNum].transform.position;
        sellItems[itemNum].transform.rotation = spawnPoints[itemNum].transform.rotation;

        yield return new WaitForSeconds(Time);
    }
}