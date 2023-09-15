using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapLight : MonoBehaviour
{
    public GameObject targetObject; // ������Ʈ�� �巡�׾ص������ �����ϼ���
    public Text textObject; // �ؽ�Ʈ ������Ʈ�� �巡�׾ص������ �����ϼ���
    private int counter = 0;
    private float interval = 5.0f; // 5�� �������� ������Ʈ�� ������ �ѱ�

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
