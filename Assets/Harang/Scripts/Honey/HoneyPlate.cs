using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class HoneyPlate : MonoBehaviourPun
{
    [SerializeField] private float maxHoney;
    [SerializeField] private float currentHoney;

    [SerializeField] private Shader honeyShader;

    private PhotonView Pv;

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

        PhotonView Pv = GetComponent<PhotonView>();
        honeyRenderer = transform.GetChild(0).GetComponent<Renderer>();
        honeyRenderer.material = new Material(honeyShader);

        honeyRenderer.material.SetFloat("_MinRemap", -0.85f);
        honeyRenderer.material.SetFloat("_MaxRemap", 0.85f);
    }

    private void Update()
    {
        honeyRenderer.material.SetFloat("_Fill", CurrentHoney / maxHoney);
    }
}