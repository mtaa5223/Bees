using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerDataScript : MonoBehaviour
{
    [System.Serializable]
    public struct FlowerData
    {
        public GameObject flowerModel;
        public float growTime;
        public float maxWater;

    }

    [SerializeField] private float growCurrentTime = 0;
    [SerializeField] private float currentWater = 0;
    public float CurrentWater { get { return currentWater; } set { currentWater = value; } }
    private int flowerGrade = 0;
    public bool waterrayt = true;

    public FlowerData[] flowerDatas;

    private GameObject flower;

    private void Start()
    {
        
    }

    private void Update()
    {
        growCurrentTime += Time.deltaTime;

        if (growCurrentTime >= flowerDatas[flowerGrade].growTime && currentWater >= flowerDatas[flowerGrade].maxWater)
        {
            if (flowerGrade < flowerDatas.Length - 1 && waterrayt == true)
            {
                FlowerUpgrade();
            }
        }
    }

    public void FlowerUpgrade()
    {
        flowerGrade++;

        if (flower != null)
        {
            Destroy(flower);
        }

        SetFlower(flowerGrade);

        currentWater = 0;
        growCurrentTime = 0;
    }

    public void SetFlower(int flowerGradeNum)
    {
        flower = Instantiate(flowerDatas[flowerGradeNum].flowerModel);
        flower.transform.SetParent(transform);
        flower.transform.position = transform.position;
    }
}
