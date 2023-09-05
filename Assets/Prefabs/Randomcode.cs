using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using Photon.Pun;

public class Randomcode : MonoBehaviourPunCallbacks
{

    public Text text;
    void Start()
    {
        string roomCodePath = "RoomCodeTXT.txt";
        if (File.Exists(roomCodePath) == true)
        {
            Text roomCodeText = gameObject.GetComponent<Text>();
            roomCodeText.text = File.ReadAllText(roomCodePath);
        }




    }
}