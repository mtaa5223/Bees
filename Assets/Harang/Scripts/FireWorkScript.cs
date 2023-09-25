using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class FireWorkScript : MonoBehaviour
{
    public GameObject[] spawnPoint;
    public GameObject[] fireWork;
    [SerializeField] private GameObject honeyOut;
    private bool isFireWork;

    private void Update()
    {
        if (honeyOut.GetComponent<HoneyOut>().CurrentBigHoney >= honeyOut.GetComponent<HoneyOut>().MaxBigHoney && !isFireWork)
        {
            StartCoroutine(PlayFireWork());
            isFireWork = true;
        }
    }

    IEnumerator PlayFireWork()
    {
        for (int i = 0; i < 60; i++)
        {
            int randomFireWork = Random.Range(0, fireWork.Length);
            int randomSpawnPoint = Random.Range(0, spawnPoint.Length);

            GameObject fireWorkObejct = Instantiate(fireWork[randomFireWork]);
            fireWorkObejct.transform.position = spawnPoint[randomSpawnPoint].transform.position;
            yield return new WaitForSeconds(0.5f);
        }
    }
}
