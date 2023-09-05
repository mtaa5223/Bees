using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxCreate : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.Instantiate("HoneyBase", transform.position, transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
