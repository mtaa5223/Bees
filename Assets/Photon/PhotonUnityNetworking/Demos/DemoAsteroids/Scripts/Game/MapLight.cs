using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapLight : MonoBehaviour
{
    public GameObject targetObject; // 오브젝트를 드래그앤드롭으로 연결하세요
    public Text textObject; // 텍스트 오브젝트를 드래그앤드롭으로 연결하세요
    private int counter = 0;
    private float interval = 5.0f; // 5초 간격으로 오브젝트를 꺼지고 켜기

    void Start()
    {
        StartCoroutine(ToggleObject());
    }

    IEnumerator ToggleObject()
    {
        while (true)
        {
            yield return new WaitForSeconds(interval);
            targetObject.SetActive(false);
            counter++;
            UpdateText();
            yield return new WaitForSeconds(interval);
            targetObject.SetActive(true);
            UpdateText();
        }
    }

    void UpdateText()
    {
      
      
    }
}
