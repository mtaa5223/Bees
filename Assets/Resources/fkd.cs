using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class fkd : MonoBehaviourPun
{
    public GameObject boxPrefab;
    private PhotonView Pv;
    

    // Start is called before the first frame update
    void Awake()
    {
        if (photonView.IsMine)
        {
            Debug.Log("����");
            GameObject boxInstance = Instantiate(boxPrefab, transform.position, transform.rotation);
            boxInstance.transform.SetParent(transform); // �θ��� �ڽ����� ����
        }
        else
        {
            
            Debug.Log("123");
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
