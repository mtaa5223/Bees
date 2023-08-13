using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class HoneyPlate : MonoBehaviour
{
    [SerializeField] private float maxHoney;
    [SerializeField] private float currentHoney;

    [SerializeField] private Shader honeyShader;

    public float CurrentHoney
    {
        get
        {
            return currentHoney;
        }
        set
        {
            if (currentHoney > maxHoney)
            {
                currentHoney = maxHoney;
            }
            else if (currentHoney < 0)
            {
                currentHoney = 0;
            }
            else
            {
                currentHoney = value;
            }
        }
    }

    private Renderer honeyRenderer;

    private void Start()
    {
        honeyRenderer = transform.GetChild(0).GetComponent<Renderer>();
        honeyRenderer.material = new Material(honeyShader);
    }

    private void Update()
    {
        honeyRenderer.material.SetFloat("_Fill", CurrentHoney / maxHoney);
    }
}
